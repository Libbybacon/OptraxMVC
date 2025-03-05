
var hideNav;

$(document).ready(function () {
    hideNav = sessionStorage.getItem('hideNav');

    if (sessionStorage.getItem('hideNav') == "true") {
        collapseNav();
    }

    $('#hide-nav').off('click').on('click', function () {
        collapseNav()
    });

    $('#show-nav').off('click').on('click', function () {
        expandNav();
    });

    $('#popupClose').off('click').on('click', function () {
        closePopup();
    });

    $(window).on('resize', function () {
        let $nav = $('.side-nav');
        let viewW = $(window).width();

        if (viewW < 768 && $nav.hasClass('collapsed')) {
            expandNav(false);
        }
        else if (viewW >= 768 && hideNav == "true" && $nav.hasClass('expanded')) {
            collapseNav(false);
        }
    });
})

function collapseNav(saveToSession = true) {
    $('.logo').removeClass('d-lg-block');
    $('.nav-bi').removeClass('me-lg-3');
    $('.logo-sm').removeClass('d-lg-none');
    $('.side-nav').css('width', '50px')
    $('.nav-text').removeClass('d-lg-block');
    $('.logout-txt').addClass('f-xs')
    $('.side-nav').addClass('collapsed').removeClass('expanded')
    $('.nav-hide-tab i').toggleClass('d-none');

    if (saveToSession) {
        sessionStorage.setItem('hideNav', true);
    }
}

function expandNav(saveToSession = true) {
    $('.logo').addClass('d-lg-block');
    $('.nav-bi').addClass('me-lg-3');
    $('.logo-sm').addClass('d-lg-none');
    $('.side-nav').css('width', 'auto');
    $('.nav-text').addClass('d-lg-block');
    $('.logout-txt').removeClass('f-xs')
    $('.side-nav').removeClass('collapsed').addClass('expanded')
    $('.nav-hide-tab i').toggleClass('d-none');

    if (saveToSession) {
        sessionStorage.setItem('hideNav', false);
    }
}

function loadPopup(props) {
    let ajaxOptions = {
        url: props.url,
        type: props.type,
        success: function (view) {
            $('#overlay').show();
            $('#popupContent').html(view);
            $('#popupTitle').html(props.title);
            $('#popup').show();
        },
        error: function (xhr, status, error) {
            console.error('Error loading popup:', xhr.responseText);
        }
    };

    if (props.data && Object.keys(props.data).length > 0) {
        ajaxOptions.data = props.data;
    }

    $.ajax(ajaxOptions);
}

function closePopup() {
    $('#popup').hide();
    $('#overlay').hide();
    $('#popupContent').html();
}

function showUpdateMessage(props) {

    let $div = $('<div>').text(props.msg).addClass('msg-div').addClass(props.css);

    props.msgdiv.append($div);

    $div.fadeIn(500, function () {
        setTimeout(function () {
            $div.fadeOut(500, function () {
                $div.remove();
            });
        }, 3000);
    });
}


function arrayToModel(arr) {
    var model = {};

    for (var i = 0; i < arr.length; i++) {

        model[arr[i]['name']] = arr[i]['value'];
    }
    return model;
}
