import { formUtil } from '../utilities/form.js';
import { curLayer, onCreate, onDelete, iconUtil, lineUtil } from './mapUtility.js';


export function init() {
    formUtil.setListeners();
    setFormListeners();
}

function setFormListeners() {
    $('.icon-coll-name').on('click', function () {
        onSelectIconCollection($(this)); // change icon collection display
    });
    
    $('.point-info').on('input', function () {
        let props = { marker: curLayer.val, title: $('#Name').val(), desc: $('#Notes').val() }// Change point's tooltip content
        iconUtil.updateIcon(props);
    });
   
    $('.icon-div').on('click', function () {
        onSelectIcon($(this)); // Update point icon
    });

    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        event.preventDefault();
        onSubmitForm($('#modelForm')) // submit form
    });

    $('#clr-picker input').on('change', function () {
        lineUtil.updateDisplay('color', $('#Color').val());
    })
    $('#clr-color-area').on('click', function () {
        var color = $(this).find('#clr-color-marker').css('color')
        lineUtil.updateDisplay('color', color);
    })
    $('#clr-swatches').on('click', function () {

        setTimeout(() => {
            var color = $('#clr-color-marker').css('color')
            lineUtil.updateDisplay('color', color);
        }, 50);

    });
    $('#Pattern').on('change', function () {
        var pattern = $(this).val();
        if (pattern == 'solid') {
            $('#DashArray').val(null).change();
            $('#DashArray').attr('readonly', 'readonly');
        }
        else {
            $('#DashArray').val('5 5').change();
            $('#DashArray').removeAttr('readonly');
        }
        setTimeout(() => {
            lineUtil.updateDisplay('dashArray', $('#DashArray').val());
        }, 50);
    })
    $('#DashArray').on('input', function () {
        lineUtil.updateDisplay('dashArray', $(this).val())
    });
    $('#Width').on('change', function () {
        lineUtil.updateDisplay('width', $(this).val())
    });
    $('#Name').on('input', function () {
        lineUtil.updateDisplay('name', $('#Name').val());
    });

    $('.delete-btn').on('click', function(){
        let id = $(this).data('id');
        let type = $(this).data('type')
        onDelete(id, type);
    })
}

function onSelectIcon($icon) {
    $('.icon-div').removeClass('selected');
    $('#IconID').val($icon.data('iconid')).change();

    $icon.addClass('selected');

    let imgURL = $icon.find('img').attr('src');
    let props = { iconURL: imgURL, marker: curLayer.val, title: $('#Name').val(), desc: $('#Notes').val() }

    iconUtil.updateIcon(props);
}

function onSelectIconCollection($coll) {
    let collID = $coll.data('collid')

    $('.icon-coll-name').removeClass('selected');
    $(`.coll-name-${collID}`).addClass('selected');

    $('.preview-div').addClass('d-none');
    $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
}

async function onSubmitForm($form) {

    let response = await formUtil.submitForm();

    if (response.success) {

        onCreate(response);

        let objType = $form.data('obj');
        let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';
        window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
    }
    else {
        alert('Error! Invalid form...')
    }
}