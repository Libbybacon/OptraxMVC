/******/ (() => { // webpackBootstrap
/*!****************************!*\
  !*** ./wwwroot/js/tabs.js ***!
  \****************************/
var curPage;
$(function () {
  $(".top-tabs .nav-link").on("click", function () {
    loadTab($(this));
  });
  curPage = $('#tab-page').val();
  var storedTab = sessionStorage.getItem("".concat(curPage, "-active"));
  if (storedTab && storedTab !== "undefined") {
    var $activeTab = $("button[data-key=\"".concat(storedTab, "\"].nav-link"));
    $activeTab.trigger('click');
  } else {
    var firstTab = $(".top-tabs .nav-link.active");
    loadTab($(firstTab));
  }
});
function loadTab(tab) {
  var tabKey = $(tab).data("key");
  sessionStorage.setItem("".concat(curPage, "-active"), tabKey);
  var $innerTab = $("#".concat(tabKey));
  if ($innerTab.hasClass("loaded")) return;
  $innerTab.addClass('loaded');
  var path = $(tab).attr("data-path");
  console.log('loadTab', path);
  $.ajax({
    url: path,
    type: "GET",
    success: function success(view) {
      $innerTab.html(view);
      $innerTab.hasClass("loaded");
    },
    error: function error() {
      $innerTab.html('<div class="tab-div"><div class="tab-inner error-div">Coming Soon!</div></div>');
    }
  });
}
/******/ })()
;
//# sourceMappingURL=tabs.bundle.js.map