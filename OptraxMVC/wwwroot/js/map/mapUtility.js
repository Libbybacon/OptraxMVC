import { map, layerIndex } from './map.js';
import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';

export var curLayer = { val: {} };

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
let colorSwatches = [
    '#FF3333',
    '#EF7A1A',
    '#F9C04D',
    '#328532',
    '#1D52D7',
    '#9E6DD9',
    '#DA6565',
    '#F9AA8A',
    '#F8DEA0',
    '#97CA91',
    '#9BB2E3',
    '#C4ADCA'
]
export async function loadObjects(mapLayer, layerType) {
    try {
        console.log('mapLayer', mapLayer, 'layerType', layerType);
        const response = await apiService.get('/Grow/Map/GetObjects', { objType: layerType });
        console.log('response', response);

        if (response.success === false) { throw new Error(response.error || "Failed to load points"); }

        mapLayer.addData(response.data);
    }
    catch (error) {
        console.error("Error loading points:", error);
    }
}

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

    curLayer.val = styleUtil.getLastLayer(layerSet);

    layerIndex.set(-1, curLayer.val);

    let props = {
        id: -1,
        type: type,
        data: { objType: type },
        url: `${urlBase}AddNewObject/`,
        center: (type == 'Point' || type == 'Circle') ? l.getLatLng() : l.getBounds().getCenter(),
    }

    styleUtil.saveStyle();

    await showEditPopup(props).then(() => {
        mapFormUtil.setFormListeners();

        updateHiddenFields(type, layerProps);
        map.on('popupclose', styleUtil.removeLayer);
    });
}

async function showEditPopup(props) {
    console.log('showEditPopup props', props);

    const response = await apiService.get(props.url, props.data);

    console.log('showEditPopup response', response);
    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading' + props.type, msgdiv: $('.map-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    const view = await response.data;
    console.log('showEditPopup response', view);

    const $editDiv = $('<div/>').addClass('edit-popup').html(view);
    L.DomEvent.disableClickPropagation($editDiv[0]);
    L.DomEvent.disableScrollPropagation($editDiv[0]);

    L.popup({ offset: L.point(0, -30) }).setLatLng(props.center).setContent($editDiv[0]).openOn(map);

    $($editDiv).find('#Color.color-picker').spectrum(mapFormUtil.setColorPicker($editDiv, 'color'));
    $($editDiv).find('#FillColor.color-picker').spectrum(mapFormUtil.setColorPicker($editDiv, 'fillColor'));
    //mapFormUtil.setColorPicker($editDiv);
}


export function updateHiddenFields(type, props) {
    let layer = curLayer.val;

    if (type == 'Point') {
        const latlng = layer.getLatLng();
        $('#Latitude').val(latlng.lat);
        $('#Longitude').val(latlng.lng);
    }

    if (type === 'Line') {
        const latlngs = layer.getLatLngs();
        const coordString = latlngs.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `LINESTRING(${coordString})`;

        $('#LineGeometryWKT').val(wkt);
    }

    else if (type == 'Circle') {
        $('#Latitude').val(props.latlng.lat);
        $('#Longitude').val(props.latlng.lng);
        $('#Radius').val(props.radius);
    }

    else if (type == 'Polygon') {
        const latlngs = layer.getLatLngs();
        const or = latlngs[0] ?? latlngs; // outer ring
        const closed = [...or];

        if (or.length > 0 && (or[0].lat !== or[or.length - 1].lat || or[0].lng !== or[or.length - 1].lng)) {
            closed.push(or[0]); // close the ring
        }

        const coordString = closed.map(p => `${p.lng} ${p.lat}`).join(', ');
        const wkt = `POLYGON((${coordString}))`;
        $('#PolyGeometryWKT').val(wkt);
    }
}


// Edit
export async function getEdit(id, type, center) {

    let props = {
        type: type,
        center: center,
        data: { id: id, objType: type },
        url: `${urlBase}LoadEdit/`
    }

    styleUtil.saveStyle();

    await showEditPopup(props).then(() => {
        mapFormUtil.setFormListeners();

        map.on('popupclose', styleUtil.restoreStyle);
    });
}


// Delete
export async function onDelete(id, type) {
    const response = await apiService.postForm(`${urlBase}DeleteObject/`, { id: id, objType: type })

    if (response.success == true) {
        curLayer.val.remove();
        map.closePopup();
        //window.showMessage({ msg: `${type} Deleted!`, css: 'success', msgdiv: $('.map-msg') });
    }
    else {
        //window.showMessage({ msg: `Error deleting ${type}!`, css: 'error', msgdiv: $('.map-msg') });
    }
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
}


export const styleUtil = {
    getLastLayer: function (layerSet) {
        let layers = layerSet.getLayers();
        return layers[layers.length - 1];
    },
    saveStyle: function () {
        let layer = curLayer.val;
        let tooltip = layer.getTooltip();

        layer._origStyle = {
            icon: layer instanceof L.Marker ? layer.getIcon() : null,
            style: layer.setStyle ? { ...layer.options } : null,
            content: tooltip.getContent()
        };
    },
    updateStyle: function (input, val) {
        let layer = curLayer.val;
        switch (input) {
            case 'name':
                layer._tooltip.setContent(`<b>${val}</b>`);
                break;
            case 'color':
                layer.setStyle({ color: val });
                break;
            case 'fillColor':
                layer.setStyle({ fillColor: val })
                break;
            case 'weight':
                layer.setStyle({ weight: val });
                break;
            case 'dashArray':
                layer.setStyle({ dashArray: val });
                break;
            default:
                break;
        }
    },
    restoreStyle: function () {
        console.log('restoreStyle')
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
    },

    onSelectIcon: function ($icon) {
        $('.icon-div').removeClass('selected');
        $('#IconID').val($icon.data('iconid')).change();

        $icon.addClass('selected');

        let imgURL = $icon.find('img').attr('src');
        let props = { iconURL: imgURL, marker: curLayer.val, title: $('#Name').val(), desc: $('#Notes').val() }

        iconUtil.updateIcon(props);
    },
    onSelectIconCollection: function ($coll) {
        let collID = $coll.data('collid')

        $('.icon-coll-name').removeClass('selected');
        $(`.coll-name-${collID}`).addClass('selected');

        $('.preview-div').addClass('d-none');
        $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
    },
    removeLayer: function () {
        let layer = curLayer.val;
        if (!layer) return;
        layer.remove();
    },

}

export const mapFormUtil = {
    setFormListeners: function () {
        $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
            event.preventDefault();
            mapFormUtil.onSubmitForm($('#modelForm')) // submit form
        });

        $(document).off('click', '.delete-btn').on('click', '.delete-btn', function () {
            let id = $(this).data('id');
            let type = $(this).data('type')
            onDelete(id, type);
        })
        formUtil.setListeners();
        mapFormUtil.setStyleListeners();
    },
    setColorPicker(div, attr) {
        return {
            type: "component",
            showPalette: true,
            showButtons: false,
            togglePaletteOnly: true,
            showSelectionPalette: true,
            selectionPalette: [colorSwatches],
            showInput: true,
            //appendTo: div,
            change: function (color) { color.toHexString(); styleUtil.updateStyle(attr, color) },
            move: function (color) { color.toHexString(); styleUtil.updateStyle(attr, color) },
            show: function (color) { color.toHexString(); styleUtil.updateStyle(attr, color) },
        }
    },
    setStyleListeners: function () {
        // Points
        $('.icon-coll-name').on('click', function () {
            styleUtil.onSelectIconCollection($(this)); // change icon collection display
        });
        $('.icon-div').on('click', function () {
            styleUtil.onSelectIcon($(this)); // Update point icon
        });
        $('.point-info').on('input', function () {
            let props = { marker: curLayer.val, title: $('#Name').val() }// Change point's tooltip content
            iconUtil.updateIcon(props);
        });

        // Not Points
        $('#Pattern').on('change', function () {
            var pattern = $(this).val();
            if (pattern == 'solid') {
                $('#DashArray').val(0).change();
                $('#DashArray').attr('readonly', 'readonly');
            }
            else {
                $('#DashArray').val('5 5').change();
                $('#DashArray').removeAttr('readonly');
            }
            setTimeout(() => {
                styleUtil.updateStyle('dashArray', $('#DashArray').val());
            }, 50);
        })
        $('#Name').on('input', function () {
            styleUtil.updateStyle('name', $('#Name').val());
        });
        $('#DashArray').on('input', function () {
            styleUtil.updateStyle('dashArray', $(this).val())
        });
        $('#Weight').on('change', function () {
            styleUtil.updateStyle('weight', $(this).val())
        });

    },
    onSubmitForm: async function ($form) {

        let response = await formUtil.submitForm();
        console.log('onSubmitForm response', response);
        if (response && response.success) {

            map.off('popupclose', styleUtil.restoreStyle);
            map.off('popupclose', styleUtil.removeLayer);
            map.closePopup();

            let objType = $form.data('obj');
            let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';
            window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
        }
        else {
            alert('Error! Invalid form...')
        }
    }
}

