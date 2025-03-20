﻿
var OrigModel;
var Changes = [];

$(document).ready(function () {

    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse($(`#modelForm`));
    }

    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        event.preventDefault();
        submitForm($(`#modelForm`))
    });

    switch ($('#modelForm').data('modelname')) {
        case 'cat':
            setCategoryListeners();
            break;
        case 'plant':
            setPlantListeners();
            break;
        case 'point':
            setMapListeners();
            break;
        default:
            break;
    }

    if ($('#modelForm').data('func').includes('edit')) {
        setModelChanges();
    }
    setSelectDrops();
});

function setSelectDrops() {

    $('.select2').select2({
        theme: "bootstrap-5", // Ensures it follows Bootstrap styles
        width: "100%"
    });

    $('.select2').on("change", function () {
        let val = $(this).val();
        if (!val || val === "") {
            $(this).val(null).trigger("change.select2");
        }
        if ($.validator && $.validator.unobtrusive) {
            setTimeout(() => { $(this).valid(); }, 10);
        }
    });
}

function setModelChanges() {
    Changes = [];
    $('#changes').val(null);

    OrigModel = arrayToModel($('#modelForm').serializeArray());

    $(document).find('.update-btn').addClass('d-none');

    $('.attr').off('change').on('change', function () {

        let attrName = $(this).attr('Name');

        if ($(this).val() != OrigModel[attrName])
        {
            Changes.push(attrName); // if updated value != original value, add attribute name to list of changes
        }
        else if (Changes.length > 0)
        {
            Changes = Changes.filter(function (c) { return c != attrName }); // if new value == orig value, remove attr from changes if it's in there.
        }

        let changed = Changes.length > 0;

        $('#changes').val(changed > 0 ? Changes.toString() : null);

        changed > 0 ? $('.update-btn').removeClass('d-none') : $('.update-btn').addClass('d-none');
    });
}

function submitForm() {

    let $form = $(`#modelForm`);
    let msgdiv = $(`#${$form.data('msgdiv')}`);
    let proceed = $form.attr('action').includes('Create') || Changes.length > 0;

    if ($form.valid() && proceed) {

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            success: function (response) {
                if (response.success) {
                    $.fn[response.function].call(response);
                    switch ($form.data('func')) {
                        case "addResource":
                            addResourceSuccess(response);
                            break;
                        case "editResource":
                            setSelectDrops();
                            setModelChanges();
                            editResourceSuccess(response);
                            break;
                        case "editCategory":
                            setSelectDrops();
                            setModelChanges();
                            editCategorySuccess();
                            break;
                        case "addPlants":
                            addPlantsSuccess(response);
                            break;
                        case "createLocation":
                            createLocationSuccess(response);
                        default:
                            closePopup();
                    }
                    showUpdateMessage({ css: 'success', msg: response.msg, msgdiv: msgdiv })
                }
                else {
                    console.log('fail')
                    showUpdateMessage({ css: 'error', msg: response.msg, msgdiv: msgdiv })
                }
            },
            error: function () {
                showUpdateMessage({ css: 'error', msg: 'An error occurred while saving.', msgdiv: msgdiv })
            }
        });
    }
    else {
        console.log('Error! Invalid form...')
    }
}

