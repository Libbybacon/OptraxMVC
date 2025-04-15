import apiService from '../utilities/api.js';
import { loadEdit, urlBase, getLayerCenter } from './objectManager.js';
import { createIcon, saveStyle } from './objStyleUtil.js';
import { getMap, setMap, setIndex, deleteIndex, setActive } from './mapState.js';

let pointsL, linesL, polysL, circlesL;

let map = null;
export function initializeLayers() {
    map = getMap();

    //console.log('initializeLayers map: ', map)
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

    //console.log('initializeLayers map: ', map)

    pointsL = L.geoJSON(null, {
        pointToLayer: function (feat, latlng) {
            console.log('pointToLayer feat', feat);
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
            //console.log('lineFeature feat', feat);
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
            //console.log('circleFeature feat', feat);
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
            //console.log('polyFeature feat', feat);
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
    const id = props.id;
    const type = props.objType;
    const isCircle = type == 'Circle';

    setIndex(id, layer);

    const editProps = {
        type: type,
        data: { id: id, objType: type },
        url: `${urlBase}LoadEdit/`
    }

    layer.bindTooltip(props.name, { permanent: true, direction: "top" });

    setClickHandlers(layer,
        function (e) {
            setActive(layer);
            editProps["center"] = getLayerCenter(layer);
            editProps["radius"] = isCircle ? layer.getRadius() : null;
            console.log('setClickHandlers single editProps', editProps);
            loadEdit(editProps);
        },
        function (e) {
            if (layer.enableEdit) {
                setActive(layer);
                saveStyle();
                layer.enableEdit();
                layer.once('editable:disable', () => {
                    editProps["center"] = getLayerCenter(layer);
                    editProps["radius"] = isCircle ? layer.getRadius() : null;
                    console.log('setClickHandlers dbl editProps', editProps);
                    loadEdit(editProps)
                });
            }
        }
    );


    layer.on('remove', function () {
        deleteIndex(props.id);
        if (layer.editEnabled && layer.editEnabled()) {
            layer.disableEdit(); // this removes any editable artifacts (vertices, drag handles, etc.)
        }
/*        map.removeLayer(layer);*/
        map.closePopup();
    });
}

//// Center map on selected object
//layer.on('click', async function (e) {
//    setActive(layer);
//    const center = (type === 'Point' || type === 'Circle') ? e.latlng : layer.getBounds().getCenter();

//    loadEdit(props.id, type, center);
//});

export function setClickHandlers(layer, onClick, onDblClick, delay = 250) {
    let clickTimer = null;

    layer.on('click', function (e) {
        if (clickTimer) return;

        clickTimer = setTimeout(() => {
            clickTimer = null;
            onClick(e);
        }, delay);
    });

    layer.on('dblclick', function (e) {
        if (clickTimer) {
            clearTimeout(clickTimer);
            clickTimer = null;
        }
        onDblClick(e);
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
        //console.log('mapLayer', mapLayer, 'layerType', layerType);
        const response = await apiService.get('/Grow/Map/GetObjects', { objType: layerType });
        //console.log('response', response);

        if (response.success === false) { alert(`Failed to load ${layerType.toLowerCase()}s`); throw new Error(response.error || `Failed to load ${layerType.toLowerCase()}s`); }

        mapLayer.addData(response.data);
    }
    catch (error) {
        console.error(`Error loading ${layerType}s:`, error);
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

export function getAllLayers() {
    return [pointsL, linesL, circlesL, polysL];
}


