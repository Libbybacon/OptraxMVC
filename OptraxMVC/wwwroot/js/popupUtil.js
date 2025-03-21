
const popupHandler = {

    loadPopup: async function (props) {
        try {
            let options = {
                method: props.type || "GET" // Default to GET if not provided
            };

            if (props.data && Object.keys(props.data).length > 0) {

                if (options.method.toUpperCase() === "GET") {

                    const url = new URL(props.url, window.location.origin);

                    Object.keys(props.data).forEach(key => url.searchParams.append(key, props.data[key]));

                    props.url = url.href;
                }
                else {
                    options.headers = { "Content-Type": "application/json" };
                    options.body = JSON.stringify(props.data);
                }
            }

            const response = await fetch(props.url, options);

            if (!response.ok) {
                throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
            }
            const view = await response.text();

            document.getElementById("popupContent").innerHTML = view;
            document.getElementById("popupTitle").innerHTML = props.title;

            if (props.isDialog) {
                $("#popup").draggable({
                    appendTo: "#map",
                    iframeFix: true,
                    refreshPositions: true,
                    containment: "parent"
                });
                $("#popup").removeClass("transform-50");
                window.addEventListener("resizeDraggable", this.resizeDraggable);
            } else {
                $("#popup").addClass("transform-50");
                window.addEventListener("resizeHeight", this.setPopupHeight);
                $("#overlay").show();
            }

            $("#popup").show();
            this.setPopupHeight;

        } catch (error) {
            console.error("Error loading popup:", error.message);
        }
    },

    resizeDraggable: function () {
        if ($("#popup").draggable("instance") != undefined) {
            $("#popup").draggable("option", "containment", "parent");
            this.setPopupHeight;
        }

    },
    setPopupHeight: function () {
        const popup = $('#popupContent');
        const winHeight = window.innerHeight;
        const maxPopHeight = winHeight * 0.8;
        popup.css('max-height', `${maxPopHeight}px`);
    },
    closePopup: function () {
        window.removeEventListener("resizeHeight", setPopupHeight);
        $('#popup').hide();
        $('#overlay').hide();
        $('#popupContent').html('');
    }
}


export default popupHandler;