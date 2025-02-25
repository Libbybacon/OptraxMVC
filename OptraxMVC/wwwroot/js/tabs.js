
var curPage;

$(document).ready(function () {

    curPage = $('#tab-page').val();

    let storedTab = localStorage.getItem(`${curPage}-active`);
    let firstTab = $(".top-tabs .nav-link.active");

    if (storedTab && storedTab !== "undefined") {
        $(firstTab).removeClass('active');

        let $activeTab = $(`button[data-key="${storedTab}"]`);
        let bsTab = new bootstrap.Tab($activeTab);
        bsTab.show();

        firstTab = $activeTab;
    }

    if (firstTab) {
        loadTab($(firstTab));
    }

    $(".nav-link").on("click", function () {
        loadTab($(this));
    });
});

function loadTab(tab) {

    let tabKey = $(tab).data("key");

    localStorage.setItem(`${curPage}-active`, tabKey);

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

