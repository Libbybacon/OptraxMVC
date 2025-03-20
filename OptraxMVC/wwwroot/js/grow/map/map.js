//import * as mapDataFuncs from './mapData.js';
//import * as mapEditFuncs from './mapEdit.js';

var map;
var pointsLayer
var linesLayer
var polysLayer

let isDrawing = false;
let isLongPress = false;
let anchorPoint = null;
let previewLine = null;
let holdTimeout = null;

let curMarker = null;
let curLine = null;
let curPoly = null;

$(document).ready(function () {
    initializeMap();


    $(window).on('resize', function () {
        setMapHeight();
    });
})

function setMapListeners() {

    // change icon collection display
    $('.icon-coll-name').on('click', function () {
        let collID = $(this).data('collid')

        $('.icon-coll-name').removeClass('selected');
        $(`.coll-name-${collID}`).addClass('selected');

        $('.preview-div').addClass('d-none');
        $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
    })

    // Change point's tooltip content
    $('.point-info').on('input', function () {
        let props = { marker: curMarker, title: $('#Name').val(), desc: $('#Notes').val() }
        updateMarker(props);
    });

    // Update point icon
    $('.icon-div').on('click', function () {
        $('.icon-div').removeClass('selected');
        $('#IconID').val($(this).data('iconid')).change();

        $(this).addClass('selected');

        let imgURL = $(this).find('img').attr('src');
        let props = { iconURL: imgURL, marker: curMarker, title: $('#Name').val(), desc: $('#Notes').val() }

        updateMarker(props);
    })
}

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

    let addMapObjectControl = new L.Control.AddMapObject(); // AddMapObject Control
    map.addControl(addMapObjectControl);

    initializeLayers();
}

function initializeLayers() {

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    pointsLayer = L.geoJSON(null, {
        pointToLayer: function (feature, latlng) {

            let props = feature.properties;

            let icon = createIcon(props.iconPath);

            var marker = L.marker(latlng, { icon: icon }).bindTooltip(props.name, { permanent: true, direction: "top" });

            marker.on('click', function () {
                editPoint(props.id, props.name, marker);
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

    loadFeatures();
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
            toggleDrawingMode();
        };

        return container;
    }
});


//function toggleDrawingMode() {
//    isDrawing = !isDrawing;

//    if (isDrawing) {
//        map.getContainer().style.cursor = 'crosshair';
//        map.on('mousedown', handleMouseDown);
//        map.on('mouseup', handleMouseUp);
//        map.on('dblclick', startLine);
//        map.doubleClickZoom.disable();
//        $('.add-map-obj').addClass('bg-grn-dk');
//    }
//    else {
//        map.getContainer().style.cursor = '';
//        map.off('mousedown', handleMouseDown);
//        map.off('mouseup', handleMouseUp);
//        map.off('dblclick', startLine);
//        map.doubleClickZoom.enable();
//        $('.add-map-obj').removeClass('bg-grn-dk');
//    }
//}
//function handleMouseDown(event) {
//    isLongPress = false;

//    holdTimeout = setTimeout(() => {
//        isLongPress = true;
//        createPoint(event.latlng);
//        toggleDrawingMode();
//    }, 500);
//}

//function handleMouseUp() {
//    clearTimeout(holdTimeout);
//}

//function startLine(event) {

//    if (anchorPoint) {
//        return; // Ignore if already drawing line
//    }

//    anchorPoint = event.latlng;

//    previewLine = L.polyline([anchorPoint, anchorPoint], { color: 'blue', dashArray: '5, 5' }).addTo(map); // Temp line that follows the mouse

//    map.on('mousemove', updateLine);
//    map.once('click', finalizeLine); // Finalize line on second click
//}

//function updateLine(event) {
//    if (!previewLine) return;
//    previewLine.setLatLngs([anchorPoint, event.latlng]);// Update preview line as mouse moves
//}

//function finalizeLine(event) {

//    if (!anchorPoint) return;

//    let endPoint = event.latlng;
//    addLine(anchorPoint, endPoint);

//    if (previewLine) {
//        map.removeLayer(previewLine); // Remove preview line
//        previewLine = null;
//    }

//    anchorPoint = null;
//    map.off('mousemove', updateLine);
//}
function toggleDrawingMode() {
    isDrawing = !isDrawing;

    if (isDrawing) {
        map.doubleClickZoom.disable();
        map.getContainer().style.cursor = 'crosshair';
        map.on('click', addLinePoint);
        map.on('mousemove', updatePreview);
        map.on('dblclick', finalizeLine);
        $('.add-map-obj').addClass('bg-grn-dk');
    } else {
        map.getContainer().style.cursor = '';
        map.off('click', addLinePoint);
        map.off('mousemove', updatePreview);
        map.off('dblclick', finalizeLine);
        map.doubleClickZoom.enable();
        $('.add-map-obj').removeClass('bg-grn-dk');
        resetDrawing();
    }
}

function addLinePoint(event) {
    let point = event.latlng;

    if (lineGeom.length === 0) {
        lineGeom.push(point);
        currentLine = L.polyline([point], { color: 'blue', dashArray: '5, 5' }).addTo(map);
    } else {
        lineGeom.push(point);
        currentLine.setLatLngs(lineGeom);
    }
}

function updatePreview(event) {
    if (!currentLine || lineGeom.length === 0) return;


    let previewPoints = [...lineGeom, event.latlng]; // Add temporary last point for preview
    currentLine.setLatLngs(previewPoints);
}

function finalizeLine() {
    if (lineGeom.length < 2) return; 

    console.log("Final Line Coordinates:", lineGeom.map(p => [p.lng, p.lat]));

    //$("#LineString").value = JSON.stringify(lineGeom.map(p => [p.lng, p.lat]));
    $("#LineString").value = JSON.stringify(lineGeom.map(p => [p.lng, p.lat]));

    let props = {
        type: 'GET',
        url: `/Grow/Map/AddLine/`,
        title: "New Line",
        data: { lineString: JSON.stringify(lineGeom.map(p => [p.lng, p.lat])) },
        isDialog: true
    }
    loadPopup(editProps);
    //resetDrawing();
}

function resetDrawing() {
    if (currentLine) {
        map.removeLayer(currentLine);
        currentLine = null;
    }
    lineGeom = [];
}


function updateMarker(props) {
    if (props.iconURL && props.iconURL.length > 0) {
        let newIcon = createIcon(props.iconURL);
        props.marker.setIcon(newIcon);
    }

    let title = (props.title != undefined) ? `<b>${props.title}</b>` : "";
    let desc = (props.desc != undefined) ? `<br>${props.desc}` : "";

    let tooltipContent = `${title}${desc}`;
    props.marker._tooltip.setContent(tooltipContent);
}

function createIcon(url) {
    return L.icon({
        iconUrl: url,   // Path to the new icon image
        iconSize: [32, 32], // Size of the icon
        iconAnchor: [16, 32], // Point where the icon anchors on the map
        popupAnchor: [0, -32], // Adjust popup position relative to icon
        tooltipAnchor: [0, -32] // Adjust popup position relative to icon
    });
}

function addLine(start, end) {
    L.polyline([start, end], { color: 'red' }).addTo(map);
}