function loadFeatures() {
    loadPoints();

    //setInterval(() => {
    //    loadPoints();
    //    loadLines();
    //    loadPolygons();
    //}, 30000);
}

function loadPoints() {
    $.ajax({
        type: "GET",
        url: "/Grow/Map/GetPoints",
        dataType: "json",
        success: function (response) {
            if (response.success) {
                pointsLayer.addData(response.data);
            }
        }
    });
}

function createPoint(latlng) {

    let newIcon = createIcon('https://img.icons8.com/?size=100&id=43731&format=png&color=263EDE');

    curMarker = L.marker(latlng).addTo(map).setIcon(newIcon).bindTooltip("New Point", { permanent: true, direction: "top" }).openTooltip();

    let props = {
        type: 'GET',
        url: `/Grow/Map/AddPoint/`,
        title: `New Point`,
        data: { lat: latlng.lat, lng: latlng.lng },
        isDialog: true
    }
    loadPopup(props);

    window.addEventListener("removeNewIcon", removeIcon);
    window.dispatchEvent(new Event("removeNewIcon"));
}

function removeIcon() {
    $(document).on('click', '.ui-draggable .popup-close', function () {
        curMarker.removeFrom(map);
        window.removeEventListener("removeNewIcon", removeIcon);
    });
}

$.fn.createPointSuccess = function (response) {

    closePopup();
};

function editPoint(id, name, marker) {

    curMarker = marker;

    let editProps = {
        type: 'GET',
        url: `/Grow/Map/EditPoint/`,
        title: name,
        data: { pointID: id },
        isDialog: true
    }
    loadPopup(editProps);
}

$.fn.editPointSuccess = function (response) {
    console.log('response', response);
    closePopup();
}

function loadLines() {
    console.log("Loading lines...");
    // Your AJAX call or logic here
}

function loadPolygons() {
    console.log("Loading polygons...");
    // Your AJAX call or logic here
}

function removeMarkerById(id) {
    console.log(`Removing marker with ID: ${id}`);
    // Your logic to remove marker
}