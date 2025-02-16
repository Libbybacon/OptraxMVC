$(document).ready(function () {


    // Detect and load the initially active tab
    var initialTab = $(".nav-link.active").attr("data-tab-key");
    if (initialTab) {
        loadTabContent(initialTab);
    }

    // Load content when another tab is clicked
    $(".nav-link").on("click", function () {
        var tabKey = $(this).attr("data-tab-key");
        loadTabContent(tabKey);
    });
});

function loadTabContent(tabKey) {
    var contentContainer = $("#" + tabKey).find(".tab-content-container");

    // Skip loading if already loaded
    if (contentContainer.hasClass("loaded")) return;

    $.ajax({
        url: "/Shared/LoadTabContent",
        type: "GET",
        data: { tabKey: tabKey },
        success: function (response) {
            contentContainer.html(response);
            contentContainer.addClass("loaded");
        },
        error: function () {
            contentContainer.html("<p>Error loading content.</p>");
        }
    });
}