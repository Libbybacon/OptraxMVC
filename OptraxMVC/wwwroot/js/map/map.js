import { pointUtil, lineUtil, polyUtil, drawUtil, iconUtil, curObject } from './mapUtility.js';

export var map;
//export const curObject = { val: null };

var pointsLayer
var linesLayer
var polysLayer



$(document).ready(function () {

    initializeMap();
    initializeLayers();
    createControls();
    loadFeatures();

    $(window).on('resize', function () {
        setMapHeight();
    });
})

function initializeMap() {
    map = L.map('map', {
        center: [-1.28333, 36.81667],
        zoom: 13
    });

    map.on('click', function (event) {
        event.originalEvent.preventDefault();  // Prevent default behavior
        event.originalEvent.stopPropagation(); // Stop the event from affecting the page
    });
    setMapHeight();
}

function setMapHeight() {
    if ($(window).width() < 768) {
        $('#map').css('height', 'calc(-75px + 100vh)');
    }
    else {
        $('#map').css('height', 'calc(-45px + 100vh)');
    }
    map.invalidateSize();
}

async function loadFeatures() {
    //setInterval(() => {
    //    await this.loadPoints();
    //    await this.loadLines();
    //    await this.loadPolygons();
    //}, 30000);
    await pointUtil.loadPoints(pointsLayer);
    //await lineUtil.loadLines(linesLayer);
}

function initializeLayers() {

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    pointsLayer = L.geoJSON(null, {

        pointToLayer: function (feature, latlng) {

            let props = feature.properties;
            let icon = iconUtil.createIcon(props.iconPath);
            var marker = L.marker(latlng, { icon: icon }).bindTooltip(props.name, { permanent: true, direction: "top" });

            marker.on('click', function () {
                pointUtil.editPoint(props.id, props.name, marker);
            })
            return marker;
        }
    }).addTo(map);

    linesLayer = L.geoJSON(null, {
        style: function (feature) {
            return { color: feature.properties.color || "blue", weight: 3 };
        }
    }).addTo(map);

    polysLayer = L.geoJSON(null, {
        style: function (feature) {
            return { color: feature.properties.color || "green", fillOpacity: 0.5 };
        }
    }).addTo(map);
}

function createControls() {

    let addObjControl = new L.Control.AddMapObject(); // AddMapObject Control
    map.addControl(addObjControl);
}

L.Control.AddMapObject = L.Control.extend({
    options: {
        position: 'topright'
    },

    onAdd: function (map) {
        let container = L.DomUtil.create('div', 'leaflet-control-map-object');

        let btn = L.DomUtil.create('button', 'form-btn add-map-obj', container);
        btn.innerHTML = 'Add Map Object';

        L.DomEvent.disableClickPropagation(container);

        btn.onclick = function () {
            drawUtil.toggleDrawingMode();
        };
        return container;
    }
});






//function toggleDrawingMode() {
//    isDrawing = !isDrawing;

//    if (isDrawing) {
//        map.doubleClickZoom.disable();
//        map.getContainer().style.cursor = 'crosshair';
//        map.on('click', addLinePoint);
//        map.on('mousemove', updatePreview);
//        map.on('dblclick', finalizeLine);
//        $('.add-map-obj').addClass('bg-grn-dk');
//    } else {
//        map.getContainer().style.cursor = '';
//        map.off('click', addLinePoint);
//        map.off('mousemove', updatePreview);
//        map.off('dblclick', finalizeLine);
//        map.doubleClickZoom.enable();
//        $('.add-map-obj').removeClass('bg-grn-dk');
//        resetDrawing();
//    }
//}

//function addLinePoint(event) {
//    let point = event.latlng;

//    if (lineGeom.length === 0) {
//        lineGeom.push(point);
//        currentLine = L.polyline([point], { color: 'blue', dashArray: '5, 5' }).addTo(map);
//    } else {
//        lineGeom.push(point);
//        currentLine.setLatLngs(lineGeom);
//    }
//}

//function updatePreview(event) {
//    if (!currentLine || lineGeom.length === 0) return;


//    let previewPoints = [...lineGeom, event.latlng]; // Add temporary last point for preview
//    currentLine.setLatLngs(previewPoints);
//}

//function finalizeLine() {
//    if (lineGeom.length < 2) return;

//    console.log("Final Line Coordinates:", lineGeom.map(p => [p.lng, p.lat]));

//    //$("#LineString").value = JSON.stringify(lineGeom.map(p => [p.lng, p.lat]));
//    $("#LineString").value = JSON.stringify(lineGeom.map(p => [p.lng, p.lat]));

//    let props = {
//        type: 'GET',
//        url: `/Grow/Map/AddLine/`,
//        title: "New Line",
//        data: { lineString: JSON.stringify(lineGeom.map(p => [p.lng, p.lat])) },
//        isDialog: true
//    }
//    loadPopup(props);
//    //resetDrawing();
//}

//function resetDrawing() {
//    if (currentLine) {
//        map.removeLayer(currentLine);
//        currentLine = null;
//    }
//    lineGeom = [];
//}




