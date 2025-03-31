// jQuery + Bootstrap
import $ from 'jquery';
window.$ = $;
window.jQuery = $;
import 'jquery-ui';
import 'bootstrap';

// Leaflet
import L from 'leaflet';
import 'leaflet-draw'; // also attaches to Leaflet

// Choices.js
import 'choices.js';

// Driver.js
import Driver from 'driver.js';
import 'driver.js';


import popupHandler from "./utilities/popup.js";

var hideNav;

$(document).ready(function () {
    hideNav = sessionStorage.getItem('hideNav');

    if (hideNav == "true") {
        collapseNav();
    }

    $('#hide-nav').off('click').on('click', function () {
        collapseNav()
    });

    $('#show-nav').off('click').on('click', function () {
        expandNav();
    });

    $(window).on('resize', function () {
        const $nav = $('.side-nav');
        const viewW = $(window).width();

        if (viewW < 768 && $nav.hasClass('collapsed')) {
            expandNav(false);
        }
        else if (viewW >= 768 && hideNav == "true" && $nav.hasClass('expanded')) {
            collapseNav(false);
        }
    });

    window.showMessage = showMessage;
    window.loadPopup = popupHandler.loadPopup;
    window.closePopup = popupHandler.closePopup;
})

function showMessage(props) {

    const $div = $('<div>').text(props.msg).addClass('msg').addClass(props.css);

    props.msgdiv.append($div);

    $div.fadeIn(500, function () {
        setTimeout(function () {
            $div.fadeOut(500, function () {
                $div.remove();
            });
        }, 3000);
    });
}

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