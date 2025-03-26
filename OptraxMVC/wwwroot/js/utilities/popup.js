import apiService from "./api.js";

const popupHandler = {

    // title, url, data, module
    loadPopup: async function (props) {
        try {
            const response = await apiService.get(props.url, props.data);

            if (!response.success == true) {
                throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
            }
            const view = response.data;

            document.getElementById("popupContent").innerHTML = view;
            document.getElementById("popupTitle").innerHTML = props.title;            

            window.addEventListener("resizeHeight", popupHandler.setPopupHeight);
            $("#overlay").show();

            if (props.mod) {
                popupHandler.loadModule(props.mod);
            }
            $("#popup").show();
            popupHandler.setPopupHeight;

        } catch (error) {
            console.error("Error loading popup:", error.message);
        }
    },
    setPopupHeight: function () {
        const popup = $('#popupContent');
        const winHeight = window.innerHeight;
        const maxPopHeight = winHeight * 0.8;
        popup.css('max-height', `${maxPopHeight}px`);
    },
    closePopup: function () {
        window.removeEventListener("resizeHeight", popupHandler.setPopupHeight);
        //window.removeEventListener("resizeDraggable", popupHandler.resizeDraggable);

        $('#popup').hide();
        $('#overlay').hide();
        $('#popupContent').html('');
    },
    loadModule: async function (mod) {
        try {
            const cacheBustedPath = `${mod.path}?v=${Date.now()}`;
            const module = await import(cacheBustedPath);
            if (module[mod.method]) {
                module[mod.method]();
            }
            else {
                console.warn(`Method '${mod.method}' not found in ${mod.path}`);
            }
        } catch (err) {
            console.error(`Failed to load module '${mod.path}':`, err);
        }
    },
}

export default popupHandler;

//if (props.isDialog) {
//    $("#popup").draggable({
//        appendTo: "#map",
//        iframeFix: true,
//        refreshPositions: true,
//        containment: "parent"
//    });
//    $("#popup").removeClass("transform-50");
//    window.addEventListener("resizeDraggable", popupHandler.resizeDraggable);
//}
//else {
//    $("#popup").addClass("transform-50");
//    window.addEventListener("resizeHeight", popupHandler.setPopupHeight);
//    $("#overlay").show();
//}

//resizeDraggable: function () {
//    if ($("#popup").draggable("instance") != undefined) {
//        $("#popup").draggable("option", "containment", "parent");
//        this.setPopupHeight;
//    }
//},