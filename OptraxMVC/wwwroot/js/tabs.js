
var curPage;

$(document).ready(function () {
    $(".nav-link").on("click", function () {
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
    let tabKey = $(tab).data("key");

    sessionStorage.setItem(`${curPage}-active`, tabKey);

    let $innerTab = $(`#${tabKey}`);

    if ($innerTab.hasClass("loaded")) return;

    let area = $(tab).attr("data-area");
    let name = $(tab).attr("data-name");

    $.ajax({
        url: '/Tabs/LoadTabContent/',
        type: "GET",
        data: { area: area, name: name },
        success: function (view) {
            $innerTab.html(view);
            $innerTab.hasClass("loaded");
        },
        error: function () {
            $innerTab.html('<div class="tab-div"><div class="tab-inner error-div">Coming Soon!</div></div>');
        }
    });
}

