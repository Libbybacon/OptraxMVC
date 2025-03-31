import apiService from '../utilities/api.js';
import { loadEdit } from './objectManager.js';
import { createIcon } from './objStyleUtil.js';
import { getMap, setMap, setIndex, deleteIndex, setActive } from './mapState.js';

let pointsL, linesL, polysL, circlesL;

let map = null;
export function initializeLayers() {
    map = getMap();

     console.log('initializeLayers map: ', map)
    const satellite = L.tileLayer('https://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3'],
        attribution: '© Google'
    }).addTo(map);

    const osm = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    });

    const baseMaps = {
        "Satellite": satellite,
        "OpenStreetMap": osm,
    };

    L.control.layers(baseMaps).addTo(map);

    pointsL = L.geoJSON(null, {
        pointToLayer: function (feat, latlng) {
            const icon = createIcon(feat.properties.iconPath);
            const l = L.marker(latlng, { icon: icon });

            setType(feat, 'Point');
            setActions(feat.properties, l);
            return l;
        }
    }).addTo(map);

    linesL = L.geoJSON(null, {
        style: function (feat) {
            return setStyle(feat.properties);
        },
        onEachFeature: (feat, l) => {
            setType(feat, 'Line');
            setActions(feat.properties, l);
        }
    }).addTo(map);

    circlesL = L.geoJSON(null, {
        pointToLayer: function (feat, latlng) {
            let props = feat.properties;
            props["fillOpacity"] = 1;

            if (props && props.radius) {
                return L.circle(latlng, props);
            }
            return L.marker(latlng);
        },
        onEachFeature: (feat, l) => {
            setType(feat, 'Circle');
            setActions(feat.properties, l);
        }
    }).addTo(map);

    polysL = L.geoJSON(null, {
        style: function (feat) {
            feat.properties["fillOpacity"] = 1;
            return setStyle(feat.properties);
        },
        onEachFeature: (feat, l) => {
            setType(feat, 'Polygon');
            setActions(feat.properties, l);
        }
    }).addTo(map);

    setMap(map);
}

export function setType(feat, type) {
    feat.properties["objType"] = type;
}

export function setStyle(props) {
    let style = {
        color: props.color,
        weight: props.weight,
        dashArray: props.dashArray,
        fillColor: props.fillColor,
        fillOpacity: props.fillOpacity
    };
    if (props.objType === 'Circle') {
        style["radius"] = props.radius;
    }
    return style;
}

export function setActions(props, layer) {

    const type = props.objType;

    setIndex(props.id, layer);

    layer.bindTooltip(props.name, { permanent: true, direction: "top" });

    layer.on('click', async function (e) {
        setActive(layer);
        const center = (type === 'Point' || type === 'Circle') ? e.latlng : layer.getBounds().getCenter();

        loadEdit(props.id, type, center);
    });

    layer.on('remove', function () {
        deleteIndex(props.id);
        const map = getMap();
        map.closePopup();
    });
}

export async function loadFeatures() {
    await loadObjects(pointsL, 'Point');
    await loadObjects(linesL, 'Line');
    await loadObjects(polysL, 'Polygon');
    await loadObjects(circlesL, 'Circle');
}

export async function loadObjects(mapLayer, layerType) {
    try {
        console.log('mapLayer', mapLayer, 'layerType', layerType);
        const response = await apiService.get('/Grow/Map/GetObjects', { objType: layerType });
        console.log('response', response);

        if (response.success === false) { alert(`Failed to load ${layerType.toLowerCase()}s`); throw new Error(response.error || `Failed to load ${layerType.toLowerCase()}s`); }

        mapLayer.addData(response.data);
    }
    catch (error) {
        console.error("Error loading points:", error);
    }
}

export const getLayerset = objType => {

    switch (objType) {
        case 'marker':
            return pointsL;
        case 'polyline':
            return linesL;
        case 'circle':
            return circlesL;
        default:
            return polysL;
    }
}

export function getPointsLayer() { return pointsL; }
export function getLinesLayer() { return linesL; }
export function getCirclesLayer() { return circlesL; }
export function getPolysLayer() { return polysL; }
export function getAllLayers() {
    return [pointsL, linesL, circlesL, polysL ];
}
