
var OrigModel;
var Changes = [];

$(document).ready(function () {

    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse($(`#modelForm`));
    }

    //$(`#modelForm`).on('submit', submitForm)
    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        console.log('sub 1');
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
        default:
            break;
    }

    if ($('#modelForm').data('func').includes('update')) {
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

    $(document).find('.update-btn').removeClass('d-none').addClass('d-none');

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
    });
}

function submitForm() {

    let $form = $(`#modelForm`);
    let msgdiv = $(`#${$form.data('msgdiv')}`);
    let proceed = $form.attr('action').includes('Create') || Changes.length > 0;
    console.log('form');

    //if ($form.data('func') == "addPlants") {
    //    console.log('resubmit')
    //    $(`#modelForm`).off('submit', submitForm);
    //    $('#modelForm').submit();
    //}
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
                            setSelectDrops();
                            setModelChanges();
                            updateItemSuccess(response);
                            break;
                        case "updateCategory":
                            setSelectDrops();
                            setModelChanges();
                            updateCategorySuccess();
                            break;
                        case "addPlants":
                            addPlantsSuccess(response);
                            break;
                        case "addLocation":
                            addLocationSuccess(response);
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

