﻿
var curPage;

$(function () {

    $(".top-tabs .nav-link").on("click", function () {
        loadTab($(this));
    });

    curPage = $('#tab-page').val();

    let storedTab = sessionStorage.getItem(`${curPage}-active`);

    if (storedTab && storedTab !== "undefined") {
        let $activeTab = $(`button[data-key="${storedTab}"].nav-link`);
        $activeTab.trigger('click');
    }
    else {
        let firstTab = $(".top-tabs .nav-link.active");
        loadTab($(firstTab));
    }


});

function loadTab(tab) {
    const tabKey = $(tab).data("key");

    sessionStorage.setItem(`${curPage}-active`, tabKey);

    const $innerTab = $(`#${tabKey}`);

    if ($innerTab.hasClass("loaded")) return;

    $innerTab.addClass('loaded');

    const path = $(tab).attr("data-path");
    console.log('loadTab', path);

    $.ajax({
        url: path,
        type: "GET",
        success: function (view) {
            $innerTab.html(view);
            $innerTab.hasClass("loaded");
        },
        error: function () {
            $innerTab.html('<div class="tab-div"><div class="tab-inner error-div">Coming Soon!</div></div>');
        }
    });
}

