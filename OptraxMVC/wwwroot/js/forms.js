﻿
var OrigModel;
var Changes = [];

var ColorSwatches = [
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

var BwSwatches = ["#000000", "#FFFFFF"]

$(document).ready(function () {

    Changes = [];
    OrigModel = arrayToModel($('#modelForm').serializeArray()); // save original model values

    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse($(`#modelForm`));
    }

    setSelectDrops();
    resetModelChanges();
    setItemFormListeners();

    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        event.preventDefault();
        submitForm($(`#modelForm`))
    });

    $('.attr').off('change').on('change', function () {

        let attrName = $(this).attr('Name');

        if ($(this).val() != OrigModel[attrName]) {
            Changes.push(attrName);
        }
        else if (Changes.length > 0) {
            Changes = Changes.filter(function (c) { return c != attrName });
        }
        let changed = Changes.length > 0;

        $('#changes').val(changed > 0 ? Changes.toString() : null);      

        changed > 0 ? $('.update-btn').removeClass('d-none') : $('.update-btn').addClass('d-none');
    })
});

function setItemFormListeners() {

    $('.cat-name-edit').on('input', function () {
        $('.hex-prev').val($(this).val());
    });

    $('.hex-pick').on('click', function () {
        Coloris({
            alpha: true,
            swatches: ColorSwatches,
            onChange: (color) => $('.hex-prev').css('background-color', color)
        });
    });

    $('.hex-pick-bw').on('click', function () {
        Coloris({
            alpha: false,
            swatches: BwSwatches,
            onChange: (color) => $('.hex-prev').css('color', color)
        });
    });
}

function arrayToModel(arr) {
    var model = {};

    for (var i = 0; i < arr.length; i++) {

        model[arr[i]['name']] = arr[i]['value'];
    }
    return model;
}

function setSelectDrops() {

    $('.select2').select2({
        theme: "bootstrap-5", // Ensures it follows Bootstrap styles
        width: "100%"
    });

    $(window).on("resize", function () {
        $(".select2").each(function () {
            $(this).select2({
                theme: "bootstrap-5",
                width: "100%"
            });
        });
    });

    $(".select2").on("change", function () {

        let val = $(this).val();

        if (!val || val === "") {
            $(this).val(null).trigger("change.select2");
        }
        else {
            $(this).valid()
        }
    });
}

function resetModelChanges() {
    Changes = [];
    $('#changes').val(null);
    OrigModel = arrayToModel($('#modelForm').serializeArray());

    $(document).find('.update-btn').removeClass('d-none').addClass('d-none');
}

function submitForm($form) {

    let msgdiv = $(`#${$form.data('msgdiv')}`);

    let proceed = $form.attr('action').includes('Create') || Changes.length > 0;

    if ($form.valid() && proceed) {

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            success: function (response) {
                if (response.success) {
                    switch ($form.data('func')) {
                        case "addItem":
                            addItemSuccess(response);
                            break;
                        case "updateItem":
                            resetModelChanges();
                            updateItemSuccess(response);
                            break;
                        case "updateCategory":
                            resetModelChanges();
                            updateCategorySuccess();                            
                        default:
                            closePopup();
                    }
                    showUpdateMessage({ css: 'success', msg: response.msg, msgdiv: msgdiv })
                }
                else {
                    console.log('fail')
                    showUpdateMessage({ css: 'error', msg: 'Error Saving Changes...', msgdiv: msgdiv })
                }
            },
            error: function () {
                showUpdateMessage({ css: 'error', msg: 'An error occurred while saving.', msgdiv: msgdiv })
            }
        });
    }
    else {
        console.log('error!')
    }
}

