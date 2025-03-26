import popupHandler from "./utilities/popup.js";

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

    $(document).on('click', '#modelForm .edit-btn', function () {
        let $form = $('#modelForm');
        $form.find('.view').addClass('d-none');
        $form.find('.show-ed').removeClass('d-none');
        $form.find('.attr').removeClass('d-none');
        $form.find('.cancel-btn').removeClass('d-none');
    });
    $(document).on('click', '#modelForm .cancel-btn', function () {
        let $form = $('#modelForm');
        $form.find('.view').removeClass('d-none');
        $form.find('.show-ed').addClass('d-none');
        $form.find('.attr').addClass('d-none');
        $form.find('.cancel-btn').addClass('d-none');
    });

    $(window).on('resize', function () {
        let $nav = $('.side-nav');
        let viewW = $(window).width();
        let viewH = $(window).height();

/*        $('#map').css('height', `${viewH - 50}px`);*/

        if (viewW < 768 && $nav.hasClass('collapsed')) {
            expandNav(false);
        }
        else if (viewW >= 768 && hideNav == "true" && $nav.hasClass('expanded')) {
            collapseNav(false);
        }
    });
})

window.loadPopup = popupHandler.loadPopup;
window.closePopup = popupHandler.closePopup;
window.showMessage = showMessage;

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

function showMessage(props) {

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








//function loadPopup(props) {
//    let ajaxOptions = {
//        url: props.url,
//        type: props.type,
//        success: function (view) {

//            $('#popupContent').html(view);
//            $('#popupTitle').html(props.title);

//            if (props.isDialog && props.isDialog == true) {
//                $('#popup').draggable({
//                    appendTo: "#map",
//                    iframeFix: true,
//                    refreshPositions: true,
//                    containment: "parent"
//                });
//                $('#popup').removeClass('transform-50');
//                window.addEventListener("resizeDraggable", resizeDraggable);
//            }
//            else
//            {
//                $('#popup').addClass('transform-50');
//                window.addEventListener("resizeHeight", setPopupHeight);

//                $('#overlay').show();
//            }
//            $('#popup').show();
//            setPopupHeight();
//        },
//        error: function (xhr, status, error) {
//            console.error('Error loading popup:', xhr.responseText);
//        }
//    };

//    if (props.data && Object.keys(props.data).length > 0) {
//        ajaxOptions.data = props.data;
//    }

//    $.ajax(ajaxOptions);
//}