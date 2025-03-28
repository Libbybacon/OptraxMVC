import * as util from './mapUtility.js';


export var map;

var pointsL;
var linesL;
var polysL;
var circlesL;

const urlBase = '/Grow/Map/';
const typeMap = {
    marker: 'Point',
    polyline: 'Line',
    circle: 'Circle'
};

const viewProps = {
    type: 'GET',
    isDialog: true,
}

export const layerIndex = new Map();

$(document).ready(function () {

    initializeMap();

    $(window).on('resize', function () {
        setMapHeight();
    });
})

async function initializeMap() {
    map = L.map('map', {
        center: [39.8283, -98.5795],
        zoom: 4
    });

    map.on('click', function (event) {
        event.originalEvent.preventDefault();  // Prevent default behavior
        event.originalEvent.stopPropagation(); // Stop the event from affecting the page
    });
    setMapHeight();
    initializeLayers();
    createControls();
    await loadFeatures().then(() => {
        zoomToAllLayers();
    });

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
    await util.loadObjects(pointsL, 'Point');
    await util.loadObjects(linesL, 'Line');
    await util.loadObjects(polysL, 'Polygon');
    await util.loadObjects(circlesL, 'Circle');
}

function initializeLayers() {

    var satellite = L.tileLayer('https://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3'],
        attribution: '© Google'
    }).addTo(map);

    var osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    });

    var baseMaps = {
        "Satellite": satellite,
        "OpenStreetMap": osm,
    };

    L.control.layers(baseMaps).addTo(map);

    pointsL = L.geoJSON(null, {

        pointToLayer: function (feature, latlng) {
            const props = feature.properties;
            props["objType"] = 'Point';
            const icon = util.iconUtil.createIcon(props.iconPath);
            const layer = L.marker(latlng, { icon: icon });

            setActions(props, layer);
            return layer;
        }
    }).addTo(map);

    linesL = L.geoJSON(null, {
        style: function (feature) {
            return setStyle(feature.properties,);
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Line';
            setActions(feature.properties, layer);
        }
    }).addTo(map);

    circlesL = L.geoJSON(null, {
        pointToLayer: function (feature, latlng) {
            console.log('circle pointToLayer feature', feature, 'properties', feature.properties)
            feature.properties["fillOpacity"] = 1;
            if (feature.properties && feature.properties.radius) {

                return L.circle(latlng, feature.properties);
            }
            return L.marker(latlng); // just render as marker if no radius
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Circle';
            setActions(feature.properties, layer);
        }
    }).addTo(map);

    polysL = L.geoJSON(null, {
        style: function (feature) {
            feature.properties["fillOpacity"] = 1;
            return setStyle(feature.properties);
        },
        onEachFeature: (feature, layer) => {
            feature.properties['objType'] = 'Polygon';
            setActions(feature.properties, layer);
        }
    }).addTo(map);
}

function zoomToAllLayers() {
    let ctr = null;
    const bounds = [];

    [pointsL, linesL, circlesL, polysL].forEach(l => {
        if (l.getLayers().length > 0) {
            const b = l.getBounds();
            if (b.isValid()) {
                bounds.push(b);
            }
        }
    });

    if (bounds.length > 0) {
        ctr = bounds[0];
        for (let i = 1; i < bounds.length; i++) {
            ctr = ctr.extend(bounds[i]);
        }
    }
    ctr ? map.fitBounds(ctr, { padding: [40, 40] }) : map.setView([39.8283, -98.5795], 4);
}

function setActions(props, layer) {

    const type = props.objType;
    layerIndex.set(props.id, layer);

    layer.bindTooltip(props.name, { permanent: true, direction: "top" });

    layer.on('click', async function (e) {

        util.curLayer.val = layer;

        const center = (type == 'Point' || type == 'Circle') ? e.latlng : layer.getBounds().getCenter();

        util.getEdit(props.id, type, center)
    })

    layer.on('remove', function () {
        layerIndex.delete(props.id);
        map.removeLayer(layer);
        map.closePopup();
    });
}

function setStyle(props) {
    let style = {
        color: props.color,
        weight: props.weight,
        dashArray: props.dashArray,
        fillColor: props.fillColor,
        fillOpacity: props.fillOpacity
    }
    if (props.objType == 'Circle') {
        style["radius"] = props.radius;
    }
    return style;
}

function createControls() {
    L.Marker.prototype.options.icon = util.iconUtil.createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE')

    const drawControl = new L.Control.Draw({
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
            marker: pointsL,
            polyline: linesL,
            circle: circlesL
        };
        let layerset = layersetMap[e.layerType] ?? polysL;
        util.addObject(e, layerset);

    });

    addTopCenterPosition();

    const TitleControl = L.Control.extend({
        onAdd: function () {
            const mapTitle = L.DomUtil.create('div', 'leaflet-control title-control');

            const $title = document.getElementById('map-title');
            if ($title) {
                mapTitle.innerHTML = $title.innerHTML;
            }

            L.DomEvent.disableClickPropagation(mapTitle);

            $(document).on('click', '.map-toggle', function (e) {
                console.log('click')
                $('.map-info').toggleClass('d-none');
                e.stopPropagation()
            })

            util.mapFormUtil.setFormListeners('#mapForm');


            return mapTitle;
        }
    });

    map.addControl(new TitleControl({ position: 'topcenter' }));

}

function addTopCenterPosition() {
    L.Control.Position = Object.assign(L.Control.Position || {}, {
        TOPCENTER: 'topcenter'
    });
    L.Map.mergeOptions({
        controlPositions: {
            topcenter: L.Control.Position.TOPCENTER
        }
    });
    L.Control.include({
        _setPosition: function (position) {
            const map = this._map;
            const pos = map._controlCorners[position];

            if (!pos) return;

            L.DomUtil.addClass(this._container, 'leaflet-control');
            pos.appendChild(this._container);
        }
    });
    map._controlCorners.topcenter = L.DomUtil.create('div', 'leaflet-top leaflet-center', map._controlContainer);
}
