import apiService from '../utilities/api.js';
import { map } from './map.js';

export var curObject;

const module = { path: '/js/map/mapObjects.js', method: 'init' };
const urlBase = '/Grow/Map/';
let props = {
    type: 'GET',
    isDialog: true,
    mod: module
}

let isDrawing = false;
var isLongPress = false;
let anchorPoint = null;
let previewLine = null;
let holdTimeout = null;

export const pointUtil = {
    loadPoints: async function (pointsLayer) {

        try {
            const response = await apiService.get('/Grow/Map/GetPoints');

            if (response.success === false) {
                throw new Error(response.error || "Failed to load points");
            }

            pointsLayer.addData(response.data);
        }
        catch (error) {
            console.error("Error loading points:", error);
        }
    },
    createPoint: function (latlng) {

        let newIcon = iconUtil.createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE');

        curObject = L.marker(latlng).addTo(map).setIcon(newIcon).bindTooltip("New Point", { permanent: true, direction: "top" }).openTooltip();

        props['title'] = 'New Point'
        props['data'] = { lat: latlng.lat, lng: latlng.lng };
        props['url'] = urlBase + 'AddPoint/'

        window.loadPopup(props);

        window.addEventListener("removeNewIcon", this.removeIcon);
        window.dispatchEvent(new Event("removeNewIcon"));
    },
    createSuccess: function (response) {

        window.closePopup();
    },
    removeIcon: function () {
        $(document).on('click', '.ui-draggable .popup-close', function () {
            curObject.removeFrom(map);
            window.removeEventListener("removeNewIcon", this.removeIcon);
        });
    },
    editPoint: function (id, name, marker) {

        curObject = marker;

        props['title'] = name;
        props['data'] = { pointID: id };
        props['url'] = urlBase + 'EditPoint/'

        window.loadPopup(props);
    },
    editSuccess: function (response) {
        window.closePopup();
    }
}

export const lineUtil = {
    loadLines: function () {
        console.log("Loading lines...");
    },
    createLine: function (lineString) {
        props['title'] = 'New Line'
        props['data'] = { lineString: lineString };
        props['url'] = urlBase + 'AddLine/'

        window.loadPopup(props);
    },
    createLineSuccess: function (response) {
        //if (previewLine) {
        //    map.removeLayer(previewLine); // Remove preview line
        //    previewLine = null;
        //}
        window.closePopup();
    },
    removeIcon: function () {
        $(document).on('click', '.ui-draggable .popup-close', function () {
            curObject.removeFrom(map);
            window.removeEventListener("removeNewLine", this.removeLine);
        });
    },
    editLine: function (id, name) {
        props['title'] = name
        props['data'] = { lineString: lineString };
        props['url'] = urlBase + 'EditLine/'

        window.loadPopup(props);
    },
    editLineSuccess: function (response) {
        console.log('response', response);
        window.closePopup();
    },
    updateDisplay: function (input, val) {
        switch (input) {
            case 'color':
                curObject.setStyle({ color: val });
                break;
            case 'width':
                curObject.setStyle({ weight: val });
                break;
            case 'name':
                curObject._tooltip.setContent(`<b>${val}</b>`);
        }
    }
}

export const polyUtil = {
    loadPolygons: function () {
        console.log("Loading polygons...");
    }
}

export const drawUtil = {
    toggleDrawingMode: function () {
        isDrawing = !isDrawing;

        if (isDrawing) {
            map.doubleClickZoom.disable();
            map.getContainer().style.cursor = 'crosshair';
            map.on('mousedown', drawUtil.handleMouseDown);
            map.on('mouseup', drawUtil.handleMouseUp);
            map.on('dblclick', drawUtil.startLine);
            $('.add-map-obj').addClass('bg-grn-dk');
        }
        else {
            map.getContainer().style.cursor = '';
            map.off('mousedown', drawUtil.handleMouseDown);
            map.off('mouseup', drawUtil.handleMouseUp);
            map.off('dblclick', drawUtil.startLine);
            map.doubleClickZoom.enable();
            $('.add-map-obj').removeClass('bg-grn-dk');
        }
    },
    handleMouseDown: function (event) {
        isLongPress = false;

        holdTimeout = setTimeout(() => {
            isLongPress = true;
            pointUtil.createPoint(event.latlng);
            toggleDrawingMode();
        }, 500);
    },

    handleMouseUp: function () {
        clearTimeout(holdTimeout);
    },

    startLine: function (event) {

        if (anchorPoint) {
            return; // Ignore if already drawing line
        }

        anchorPoint = event.latlng;

        previewLine = L.polyline([anchorPoint, anchorPoint], { color: 'blue', dashArray: '5, 5' }).bindTooltip("New Line", { permanent: true, direction: "top" }).openTooltip().addTo(map); // Temp line that follows the mouse

        map.on('mousemove', drawUtil.updatePreviewLine);
        map.once('click', drawUtil.finalizeLine); // Finalize line on second click
    },

    updatePreviewLine: function (event) {
        if (!previewLine) return;
        previewLine.setLatLngs([anchorPoint, event.latlng]);// Update preview line as mouse moves
    },

    finalizeLine: function (event) {

        if (!anchorPoint) return;
        map.off('mousemove', drawUtil.updatePreviewLine);

        let endPoint = event.latlng;
        curObject = previewLine;

        lineUtil.createLine(anchorPoint, endPoint);
        anchorPoint = null;
    },

    addLine: function (start, end) {
        L.polyline([start, end], { color: 'red' }).addTo(map);
    }
}

export const iconUtil = {
    updateMarker: function (props) {
        console.log('updateMarker props', props)
        if (props.iconURL && props.iconURL.length > 0) {
            let newIcon = iconUtil.createIcon(props.iconURL);
            props.marker.setIcon(newIcon);
        }

        let title = (props.title != undefined) ? `<b>${props.title}</b>` : "";
        let desc = (props.desc != undefined) ? `<br>${props.desc}` : "";

        let tooltipContent = `${title}${desc}`;
        props.marker._tooltip.setContent(tooltipContent);
    },
    createIcon: function (url) {
        return L.icon({
            iconUrl: url,   // Path to the new icon image
            iconSize: [32, 32], // Size of the icon
            iconAnchor: [16, 32], // Point where the icon anchors on the map
            popupAnchor: [0, -32], // Adjust popup position relative to icon
            tooltipAnchor: [0, -32] // Adjust popup position relative to icon
        });
    }
}