import { colorSwatches } from '../utilities/color.js';
import { getActive } from './mapState.js';

const formId = '#mapObjForm';
export function createIcon(url) {
    return L.icon({
        iconUrl: url,
        iconSize: [32, 32],
        iconAnchor: [16, 32],
        popupAnchor: [0, -32],
        tooltipAnchor: [0, -32]
    });
}
export function updateIcon(props) {
    if (props.iconURL && props.iconURL.length > 0) {
        let newIcon = createIcon(props.iconURL);
        props.marker.setIcon(newIcon);
    }

    let tooltipContent = (props.title != undefined) ? props.title : "";
    props.marker._tooltip.setContent(tooltipContent);
}

export function selectIcon($icon) {
    $('.icon-div').removeClass('selected');
    $('.obj-iconId').val($icon.data('iconid')).trigger('change');

    $icon.addClass('selected');

    let imgURL = $icon.find('img').attr('src');
    let props = { iconURL: imgURL, marker: getActive(), title: $('.obj-name').val(), desc: $('.obj-details').val() }

    updateIcon(props);
}
export function selectIconColl($coll) {
    let collId = $coll.data('collid')

    $('.icon-coll-name').removeClass('selected');
    $(`.coll-name-${collId}`).addClass('selected');

    $('.preview-div').addClass('d-none');
    $(`.preview-div.preview-coll-${collId}`).removeClass('d-none');
}

export function setColorPicker(attr) {
    return {
        type: "component",
        showInput: true,
        showPalette: true,
        showButtons: false,
        preferredFormat: "rgb",
        togglePaletteOnly: true,
        showSelectionPalette: true,
        selectionPalette: [colorSwatches],
        change: function (color) { updateStyle(attr, color.toRgbString()); },
        move: function (color) { updateStyle(attr, color.toRgbString()); },
        show: function (color) { updateStyle(attr, color.toRgbString()); },
    }
}

export function updateStyle(input, val) {
    let layer = getActive();
    //console.log('updateStyle layer', layer, 'input', input, 'val', val);
    switch (input) {
        case 'name':
            layer._tooltip.setContent(val);
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
}

export function saveStyle () {
    let layer = getActive();
    let tooltip = layer.getTooltip();
    //console.log('saveStyle');
    layer._origStyle = {
        icon: layer instanceof L.Marker ? layer.getIcon() : null,
        style: layer.setStyle ? { ...layer.options } : null,
        content: tooltip?.getContent(),
        geometry: getGeometrySnapshot(layer)
    };
}

export function restoreStyle(input, val) {

    const l = getActive();
    const orig = l._origStyle
    const tooltip = l.getTooltip();

    if (l instanceof L.Marker && orig.icon) {
        l.setIcon(orig.icon);
        l._tooltip.setContent()
    }
    else if (l.setStyle && orig.style) {
        l.setStyle(orig.style);
    }
    if (tooltip) {
        tooltip.setContent(orig.content);
    }

    restoreGeometry(l, orig.geometry);

    delete l._originalStyle;
}

function getGeometrySnapshot(layer) {
    if (layer instanceof L.Marker) {
        return { latlng: layer.getLatLng() };
    }

    if (layer instanceof L.Circle) {
        return {
            latlng: layer.getLatLng(),
            radius: layer.getRadius()
        };
    }

    if (layer.getLatLngs) {
        return { latlngs: layer.getLatLngs() };
    }
    return null;
}

function restoreGeometry(layer, geom) {
    if (!geom) return;

    if (layer instanceof L.Marker && geom.latlng) {
        layer.setLatLng(geom.latlng);
    }

    if (layer instanceof L.Circle && geom.latlng && geom.radius != null) {
        layer.setLatLng(geom.latlng);
        layer.setRadius(geom.radius);
    }

    if (layer.setLatLngs && geom.latlngs) {
        layer.setLatLngs(geom.latlngs);
    }
}

export function setStyleListeners(formId) {
    //console.log('setStyleListeners');
    // Points
    $('.icon-coll-name').on('click', function () {
        selectIconColl($(this)); // change icon collection display
    });
    $('.icon-div').on('click', function () {
        selectIcon($(this)); // Update point icon
    });
    $('.point-info').on('input', function () {
        let props = { marker: getActive(), title: $('#Name').val() }// Change point's tooltip content
        updateIcon(props);
    });

    // Not Points
    $('.obj-pattern').on('change', function () {
        var pattern = $(this).val();
        var $dash = $('.obj-dash');

        if (pattern == 'solid') {
            $dash.val(0).trigger('change');
            $dash.attr('readonly', 'readonly');
        }
        else {
            $dash.val('5 5').trigger('change');
            $dash.removeAttr('readonly');
        }
        setTimeout(() => {
            updateStyle('dashArray', $dash.val());
        }, 50);
    })

    $('.obj-name').on('input', function () {
        updateStyle('name', $(this).val());
    });
    $('.obj-dash').on('input', function () {
        updateStyle('dashArray', $(this).val())
    });
    $('.obj-weight').on('change', function () {
        updateStyle('weight', $(this).val())
    });
}
