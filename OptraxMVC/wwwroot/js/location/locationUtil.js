import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import { startDraw } from '../map/objectManager.js';
import { getMap } from '../map/mapState.js';

const formId = '#locForm';
const urlBase = '/Grow/Locations/';

export function loadCreate(parentId, type) {

    const props = { action: 'LoadCreate', data: { type: type, parentId: parentId } }

    loadPartial(props).then = () => {
        setFormListeners();
    };
}

export async function loadPartial(props) {
    const response = await apiService.get(`${urlBase}${props.action}/`, props.data);
    console.log('locjs loadPartial response', response);

    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading location', msgdiv: $('.loc-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    const view = await response.data;
    if (view) {
        $("#loc-details").html(view);
        setFormListeners();
        let map = getMap();
        zoomToSite(map);
    }
}

export function setLocListeners() {
    $('#add-new-loc').on('click', function () {
        loadCreate(null, 'site');
    })

    $('#locationTree').on("select_node.jstree", function (e, data) {
        const props = { action: 'GetDetails', data: { id: data.node.id, type: data.node.type } }
        loadPartial(props)
    });
    setFormListeners();
}

export function setFormListeners() {
    $(formId).find('loc-name').on('input', function () {
        $(formId).find('addy-name').val($(this).val()).trigger('change');
    })

    $('.draw-list li a').off('click').on('click', function () {
        const type = $(this).data('type');
        startDraw(type);
    })

    $(formId).find('.btn-red').off('click').on('click', function () {
        const id = $(formId).data('id');
        const type = $(formId).data('type')
        onDelete(id, type);
    })

    $(formId).find('.edit-btn').off('click').on('click', function () {
        setTimeout(() => {
            setAddyLatLng();
        }, 100)
    })

    $(formId).off('submit').on('submit', function (e) {
        e.preventDefault();
        onSubmitForm() // submit form
    });

    formUtil.setListeners(formId);

    $(formId).find('.addy').on('change', function () {
        console.log('addy change');
        setAddyLatLng();
    });
}

export async function onDelete(id, type) {
    const response = await apiService.get(`${urlBase}Delete/`, { id: id });

    if (response && response.success) {
        window.showMessage({ msg: `${locType} Deleted!`, css: 'success msg', msgdiv: $('.loc-msg') });
    }
    else {
        var msg = response.msg ?? "Error deleting " + type;
        window.showMessage({ msg: msg, css: 'error msg', msgdiv: $('.loc-msg') });
    }
}

export async function onSubmitForm() {
    const action = $(formId).attr('action');
    const locType = $(formId).find('.loc-type').val();
    const isCreate = action && action.includes('Create');

    //console.log('loc onSubmitForm objType: ', locType, ' action:', action);

    const response = await formUtil.submitForm(formId);
    console.log('loc onSubmitForm response', response);

    if (response && response.success) {
        if (isCreate) {
            if (response.data) {
                console.log('response.data', response.data)
                $(formId + ' #Id').val(response.data.id);

                const tree = $('#locationTree').jstree(true);
                tree.create_node(response.data.parent, response.data, "last", function (newNode) {
                    newNode.parents.forEach(id => {
                        tree.open_node(id);
                    });
                    tree.deselect_all();
                    tree.select_node(newNode.id);
                });
            }
        }
        $(formId + ' .m-toggle').toggleClass('d-none');

        let msgTxt = isCreate ? 'Created' : 'Updated';
        window.showMessage({ msg: `${locType} ${msgTxt}!`, css: 'success msg', msgdiv: $('.loc-msg') });
    }
    else {
        alert('Error! ' + response.error);
    }
}

export function setAddyLatLng() {
    console.log('setAddyLatLng')
    // Check whether all components of address are filled
    const addyArr = [$('.addy-street1').val(), $('.addy-city').val(), $('.addy-state').val(), $('.addy-zip').val()]
    const hasEmpty = addyArr.some((a) => a === null || a === undefined || a.trim() === '');

    if (!hasEmpty) {
        const address = addyArr.join(', ');

        // Get address lat, lng, zoom to loc on map, set form values
        geocodeAddress(address, (err, result) => {
            console.log('geocode result', result, 'address', address);
            if (err) {
                console.log('geocode error')
                return;
            }
            const { lat, lon } = result;

            let map = getMap();
            map.setView([lat, lon], 21);

            $('.addy-lat').val(lat).trigger('change');
            $('.addy-lng').val(lon).trigger('change');
        });
    }
}

function geocodeAddress(address, callback) {
    const url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(address)}`;

    fetch(url, {
        headers: {
            'User-Agent': 'OptraxApp/1.0 (optrax@optrax.dev)'
        }
    })
        .then(res => res.json())
        .then(data => {
            if (data.length > 0) {
                const lat = parseFloat(data[0].lat);
                const lon = parseFloat(data[0].lon);
                callback(null, { lat, lon });
            } else {
                callback("No results found");
            }
        })
        .catch(err => callback(err));
}

export function zoomToSite(map) {

    const lat = parseFloat($('#locForm').find('.addy-lat').val());
    const lng = parseFloat($('#locForm').find('.addy-lng').val());

    //console.log('delayed zoomToSite lat', lat, 'lng', lng);

    if (!isNaN(lat) && !isNaN(lng)) {
        map.invalidateSize();
        map.setView([lat, lng], 21);
        //console.log('zoomed after delay:', map.getCenter());
    }

}