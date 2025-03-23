import * as util from './mapUtility.js';


export var map;

var pointsLayer;
var linesLayer;
var polysLayer;
var circlesLayer;

const module = { path: '/js/map/mapObjects.js', method: 'init' };
const urlBase = '/Grow/Map/';
const typeMap = {
    marker: 'Point',
    polyline: 'Line',
    circle: 'Circle'
};

const viewProps = {
    type: 'GET',
    isDialog: true,
    mod: module
}
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

    map.on('popupclose', function () {
        $(document).find(".color-picker").spectrum("hide");
    });
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
    await util.loadObjects(pointsLayer, 'Point');
    await util.loadObjects(linesLayer, 'Line');
    await util.loadObjects(polysLayer, 'Polygon');
}

function initializeLayers() {

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    pointsLayer = L.geoJSON(null, {

        pointToLayer: function (feature, latlng) {


            const props = feature.properties;
            props["objType"] = 'Point';
            const icon = util.iconUtil.createIcon(props.iconPath);
            const layer = L.marker(latlng, { icon: icon });

            setActions(props, layer);
            return layer;
        }
    }).addTo(map);

    linesLayer = L.geoJSON(null, {
        style: function (feature) {
            return setStyle(feature.properties,);
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Line';
            setActions(feature.properties, layer);
        }
    }).addTo(map);

    circlesLayer = L.geoJSON(null, {
        pointToLayer: function (feature, latlng) {

            if (feature.properties && feature.properties.radius) {
                return L.circle(latlng, setStyle(feature.properties));
            }
            return L.marker(latlng); // just render as marker if no radius
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Circle';
            setActions(feature.properties, layer);
        }
    }).addTo(map);

    polysLayer = L.geoJSON(null, {
        style: function (feature) {
            feature.properties['opacity'] = 1;
            return setStyle(feature.properties);
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Polygon';
            setActions(feature.properties, layer);
        }
    }).addTo(map);
}

function setActions(props, layer) {

    const type = props.objType;
    layerIndex.set(props.id, layer);

    layer.bindTooltip(props.name, { permanent: true, direction: "top" });

    layer.on('click', async function (e) {

        util.curLayer.val = layer;

        const center = (type == 'Point' || type == 'Circle') ? e.latlng : layer.getBounds().getCenter();
        const point = map.setView(center, map.getZoom());

        util.getEdit(props.id, type, center)
    })

    layer.on('remove', function () {
        layerIndex.delete(props.id);
        map.removeLayer(layer);
    });
}

function setStyle(props) {
    let style = {
        color: props.color,
        weight: props.weight,
        dashArray: props.dashArray,
        fillColor: props.fillColor,
    }
    if (props.objType == 'circle') {
        style["radius"] = props.radius;
    }
    return style;
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
        console.log('draw type', e.layerType);
        console.log('e', e);
        const layersetMap = {
            marker: pointsLayer,
            polyline: linesLayer,
            circle: circlesLayer
        };
        let layerset = layersetMap[e.layerType] ?? polysLayer;
        util.addObject(e, layerset);

    });
}
