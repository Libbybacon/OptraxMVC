
var curTabKey = "";
var cache = sessionStorage;

$(document).ready(function () {

    // Load initially active tab
    let firstTab = $(".nav-link.active");
    if (firstTab) {
        loadTabContent(firstTab);
    }

    $(".nav-link").on("click", function () {
        cacheTab($(this));
    });

    $(document).on("click", ".save-btn", function () {
        var tabKey = $(this).closest(".tab-pane").attr("id");

        cache.removeItem("tabCache_" + tabKey); // Clear cache for this tab
    });
});

function cacheTab(tab) {

    var tabContent = $(`#${curTabKey}`).html();

    cache.setItem(`tabCache_${curTabKey}`, tabContent); // Save html content

    $(`#${curTabKey} :input`).each(function () {
        cache.setItem(tabKey + "_" + this.name, $(this).val()); // Save form data
    });

    $(`#${curTabKey}`).find(".inner-tab").html(); // Clear tab content from DOM

    loadTab(tab);
}
function loadTab(tab) {

    let tabKey = tab.attr("data-key");
    let innerTab = $(`#${tabKey}`).find(".inner-tab");

    var cachedTab = cache.getItem(`tabCache_${tabKey}`);

    if (cachedTab) {
        innerTab.html(cachedTab);

        $(`#${tabKey} :input`).each(function () {
            var val = cache.getItem(tabKey + "_" + this.name);
            if (val !== null) {
                $(this).val(val);
            }
        });
        return;
    }

    if (innerTab.hasClass("loaded")) return;    // Skip loading if already loaded

    let Area = tab.attr("data-area");
    let Name = tab.attr("data-name");

    let data = { Area, Tabs: [{ Name, TabKey: tabKey }] }

    $.ajax({
        url: "/Tabs/LoadTabContentAsync",
        type: "GET",
        data: data,
        success: function (view) {
            innerTab.html(view);
            sessionStorage.setItem("tabCache_" + tabKey, view);
        },
        error: function () {
            innerTab.html("<p>Error loading content.</p>");
        }
    });
}