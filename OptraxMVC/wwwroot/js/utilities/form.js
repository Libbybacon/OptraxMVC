
import apiService from "./api.js";

export let OrigModel;
export let Changes = [];

var $form;

export const formUtil = {
    setListeners: function (formID) {
        $form = $(document).find($(formID));
        if ($.validator && $.validator.unobtrusive) {
            $.validator.unobtrusive.parse($form);
        }
        console.log('setListeners form', $form, 'action', $form.attr('action'));
        if ($form.attr('action').includes('Edit')) {
            formUtil.setModelChanges();
        }
    },
    setModelChanges: function () {
        Changes = [];
        $('#changes').val(null);

        OrigModel = formUtil.arrayToModel($form.serializeArray());

        $('.attr').off('change').on('change', function () {
            let attrName = $(this).attr('Name');

            if ($(this).val() != OrigModel[attrName]) {
                Changes.push(attrName); // if updated value != original value, add attribute name to list of changes
            }
            else if (Changes.length > 0) {
                Changes = Changes.filter(function (c) { return c != attrName }); // if new value == orig value, remove attr from changes if it's in there.
            }

            let changed = Changes.length > 0;

            $('#changes').val(changed > 0 ? Changes.toString() : null);
        });
    },
    submitForm: async function (formID) {
        $form = $(formID);

        const action = $form.attr('action')
        console.log('formUtil submitForm changes', Changes, 'action', action);

        let proceed = action.includes('Create') || Changes.length > 0;
        console.log('formUtil submitForm', proceed);

        if ($form.valid() && proceed) {

            return await apiService.postForm(action, $form.serialize())
        }
        else {
            if (action.includes('Create') && !$form.valid()) {
                return { success: false, error: 'Invalid form'}
            }
            else if (Changes.length == 0) {
                return {success: true}
            }
            
        }
    },
    showHideBtns: function ($form) {
        $form.on('click', '.edit-btn', function () {
            $form.find('.view').addClass('d-none');
            $form.find('.show-ed').removeClass('d-none');
            $form.find('.attr').removeClass('d-none');
            $form.find('.cancel-btn').removeClass('d-none');
        });
        $form.on('click', '.cancel-btn', function () {
            $form.find('.view').removeClass('d-none');
            $form.find('.show-ed').addClass('d-none');
            $form.find('.attr').addClass('d-none');
            $form.find('.cancel-btn').addClass('d-none');
        });
    },
    arrayToModel: function (arr) {
        var model = {};

        for (var i = 0; i < arr.length; i++) {

            model[arr[i]['name']] = arr[i]['value'];
        }
        return model;
    }
}

//function submitForm() {

//    let $form = $(`#modelForm`);
//    let msgdiv = $(`#${$form.data('msgdiv')}`);
//    let proceed = $form.attr('action').includes('Create') || Changes.length > 0;

//    if ($form.valid() && proceed) {

//        return await apiService.postWithJsonParams({ url: $form.attr("action"), data: $form.serialize() })

//        //$.ajax({
//        //    url: $form.attr("action"),
//        //    type: $form.attr("method"),
//        //    data: $form.serialize(),
//        //    success: function (response) {
//        //        if (response.success) {
//        //            $.fn[response.function].call(response);
//        //            switch ($form.data('func')) {
//        //                case "addResource":
//        //                    addResourceSuccess(response);
//        //                    break;
//        //                case "editResource":
//        //                    setSelectDrops();
//        //                    setModelChanges();
//        //                    editResourceSuccess(response);
//        //                    break;
//        //                case "editCategory":
//        //                    setSelectDrops();
//        //                    setModelChanges();
//        //                    editCategorySuccess();
//        //                    break;
//        //                case "addPlants":
//        //                    addPlantsSuccess(response);
//        //                    break;
//        //                case "createLocation":
//        //                    createLocationSuccess(response);
//        //                default:
//        //                    closePopup();
//        //            }
//        //            showUpdateMessage({ css: 'success', msg: response.msg, msgdiv: msgdiv })
//        //        }
//        //        else {
//        //            console.log('fail')
//        //            showUpdateMessage({ css: 'error', msg: response.msg, msgdiv: msgdiv })
//        //        }
//        //    },
//        //    error: function () {
//        //        showUpdateMessage({ css: 'error', msg: 'An error occurred while saving.', msgdiv: msgdiv })
//        //    }
//        //});
//    }
//    else {
//        console.log('Error! Invalid form...')
//    }
//}

