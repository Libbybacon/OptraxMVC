
import apiService from "./api.js";

export let OrigModel;
export let Changes = [];

var $form;

export const formUtil = {

    setListeners: function (formId) {
        $form = $(document).find($(formId));
        
        if ($.validator && $.validator.unobtrusive) {
            $.validator.unobtrusive.parse($form);
        }
        
        console.log('setListeners form', $form, 'action', $form.attr('action'));
        if ($form.attr('action').includes('Edit')) {
            formUtil.setModelChanges();
        }

        $(formId + ' .toggle-edit').on('click', function () {
            const model = $(this).parent('.model');
            model.find('.m-toggle').toggleClass('d-none');
        });
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
    submitForm: async function (formId) {
        $form = $(formId);
        console.log('formUtil submitForm $form', $form);
        const action = $form.attr('action')
        console.log('formUtil submitForm changes', Changes, 'action', action);

        if ($form.valid()) {

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
    showHideBtns: function (formId) {
        $form = $(formId);

        $(formId + ' button.toggle-edit').on('click', function () {
            console.log('formjs showHideBtns click')
            $(formId + ' button.form-btn').toggleClass('d-none');
            $('.m-toggle').toggleClass('d-none');
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


