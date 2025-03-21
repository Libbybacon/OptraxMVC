console.log("✅ mapObjectEdit.js is running");

import { formUtil } from '../formUtil.js';
import { updateMarker, curObject } from './map.js';
import { curObject } from './mapDataUtil.js';



    console.log('formUtil', formUtil);
    formUtil.setListeners();
    setFormListeners();


function setFormListeners() {

    // change icon collection display
    $('.icon-coll-name').on('click', function () {
        let collID = $(this).data('collid')

        $('.icon-coll-name').removeClass('selected');
        $(`.coll-name-${collID}`).addClass('selected');

        $('.preview-div').addClass('d-none');
        $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
    })

    // Change point's tooltip content
    $('.point-info').on('input', function () {
        let props = { marker: curObject, title: $('#Name').val(), desc: $('#Notes').val() }
        updateMarker(props);
    });

    // Update point icon
    $('.icon-div').on('click', function () {
        $('.icon-div').removeClass('selected');
        $('#IconID').val($(this).data('iconid')).change();

        $(this).addClass('selected');

        let imgURL = $(this).find('img').attr('src');
        let props = { iconURL: imgURL, marker: curObject, title: $('#Name').val(), desc: $('#Notes').val() }

        updateMarker(props);
    });

    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        event.preventDefault();
        submitForm($(`#modelForm`))
    });
}

function submitForm($form) {

    if (formUtil.checkFormValid()) {
        const response = await apiService.postWithJsonParams({ url: $form.attr("action"), data: $form.serialize() })

        if (response.success) {
            window.closePopup();

            let objType = $form.data('objType')
            let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';

            window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgDiv: $('.map-msg') });
        }
        else {
            alert('Error! Invalid form...')
        }
    }
}


//$.ajax({
//    url: $form.attr("action"),
//    type: $form.attr("method"),
//    data: $form.serialize(),
//    success: function (response) {
//        if (response.success) {
//            $.fn[response.function].call(response);
//            switch ($form.data('func')) {
//                case "addResource":
//                    addResourceSuccess(response);
//                    break;
//                case "editResource":
//                    setSelectDrops();
//                    setModelChanges();
//                    editResourceSuccess(response);
//                    break;
//                case "editCategory":
//                    setSelectDrops();
//                    setModelChanges();
//                    editCategorySuccess();
//                    break;
//                case "addPlants":
//                    addPlantsSuccess(response);
//                    break;
//                case "createLocation":
//                    createLocationSuccess(response);
//                default:
//                    closePopup();
//            }
//            showUpdateMessage({ css: 'success', msg: response.msg, msgdiv: msgdiv })
//        }
//        else {
//            console.log('fail')
//            showUpdateMessage({ css: 'error', msg: response.msg, msgdiv: msgdiv })
//        }
//    },
//    error: function () {
//        showUpdateMessage({ css: 'error', msg: 'An error occurred while saving.', msgdiv: msgdiv })
//    }
//});
//function createSuccess(response){
//    switch (response.objType) {
//        case "point":
//            curMarker.
//    }
//}