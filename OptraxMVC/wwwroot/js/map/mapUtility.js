import apiService from '../utilities/api.js';
import { map, layerIndex } from './map.js';

export var curLayer = { val: {} };

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

const layerProps = {
    id: -1,
    style: {
        weight: 3,
        dashArray: '5 5',
        color: '#1d52d7',
        fillColor: '#1d52d782',
    },
    iconPath: 'https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE'
};

export async function loadObjects(mapLayer, layerType) {
    try {
        const response = await apiService.get('/Grow/Map/GetObjects', { objType: layerType });

        if (response.success === false) { throw new Error(response.error || "Failed to load points"); }

        mapLayer.addData(response.data);
    }
    catch (error) {
        console.error("Error loading points:", error);
    }
}

//TODO: center object on map, open edit dialog above
export function onCreate(response) {
    window.closePopup();

    let newID = response.data.id;
    let layer = layerIndex.get(-1);

    if (!layer) return;

    if (layer.feature && layer.feature.properties) {
        layer.feature.properties.id = newID; // Update layer w db id
    }

    layerIndex.set(newID, layer);// Update layerIndex
    layerIndex.delete(-1);
}

export function onEdit(id, layerType, name) {
    viewProps['title'] = name;
    viewProps['data'] = { id: id, objType: layerType };
    viewProps['url'] = urlBase + `LoadEdit/`

    window.loadPopup(viewProps).then(() => {
        drawUtil.restoreStyle();
    });
}

export async function onDelete(id, type) {
    const response = await apiService.post(`${urlBase}DeleteObject/`, { id: id, objType: type })

    let layer = layerIndex.get(id);

    if (!layer) return;

    if (type == 'point') {
        pointsLayer
    }
    if (layer.feature && layer.feature.properties) {
        layer.feature.properties.id = newID; // Update layer w db id
    }

    layerIndex.set(newID, layer);// Update layerIndex
    layerIndex.delete(-1);
}


export const iconUtil = {
    createIcon: function (url) {
        return L.icon({
            iconUrl: url,
            iconSize: [32, 32],
            iconAnchor: [16, 32],
            popupAnchor: [0, -32],
            tooltipAnchor: [0, -32]
        });
    },
    updateIcon: function (props) {
        if (props.iconURL && props.iconURL.length > 0) {
            let newIcon = iconUtil.createIcon(props.iconURL);
            props.marker.setIcon(newIcon);
        }

        let tooltipContent = (props.title != undefined) ? `<b>${props.title}</b>` : "";
        props.marker._tooltip.setContent(tooltipContent);
    },
    removeIcon: function () {
        $(document).on('click', '.ui-draggable .popup-close', function () {
            let layer = layerIndex.get(-1);
            console.log('remove icon layer', layer);
            if (!layer) return;

            map.removeLayer(layer);
            layerIndex.delete(-1);
            curLayer.val.removeFrom(map);
            window.removeEventListener("removeIcon", iconUtil.removeIcon);
        });
    },
}


export const lineUtil = {

    editLine: function (id, name) {
        viewProps['title'] = name
        viewProps['data'] = { lineID: id };
        viewProps['url'] = urlBase + 'EditLine/'

        const latlngs = e.layer.getLatLngs();

        const coordString = latlngs.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `LINESTRING(${coordString})`;

        window.loadPopup(viewProps).then(() => {

            doNextThing();
        });
    },
    editLineSuccess: function (response) {
        console.log('response', response);
        window.closePopup();
    },
    updateDisplay: function (input, val) {
        let layer = curLayer.val;
        switch (input) {
            case 'color':
                layer.setStyle({ color: val });
                break;
            case 'width':
                layer.setStyle({ weight: val });
                break;
            case 'name':
                layer._tooltip.setContent(`<b>${val}</b>`);
                break;
            case 'dashArray':
                layer.setStyle({ dashArray: val });
                break;
            default:
                break;
        }
    }
}


export const drawUtil = {
    addObject: function (e, layerSet) {
        var l = e.layer;
        let geojson = l.toGeoJSON();

        let type = typeMap[e.layerType] ?? 'Polygon';

        viewProps['title'] = `New ${type}`;
        viewProps['url'] = urlBase + `AddNewObject/`;
        viewProps['data'] = { objType: type.toLowerCase() };
        layerProps["name"] = viewProps['title'];

        geojson.properties = layerProps.style;
        if (layerSet = circlesLayer) {
            geojson.properties.center = [l.getLatLng().lng, l.getLatLng().lat];
            geojson.properties.radius = l.getRadius(); // in meters
        }

        console.log('')
        layerSet.addData(geojson);

        curLayer.val = l;
        curLayer.val = drawUtil.getLastLayer(layerSet);

        layerIndex.set(-1, curLayer.val);

        if (curLayer.val) {
            curLayer.val.bindTooltip(layerProps.name, {
                permanent: true,
                direction: 'top'
            })
        }

        window.loadPopup(viewProps).then(() => {
            drawUtil.restoreStyle();
        });

        if (e.type == 'point') {
            window.addEventListener("removeIcon", iconUtil.removeIcon);
            window.dispatchEvent(new Event("removeIcon"));
        }
    },
    getLastLayer: function (layerSet) {
        let layers = layerSet.getLayers();
        return layers[layers.length - 1];
    },
    restoreStyle: function () {
        let layer = curLayer.val;
        let tooltip = layer.getTooltip();
        layer._origStyle = {
            icon: layer instanceof L.Marker ? layer.getIcon() : null,
            style: layer.setStyle ? { ...layer.options } : null,
            content: tooltip.getContent()
        };

        window.addEventListener("onCloseEdit", drawUtil.onCloseEdit);
        window.dispatchEvent(new Event("onCloseEdit"));
    },
    onCloseEdit: function () {
        $(document).on('click', '.ui-draggable .popup-close', function () {
            let l = curLayer.val;
            let origStyle = l._origStyle
            let tooltip = l.getTooltip();

            if (l instanceof L.Marker && origStyle.icon) {
                l.setIcon(origStyle.icon);
                l._tooltip.setContent()
            }
            else if (l.setStyle && origStyle.style) {
                l.setStyle(origStyle.style);
            }
            if (tooltip) {
                tooltip.setContent(origStyle.content);
            }
            delete l._originalStyle;

            window.removeEventListener("onCloseEdit", drawUtil.onCloseEdit);
        });
    }

}

