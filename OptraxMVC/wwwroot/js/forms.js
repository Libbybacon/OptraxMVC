$(document).ready(function () {

    setSelectDrops();

    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse($(`#modelForm`));
    }

    $('.hex-pick').on('click', function () {
        Coloris({
            alpha: true,
            swatches: ['#FF3333', '#EF7A1A', '#F9C04D', '#328532 ', '#1D52D7', '#9E6DD9', '#DA6565', '#F9AA8A', '#F8DEA0', '#97CA91', '#9BB2E3', '#C4ADCA'],
            onChange: (color) => $('.hex-prev').css('background-color', color)
        });
    });
    $('.hex-pick-bw').on('click', function () {
        Coloris({
            alpha: false,
            swatches: ["#000000", "#FFFFFF"],
            onChange: (color) => $('.hex-prev').css('color', color)
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

    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
        event.preventDefault();
        submitForm($(`#modelForm`))
    });

    $('.cat-name-ed').on('input', function () {
        $('.hex-prev').val($(this).val());
    })

});

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
}

function submitForm($form) {
    console.log('url', $form.attr("action"))
    if ($form.valid()) {

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            success: function (response) {

                let div = $form.data('msgdiv');
                console.log('div', div);

                let msgdiv = $(`#${$form.data('msgdiv')}`);

                if (response.success) {
                    switch ($form.data('func')) {
                        case "saveItem":
                            saveItemSuccess(response);
                            break;
                        default:
                            showUpdateMessage({ css: 'success', msg: response.message, msgdiv: msgdiv })
                    }
                }
                else {
                    showUpdateMessage({ css: 'error', msg: 'Error Saving Changes...', msgdiv: msgdiv })
                }
            },
            error: function () {
                alert("");
                showUpdateMessage({ css: 'error', msg: 'An error occurred while saving.', msgdiv: msgdiv })
            }
        });
    }
}