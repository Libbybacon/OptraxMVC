$(document).ready(function () {
    $('#hide-nav').off('click').on('click', function () {
        collapseNav()
    });

    $('#show-nav').off('click').on('click', function () {
        expandNav();
    });
})

function collapseNav() {
    $('.logo').removeClass('d-lg-block');
    $('.logo-sm').removeClass('d-lg-none');
    $('.nav-bi').removeClass('me-lg-3');
    $('.nav-text').removeClass('d-lg-block');
    $('.side-nav').css('width', '50px')
    $('.nav-hide-tab i').toggleClass('d-none');
}

function expandNav() {
    console.log('click')
    $('.logo').addClass('d-lg-block');
    $('.logo-sm').addClass('d-lg-none');
    $('.nav-bi').addClass('me-lg-3');
    $('.nav-text').addClass('d-lg-block');
    $('.side-nav').css('width', 'auto');
    $('.nav-hide-tab i').toggleClass('d-none');
}

function arrayToModel(arr) {
    var model = {};

    for (var i = 0; i < arr.length; i++) {

        model[arr[i]['name']] = arr[i]['value'];
    }
    return model;
}

function showUpdateMessage($parentDiv, success, classes) {

    let text = success ? "Changes Saved!" : "Error Updating";
    let classnames = (success ? "success " : "error ") + classes;
    const $div = $('<div>').text(text).addClass(classnames);

    $parentDiv.append($div);

    // make lil update message fade in then out
    $div.fadeIn(500, function () {
        setTimeout(function () {
            $div.fadeOut(500, function () {
                $div.remove();
            });
        }, 1000);
    });
}


