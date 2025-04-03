import { colorSwatches } from '../utilities/color.js';
import { getActive } from './mapState.js';

const formID = '#mapObjForm';
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
    $('#IconID').val($icon.data('iconid')).change();

    $icon.addClass('selected');

    let imgURL = $icon.find('img').attr('src');
    let props = { iconURL: imgURL, marker: getActive(), title: $(formID + ' #Name').val(), desc: $(formID + ' #Notes').val() }

    updateIcon(props);
}
export function selectIconColl($coll) {
    let collID = $coll.data('collid')

    $('.icon-coll-name').removeClass('selected');
    $(`.coll-name-${collID}`).addClass('selected');

    $('.preview-div').addClass('d-none');
    $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
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

    layer._origStyle = {
        icon: layer instanceof L.Marker ? layer.getIcon() : null,
        style: layer.setStyle ? { ...layer.options } : null,
        content: tooltip.getContent()
    };
}
export function restoreStyle(input, val) {
    //console.log('restoreStyle')
    let l = getActive();
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
}

export function setStyleListeners(formID) {
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
    $(formID + ' #Pattern').on('change', function () {
        var pattern = $(this).val();
        if (pattern == 'solid') {
            $(formID + ' #DashArray').val(0).change();
            $(formID + ' #DashArray').attr('readonly', 'readonly');
        }
        else {
            $(formID + ' #DashArray').val('5 5').change();
            $(formID + ' #DashArray').removeAttr('readonly');
        }
        setTimeout(() => {
            updateStyle('dashArray', $(formID + ' #DashArray').val());
        }, 50);
    })
    $(formID + ' #Name').on('input', function () {
        updateStyle('name', $(this).val());
    });
    $(formID + ' #DashArray').on('input', function () {
        updateStyle('dashArray', $(this).val())
    });
    $(formID + ' #Weight').on('change', function () {
        updateStyle('weight', $(this).val())
    });
}
