import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import { getMap, getActive, setActive, deleteActive, setIndex, deleteIndex } from './mapState.js';
import * as _style from './objStyleUtil.js';
import { getLayerset } from './layerManager.js';

let map = getMap();

const urlBase = '/Grow/Map/';

const typeMap = {
    marker: 'Point',
    polyline: 'Line',
    circle: 'Circle'
};

export const layerProps = {
    id: -1,
    weight: 3,
    dashArray: '5 5',
    color: '#1d52d7',
    fillColor: '#1d52d782',
    iconPath: 'https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE'
};

// Create
export async function addObject(l, type) {
    const objType = typeMap[e.type] ?? 'Polygon';
    const layerSet = getLayerset(type);

    console.log('layerset', layerSet, 'layer', l, 'type', type);

    layerProps["name"] = 'New ' + objType;

    if (type === 'circle') {
        addCircle(l, layerSet);
    }
    else {
        const geojson = l.toGeoJSON();
        geojson.properties = layerProps;
        layerSet.addData(geojson);
    }

    setActive(getLastLayer(layerSet));

    setIndex(-1, getActive());

    const props = {
        id: -1,
        type: type,
        data: { objType: type },
        url: `${urlBase}AddNewObject/`,
        center: (type == 'Point' || type == 'Circle') ? l.getLatLng() : l.getBounds().getCenter(),
    }

    _style.saveStyle();

    await showEditPopup(props).then(() => {
        mapFormUtil.setFormListeners('#mapObjForm');

        updateHiddenFields(type, layerProps);
        map.on('popupclose', deleteActive);
    });
}

export function addCircle(l, layerSet) {
    let latlng = l.getLatLng();
    layerProps["radius"] = l.getRadius();
    layerProps['latlng'] = latlng;

    const feature = {
        type: "Feature",
        properties: layerProps,
        geometry: {
            type: "Point",
            coordinates: [latlng.lng, latlng.lat]
        },
    };
    layerSet.addData(feature);
}


export const getLastLayer = layerSet => {
    let layers = layerSet.getLayers();
    return layers[layers.length - 1];
}

export async function showEditPopup(props) {
    map = getMap();

    const response = await apiService.get(props.url, props.data);

    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading' + props.type, msgdiv: $('.map-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    $('.title-control').hide(); // Hide map title so it doesn't overlap editor window

    const view = await response.data;

    const $editDiv = $('<div/>').addClass('mapObj-popup').html(view);

    L.DomEvent.disableClickPropagation($editDiv[0]);
    L.DomEvent.disableScrollPropagation($editDiv[0]);

    L.popup({ offset: L.point(0, -30) }).setLatLng(props.center).setContent($editDiv[0]).openOn(map);

    $($editDiv).find('.obj-color.color-picker').spectrum(_style.setColorPicker('color'));
    $($editDiv).find('.obj-fill.color-picker').spectrum(_style.setColorPicker('fillColor'));
}

export function updateHiddenFields(type, props) {
    let layer = getActive();
    const mapId = $("#mapForm").find("#Id").val();

    $('.obj-mapId').val(mapId)
    //console.log('updateHiddenFields props', props, 'layer', layer);

    if (type.toLowerCase() == 'point') {
        const latlng = layer.getLatLng();
        $('.obj-lat').val(latlng.lat);
        $('.obj-lng').val(latlng.lng);
    }

    else if (type.toLowerCase() == 'circle') {
        $('.obj-lat').val(props.center.lat);
        $('.obj-lng').val(props.center.lng);
        $('.obj-radius').val(layer.feature.properties.radius);
    }

    else if (type.toLowerCase() === 'line') {
        const latlngs = layer.getLatLngs();
        const coordString = latlngs.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `LINESTRING(${coordString})`;

        $('.obj-geomWKT').val(wkt);
    }

    else if (type.toLowerCase() == 'polygon') {
        const latlngs = layer.getLatLngs();
        const or = latlngs[0] ?? latlngs; // outer ring
        const closed = [...or];

        // close the ring
        if (or.length > 0 && (or[0].lat !== or[or.length - 1].lat || or[0].lng !== or[or.length - 1].lng)) {
            closed.push(or[0]);
        }

        const coordString = closed.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `POLYGON((${coordString}))`;

        $('.obj-geomWKT').val(wkt);
    }
}

// Edit
export async function loadEdit(id, type, center) {

    let props = {
        type: type,
        center: center,
        data: { id: id, objType: type },
        url: `${urlBase}LoadEdit/`
    }

    _style.saveStyle(); // Store current style in case user cancels update

    await showEditPopup(props).then(() => {
        mapFormUtil.setFormListeners('#mapObjForm');
        updateHiddenFields(type, props);
        map.on('popupclose', _style.restoreStyle);
    });
}

// Delete
export async function onDelete(id, type) {
    const response = await apiService.postForm(`${urlBase}DeleteObject/`, { id: id, objType: type })
    console.log('onDelete response', response);

    if (response.success == true) {
        console.log('onDelete curLayer', getActive());
        deleteActive();
    }
}

export const mapFormUtil = {

    setFormListeners: function (formId) {
        $(formId).on('submit', function (event) {
            event.preventDefault();
            mapFormUtil.onSubmitForm(formId) // submit form
        });

        $(document).off('click', formId + ' .btn-red').on('click', formId + ' .btn-red', function () {
            let id = $(formId).data('id');
            let type = $(formId).data('obj')
            onDelete(id, type);
        })

        formUtil.setListeners(formId);
        if (formId == '#mapObjForm') {
            _style.setStyleListeners('#mapObjForm');
        }
    },

    onSubmitForm: async function (formId) {
        let $form = $(formId);
        const isCreate = $form.attr('action').includes('Create')

        let response = await formUtil.submitForm(formId);
        console.log('mapUtil onSubmitForm response', response);

        if (response && response.success) {

            // Update map title if user edited name
            if (formId == '#mapForm') {
                const newName = $('#mapForm #Name').val();

                $('.map-info').toggleClass('d-none');
                $('.map-title').text(newName);
            }
            else {
                map.off('popupclose', _style.restoreStyle); // Cancel event listeners to reset/delete
                map.off('popupclose', deleteActive);
                map.closePopup();

                let objType = $form.data('obj');
                let action = isCreate ? 'Created' : 'Updated';

                if (isCreate && response.data) {
                    mapFormUtil.updateId(response.data, $form.data('obj'));
                }

                window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
            }
        }
        else {
            alert('Error! ' + response.error);
        }
    },

    updateId(data, type) {
        let layer = getActive();
        let id = data.properties.id;

        layer.feature.properties.id = id;
        console.log('updateId layer', layer, 'id', id, 'data', data)
        deleteIndex(-1)
        setIndex(id, layer);

    }
}

