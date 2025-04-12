import * as _obj from './objectManager.js';
import { setMap, setLayersReady } from './mapState.js';
import * as _layers from './layerManager.js';
import { createIcon } from './objStyleUtil.js';

let map = null;
let layersets = [];
$(function () {

    initializeMap();

    $(window).on('resize', function () {
        setMapHeight();
    });
})

async function initializeMap() {
    map = L.map('map', {
        center: [39.8283, -98.5795],
        zoom: 4,
        editable: true,
    });
    setMap(map);

    map.on('click', function (e) {
        e.originalEvent.preventDefault();
        e.originalEvent.stopPropagation();
    });

    setMapHeight();
    _layers.initializeLayers();
    createControls();

    await _layers.loadFeatures().then(() => {

        layersets = _layers.getAllLayers()
        zoomToAllLayers();

    });

    map.on('popupclose', function () {
        $(document).find(".color-picker").spectrum("hide");
        $('.title-control').show();
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

// Center map on center of all layers
function zoomToAllLayers() {
    let ctr = null;
    const bounds = [];

    _layers.getAllLayers().forEach(l => {
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
    setLayersReady(true);
}

function createControls() {
    L.Marker.prototype.options.icon = createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE')

    //const drawControl = new L.Control.Draw({
    //    draw: {
    //        polyline: true,
    //        polygon: true,
    //        rectangle: true,
    //        circle: true,
    //        marker: true,
    //        circlemarker: false
    //    }
    //});
    //map.addControl(drawControl);

    //map.on('draw:created', function (e) {
    //    _obj.addObject(e.layer, e.layerType);

    //});

    addTopCenterPosition();

    const titleControl = L.Control.extend({
        onAdd: function () {
            const titleDiv = L.DomUtil.create('div', 'leaflet-control title-control');
            const $title = document.getElementById('map-title');

            if ($title) {
                titleDiv.innerHTML = $title.innerHTML;
            }

            L.DomEvent.disableClickPropagation(titleDiv);

            $(document).on('click', '.map-toggle', function (e) {
                /*console.log('click')*/
                $('.map-info').toggleClass('d-none');
                e.stopPropagation()
            })

            _obj.mapFormUtil.setFormListeners('#mapForm');

            return titleDiv;
        }
    });
    map.addControl(new titleControl({ position: 'topcenter' }));
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

export function addSitePoint(lng, lat, name) {
    let props = _obj.layerProps;
    props["name"] = name;

    const sitePoint = {
        type: "Feature",
        properties: props,
        geometry: {
            type: "Point",
            coordinates: [lng, lat]
        },
    };
    const pointsL = _layers.getLayerset('marker');
    console.log('addSitePoint sitePoint', sitePoint);
    pointsL.addData(sitePoint);
}
