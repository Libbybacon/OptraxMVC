import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import { getMap, getActive, setActive, deleteActive, setIndex, deleteIndex } from './mapState.js';
import * as _style from './objStyleUtil.js'; 


let map = getMap();

const urlBase = '/Grow/Map/';

const typeMap = {
    marker: 'Point',
    polyline: 'Line',
    circle: 'Circle'
};

const layerProps = {
    id: -1,
    weight: 3,
    dashArray: '5 5',
    color: '#1d52d7',
    fillColor: '#1d52d782',
    iconPath: 'https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE'
};

// Create
export async function addObject(e, layerSet) {
    var l = e.layer;
    let type = typeMap[e.layerType] ?? 'Polygon';

    console.log('layerset', layerSet, 'layer', l, 'type', type);

    layerProps["name"] = 'New ' + type;

    if (type === 'Circle') {
        let latlng = l.getLatLng();
        layerProps["radius"] = l.getRadius();
        layerProps['latlng'] = latlng;
        console.log('addObject circle props', layerProps);
        const feature = {
            type: "Feature",
            properties: layerProps,
            geometry: {
                type: "Point",
                coordinates: [latlng.lng, latlng.lat]
            },
        };
        console.log('addObject feature', feature);
        layerSet.addData(feature);
    }
    else {
        let geojson = l.toGeoJSON();
        geojson.properties = layerProps;
        layerSet.addData(geojson);
    }
    console.log('layer', l)

    setActive(getLastLayer(layerSet));

    setIndex(-1, getActive());

    let props = {
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

export const getLastLayer = layerSet => {
    let layers = layerSet.getLayers();
    return layers[layers.length - 1];
}

export async function showEditPopup(props) {
    map = getMap();
    console.log('showEditPopup props', props, 'map', map);

    const response = await apiService.get(props.url, props.data);

    console.log('showEditPopup response', response);
    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading' + props.type, msgdiv: $('.map-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    $('.title-control').hide();

    const view = await response.data;

    const $editDiv = $('<div/>').addClass('mapObj-popup').html(view);

    L.DomEvent.disableClickPropagation($editDiv[0]);
    L.DomEvent.disableScrollPropagation($editDiv[0]);

    L.popup({ offset: L.point(0, -30) }).setLatLng(props.center).setContent($editDiv[0]).openOn(map);

    $($editDiv).find('#Color.color-picker').spectrum(_style.setColorPicker('color'));
    $($editDiv).find('#FillColor.color-picker').spectrum(_style.setColorPicker('fillColor'));
}

export function updateHiddenFields(type, props) {
    let layer = getActive();
    const mapID = $("#mapForm").find("#ID").val();

    $('#MapID').val(mapID)

    if (type.toLowerCase() == 'point') {
        const latlng = layer.getLatLng();
        $('#Latitude').val(latlng.lat);
        $('#Longitude').val(latlng.lng);
    }

    else if (type.toLowerCase() == 'circle') {
        $('#Latitude').val(props.latlng.lat);
        $('#Longitude').val(props.latlng.lng);
        $('#Radius').val(props.radius);
    }

    else if (type.toLowerCase() === 'line') {
        const latlngs = layer.getLatLngs();
        const coordString = latlngs.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `LINESTRING(${coordString})`;

        $('#GeometryWKT').val(wkt);
    }

    else if (type.toLowerCase() == 'polygon') {
        const latlngs = layer.getLatLngs();
        const or = latlngs[0] ?? latlngs; // outer ring
        const closed = [...or];

        if (or.length > 0 && (or[0].lat !== or[or.length - 1].lat || or[0].lng !== or[or.length - 1].lng)) {
            closed.push(or[0]); // close the ring
        }

        const coordString = closed.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `POLYGON((${coordString}))`;
        $('#GeometryWKT').val(wkt);
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

    _style.saveStyle();

    await showEditPopup(props).then(() => {
        mapFormUtil.setFormListeners('#mapObjForm');

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
    setFormListeners: function (formID) {
        console.log('mapFormUtil setFormListeners formID', formID);

        $(formID).on('submit', function (event) {
            event.preventDefault();
            mapFormUtil.onSubmitForm(formID) // submit form
        });

        $(document).off('click', formID + ' .btn-red').on('click', formID + ' .btn-red', function () {
            let id = $(formID).data('id');
            let type = $(formID).data('obj')
            onDelete(id, type);
        })

        formUtil.setListeners(formID);
        if (formID == '#mapObjForm') {
            _style.setStyleListeners('#mapObjForm');
        }
    },
    onSubmitForm: async function (formID) {
        let $form = $(formID);

        console.log('mapUtil onSubmitForm $form', $form);

        const isCreate = $form.attr('action').includes('Create')

        let response = await formUtil.submitForm(formID);
        console.log('mapUtil onSubmitForm response', response);

        if (response && response.success) {

            if (formID == '#mapForm') {
                const newName = $('#mapForm #Name').val();

                $('.map-info').toggleClass('d-none');
                $('.map-title').text(newName);
            }
            else {
                map.off('popupclose', _style.restoreStyle);
                map.off('popupclose', deleteActive);
                map.closePopup();

                let objType = $form.data('obj');
                let action = isCreate ? 'Created' : 'Updated';

                if (isCreate && response.data) {
                    mapFormUtil.updateID(response.data, $form.data('obj'));
                }

                window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
            }
        }
        else {
            alert('Error! ' + response.error);
        }
    },
    updateID(data, type) {
        let layer = getActive();
        let id = data.properties.id;

        layer.feature.properties.id = id;
        console.log('updateID layer', layer, 'id', id, 'data', data)
        deleteIndex(-1)
        setIndex(id, layer);

    }
}

