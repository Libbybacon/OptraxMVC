
var curTabKey = "";
var cache = sessionStorage;

$(document).ready(function () {

    // Load initially active tab
    let firstTab = $(".top-tabs .nav-link.active");
    if (firstTab) {
        loadTab($(firstTab));
    }

    $(".nav-link").on("click", function () {
        //cacheTab($(this));
        loadTab($(this));
    });

    $(document).on("click", ".save-btn", function () {
        var tabKey = $(this).closest(".tab-pane").attr("id");

        cache.removeItem("tabCache_" + tabKey); // Clear cache for this tab
    });
});

//function cacheTab(tab) {

//    var tabContent = $(`#${curTabKey}`).html();

//    cache.setItem(`tabCache_${curTabKey}`, tabContent); // Save html content

//    $(`#${curTabKey} :input`).each(function () {
//        cache.setItem(tabKey + "_" + this.name, $(this).val()); // Save form data
//    });

//    $(`#${curTabKey}`).find(".inner-tab").html(); // Clear tab content from DOM

//    loadTab(tab);
//}


function loadTab(tab) {
    let tabKey = $(tab).data("key");
    let innerTab = $(`#${tabKey}`).find(".inner-tab");
    if (innerTab.hasClass("loaded")) return;
    //curTabKey = tabKey;

    //var cachedTab = cache.getItem(`tabCache_${tabKey}`);

    //if (cachedTab) {
    //    innerTab.html(cachedTab);

    //    $(`#${tabKey} :input`).each(function () {
    //        var val = cache.getItem(tabKey + "_" + this.name);
    //        if (val !== null) {
    //            $(this).val(val);
    //        }
    //    });
    //    return;
    //}

    if (innerTab.hasClass("loaded")) return;    // Skip loading if already loaded

    let area = $(tab).attr("data-area");
    let name = $(tab).attr("data-name");

    let tabVM = { Area: area, Tabs: [{ Name: name, TabKey: tabKey }] } 
    console.log(tabVM)
    var url = '@Url.Action("LoadTabContentAsync", "Tabs")';
    $.ajax({
        url: '/Tabs/LoadTabContent/',
        type: "GET",
        data: {area: area, name: name},
        success: function (view) {
            innerTab.html(view);
            innerTab.hasClass("loaded");
            sessionStorage.setItem("tabCache_" + tabKey, view);
        },
        error: function () {
            innerTab.html("<p>Error loading content.</p>");
        }
    });
}