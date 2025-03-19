var map;
let isDrawing = false;
let isLongPress = false;
let anchorPoint = null;
let previewLine = null;
let holdTimeout = null;
let curMarker = null;

$(document).ready(function () {
    initializeMap();
})

function setMapListeners() {

    // Change point's tooltip content
    $('.point-info').on('input', function () {
        let props = { marker: curMarker, title: $('#Name').val(), desc: $('#Notes').val() }
        updateMarker(props);
    });

    // change icon collection display
    $('.icon-coll-name').on('click', function () {
        let collID = $(this).data('collid')

        $('.icon-coll-name').removeClass('selected');
        $(`.coll-name-${collID}`).addClass('selected');
        $('.preview-div').addClass('d-none');
        $(`.preview-div.preview-coll-${collID}`).removeClass('d-none');
    })

    // Update point icon
    $('.icon-div').on('click', function () {
        $('.icon-div').removeClass('selected');
        $('#IconID').val($(this).data('iconid'))
        $(this).addClass('selected');
        let imgURL = $(this).find('img').attr('src');
        let props = { iconURL: imgURL, marker: curMarker, title: $('#Name').val(), desc: $('#Notes').val() }
        updateMarker(props);
    })
}


function initializeMap() {
    map = L.map('map', {
        center: [-1.28333, 36.81667],
        zoom: 13
    });

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    setMapHeight();

    let addMapObjectControl = new L.Control.AddMapObject(); // AddMapObject Control
    map.addControl(addMapObjectControl);

    map.on('click', function (event) {
        event.originalEvent.preventDefault();  // Prevent default behavior
        event.originalEvent.stopPropagation(); // Stop the event from affecting the page
    });

    loadPoints();
}

function setMapHeight() {
    let viewH = `calc(100vh - 50px)`;

    $('#map').css('height', viewH);
    $(window).on('resize', function () {
        $('#map').css('height', viewH);
    });

    map.invalidateSize();
}

L.Control.AddMapObject = L.Control.extend({
    options: {
        position: 'topright'
    },

    onAdd: function (map) {
        let container = L.DomUtil.create('div', 'leaflet-control-map-object');

        let btn = L.DomUtil.create('button', 'form-btn add-map-obj', container);
        btn.innerHTML = 'Add Map Object';

        L.DomEvent.disableClickPropagation(container);

        btn.onclick = function () {
            toggleDrawingMode();
        };

        return container;
    }
});

function loadPoints() {
    $.ajax({
        type: "GET",
        url: "/Grow/Map/GetMapObjects",
        success: function (response) {
            console.log('response', response)
            if (response.success == true) {

                $.each(response.data, function (index, point) {
                    console.log('index', index, 'point', point);
                    let icon = createIcon(point.iconPath);
                    var marker = L.marker([point.lat, point.long]).addTo(map).setIcon(icon).bindTooltip(point.name, { permanent: true, direction: "top" }).openTooltip();
                })
            }
        }
    })
}


function toggleDrawingMode() {
    isDrawing = !isDrawing;

    if (isDrawing) {
        map.getContainer().style.cursor = 'crosshair';
        map.on('mousedown', handleMouseDown);
        map.on('mouseup', handleMouseUp);
        map.on('dblclick', startLine);
        map.doubleClickZoom.disable();
        $('.add-map-obj').addClass('bg-grn-dk');
    }
    else {
        map.getContainer().style.cursor = '';
        map.off('mousedown', handleMouseDown);
        map.off('mouseup', handleMouseUp);
        map.off('dblclick', startLine);
        map.doubleClickZoom.enable();
        $('.add-map-obj').removeClass('bg-grn-dk');
    }
}

function handleMouseDown(event) {
    isLongPress = false;

    holdTimeout = setTimeout(() => {
        isLongPress = true;
        createPoint(event.latlng);
        toggleDrawingMode(); 
    }, 500); 
}

function handleMouseUp() {
    clearTimeout(holdTimeout);
}

function startLine(event) {

    if (anchorPoint) {
        return; // Ignore if already drawing line
    }

    anchorPoint = event.latlng;
    
    previewLine = L.polyline([anchorPoint, anchorPoint], { color: 'blue', dashArray: '5, 5' }).addTo(map); // Temp line that follows the mouse

    map.on('mousemove', updateLine);
    map.once('click', finalizeLine); // Finalize line on second click
}

function updateLine(event) {
    if (!previewLine) return;
    previewLine.setLatLngs([anchorPoint, event.latlng]);// Update preview line as mouse moves
}

function finalizeLine(event) {

    if (!anchorPoint) return;

    let endPoint = event.latlng;
    addLine(anchorPoint, endPoint);
   
    if (previewLine) {
        map.removeLayer(previewLine); // Remove preview line
        previewLine = null;
    }

    anchorPoint = null;
    map.off('mousemove', updateLine);
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
}

function updateMarker(props) {
    console.log('props', props)
    if (props.iconURL && props.iconURL.length > 0) {
        let newIcon = createIcon(props.iconURL);
        props.marker.setIcon(newIcon);
    }

    let title = (props.title != undefined) ? `<b>${props.title}</b>` : "";
    let desc = (props.desc != undefined) ? `<br>${props.desc}` : "";
    console.log('title', title, 'desc', desc)
    let tooltipContent = `${title}${desc}`;
    props.marker._tooltip.setContent(tooltipContent);
}

function createIcon(url) {
    return L.icon({
        iconUrl: url,   // Path to the new icon image
        iconSize: [32, 32], // Size of the icon
        iconAnchor: [16, 32], // Point where the icon anchors on the map
        popupAnchor: [0, -32], // Adjust popup position relative to icon
        tooltipAnchor: [0, -32] // Adjust popup position relative to icon
    });
}

function addLine(start, end) {
    L.polyline([start, end], { color: 'red' }).addTo(map);
}