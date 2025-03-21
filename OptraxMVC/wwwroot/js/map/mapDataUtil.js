import apiService from '../apiService.js';
import { map } from './map.js';

export var curObject;

export const pointUtil = {
    loadPoints: async function (pointsLayer) {

        try {
            const response = await apiService.getNoParams('/Grow/Map/GetPoints');

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

        let newIcon = this.createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE');

        curObject = L.marker(latlng).addTo(map).setIcon(newIcon).bindTooltip("New Point", { permanent: true, direction: "top" }).openTooltip();

        let props = {
            type: 'GET',
            url: `/Grow/Map/AddPoint/`,
            title: `New Point`,
            data: { lat: latlng.lat, lng: latlng.lng },
            isDialog: true
        }
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

        let editProps = {
            type: 'GET',
            url: `/Grow/Map/EditPoint/`,
            title: name,
            data: { pointID: id },
            isDialog: true
        }
        window.loadPopup(editProps);
    },
    editSuccess: function (response) {
        console.log('response', response);
        window.closePopup();
    }
}

export const lineUtil = {
    loadLines: function () {
        console.log("Loading lines...");
    },
    createLine: function (lineString) {
        let props = {
            type: 'GET',
            url: `/Grow/Map/AddLine/`,
            title: `New Line`,
            data: { lineString: lineString },
            isDialog: true
        }
        window.loadPopup(props);
    },
    createLineSuccess: function (response) {

        window.closePopup();
    },
    removeIcon: function () {
        $(document).on('click', '.ui-draggable .popup-close', function () {
            curObject.removeFrom(map);
            window.removeEventListener("removeNewLine", this.removeLine);
        });
    },
    editLine: function (id, name, marker) {

        curObject = marker;

        let editProps = {
            type: 'GET',
            url: `/Grow/Map/EditLine/`,
            title: name,
            data: { pointID: id },
            isDialog: true
        }
        window.loadPopup(editProps);
    },
    editLineSuccess: function (response) {
        console.log('response', response);
        window.closePopup();
    }
}

export const polyUtil = {
    loadPolygons: function () {
        console.log("Loading polygons...");
    }
}
