(()=>{var a;function t(t){var n=$(t).data("key");sessionStorage.setItem("".concat(a,"-active"),n);var e=$("#".concat(n));if(!e.hasClass("loaded")){e.addClass("loaded");var o=$(t).attr("data-path");console.log("loadTab",o),$.ajax({url:o,type:"GET",success:function(a){e.html(a),e.hasClass("loaded")},error:function(){e.html('<div class="tab-div"><div class="tab-inner error-div">Coming Soon!</div></div>')}})}}$(document).ready((function(){$(".top-tabs .nav-link").on("click",(function(){t($(this))})),a=$("#tab-page").val();var n=sessionStorage.getItem("".concat(a,"-active"));if(n&&"undefined"!==n)$('button[data-key="'.concat(n,'"].nav-link')).trigger("click");else{var e=$(".top-tabs .nav-link.active");t($(e))}}))})();