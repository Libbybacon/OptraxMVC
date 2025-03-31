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

            $('#popupClose').off('click').on('click', function () {
                popupHandler.closePopup();
            });

            $("#popup").show();
            popupHandler.setPopupHeight;

        }
        catch (error) {
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

        $('#popup').hide();
        $('#overlay').hide();
        $('#popupContent').html('');
    }
}

export default popupHandler;
