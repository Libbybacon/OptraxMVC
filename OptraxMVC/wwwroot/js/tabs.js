
var curTabKey = "";
var cache = sessionStorage;

$(document).ready(function () {

    
    let storedTab = localStorage.getItem('activeTab');    
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

    $(document).on("click", ".save-btn", function () {
        var tabKey = $(this).closest(".tab-pane").attr("id");

        cache.removeItem("tabCache_" + tabKey); // Clear cache for this tab
    });
});

function loadTab(tab) {

    let tabKey = $(tab).data("key");

    localStorage.setItem('activeTab', tabKey);

    let $innerTab = $(`#${tabKey}`).find(".inner-tab");

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

