import * as util from './mapUtility.js';

export var map;

var pointsLayer;
var linesLayer;
var polysLayer;
var circlesLayer;


export const layerIndex = new Map();


$(document).ready(function () {

    initializeMap();

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
    initializeLayers();
    createControls();
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

async function loadFeatures() {
    //setInterval(() => {
    //    await this.loadPoints();
    //    await this.loadLines();
    //    await this.loadPolygons();
    //}, 30000);
    await util.loadObjects(pointsLayer, 'point');
    //await lineUtil.loadLines(linesLayer);
}

function initializeLayers() {

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    pointsLayer = L.geoJSON(null, {

        pointToLayer: function (feature, latlng) {
            const props = feature.properties;           

            const icon = util.iconUtil.createIcon(props.iconPath);
            const marker = L.marker(latlng, { icon: icon }).bindTooltip(props.name, { permanent: true, direction: "top" });

            marker.on('click', function () {
                util.curLayer.val = marker;
                util.onEdit(props.id, 'point', props.name);
            })

            layerIndex.set(props.id, marker);

            return marker;
        }
    }).addTo(map);

    linesLayer = L.geoJSON(null, {
        style: function (feature) {
            return feature.properties.style;
        },
        onEachFeature: (feature, layer) => {
            const props = feature.properties;

            layerIndex.set(props.id, layer);
            layer.bindTooltip(props.name, { permanent: true, direction: "top" });

            layer.on('click', function () {
                util.curLayer.val = layer;
                util.onEdit(props.id, 'line', props.name);
            })
        }
    }).addTo(map);

    circlesLayer = L.geoJSON(null, {
        pointToLayer: function (feature, latlng) {
            if (feature.properties?.style?.radius) {
                return L.circle(latlng, feature.properties.style);
            }
            return L.marker(latlng); // fallback if needed
        },
        onEachFeature: function (feature, layer) {
            const props = feature.properties;

            layer.bindTooltip(props.name, { permanent: true, direction: "top" });

            layerIndex.set(props.id ?? -1, layer);

            layer.on('click', function () {
                util.curLayer.val = layer;
                util.onEdit(props.id ?? -1, 'circle', props.name);
            });
        }
    }).addTo(map);

    polysLayer = L.geoJSON(null, {
        style: function (feature) {
            return feature.properties.style;
        },
        onEachFeature: (feature, layer) => {
            const props = feature.properties;

            layerIndex.set(props.id, layer);
            layer.bindTooltip(props.name, { permanent: true, direction: "top" });

            layer.on('click', function () {
                util.curLayer.val = layer;
                util.onEdit(props.id, 'polygon', props.name);
            })
        }
    }).addTo(map);
}

function createControls() {
    L.Marker.prototype.options.icon = util.iconUtil.createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE')

    var drawControl = new L.Control.Draw({
        draw: {
            polyline: true, // enable polyline drawing
            polygon: true,
            rectangle: true,
            circle: true,
            marker: true,
            circlemarker: false
        }
    });
    map.addControl(drawControl);

    map.on('draw:created', function (e) {
        const layersetMap = {
            marker: pointsLayer,
            polyline: linesLayer,
            circle: circlesLayer
        };
        let layerset = layersetMap[e.type] ?? polysLayer;
        util.drawUtil.addObject(e, layerset);

    });
}
