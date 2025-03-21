
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
                window.addEventListener("resizeDraggable", popupHandler.resizeDraggable);
            }
            else {
                $("#popup").addClass("transform-50");
                window.addEventListener("resizeHeight", popupHandler.setPopupHeight);
                $("#overlay").show();
            }
            console.log('props', props)
            if (props.mod) {
                popupHandler.loadModule(props.mod);
            }
            $("#popup").show();
            popupHandler.setPopupHeight;

        } catch (error) {
            console.error("Error loading popup:", error.message);
        }
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
        window.removeEventListener("resizeHeight", popupHandler.setPopupHeight);
        window.removeEventListener("resizeDraggable", popupHandler.resizeDraggable);

        $('#popup').hide();
        $('#overlay').hide();
        $('#popupContent').html('');
    }
}


export default popupHandler;