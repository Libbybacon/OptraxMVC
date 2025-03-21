import { formUtil } from '../utilities/form.js';
import { curObject, iconUtil, lineUtil } from './mapUtility.js';


export function init() {
    formUtil.setListeners();
    setFormListeners();
}

function setFormListeners() {
    $('.icon-coll-name').on('click', function () {
        onSelectIconCollection(); // change icon collection display
    });
    
    $('.point-info').on('input', function () {
        let props = { marker: curObject, title: $('#Name').val(), desc: $('#Notes').val() }// Change point's tooltip content
        iconUtil.updateMarker(props);
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
    $('#clr-picker button').on('click', function () {
        console.log('btn color', $(this).val() )
        lineUtil.updateDisplay('color', $(this).val());
    })
    //$('#clr-color-area').on('click', function () {
    //    lineUtil.updateDisplay('color', $('#Color').val());
    //})
    //$('#clr-alpha-slider').on('change', function () {
    //    console.log('color', $('#Color').val());
    //    lineUtil.updateDisplay('color', $('#Color').val());
    //});
    //$('#clr-color-value').on('change', function () {
    //    console.log('color', $('#Color').val());
    //    lineUtil.updateDisplay('color', $('#Color').val());
    //})
    $('#Color').on('change', function () {
        lineUtil.updateDisplay('color', $(this).val());
    })
    $('#Width').on('change', function () {
        console.log('change width', $(this).val());
        lineUtil.updateDisplay('width', $(this).val())
    });
    $('#Name').on('input', function () {
        console.log('change Name');
        lineUtil.updateDisplay('name', $('#Notes').val());
    });

}

function onSelectIcon($icon) {
    $('.icon-div').removeClass('selected');
    $('#IconID').val($icon.data('iconid')).change();

    $icon.addClass('selected');

    let imgURL = $icon.find('img').attr('src');
    let props = { iconURL: imgURL, marker: curObject, title: $('#Name').val(), desc: $('#Notes').val() }

    iconUtil.updateMarker(props);
}

function onSelectIconCollection() {
    let collID = $(this).data('collid')

    $('.icon-coll-name').removeClass('selected');
    $(`.coll-name-${collID}`).addClass('selected');

    $('.preview-div').addClass('d-none');
    $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
}

async function onSubmitForm($form) {

    let response = await formUtil.submitForm();

    if (response.success) {
        window.closePopup();

        let objType = $form.data('obj');
        console.log($form)
        let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';

        window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
    }
    else {
        alert('Error! Invalid form...')
    }
}