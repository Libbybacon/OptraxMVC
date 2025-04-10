import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import { addSitePoint } from '../map/map.js';
const urlBase = '/Grow/Locations/';
const formId = '#locForm';


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
    $(formId + ' #Name').on('input', function () {
        $(formId + ' #Address_Name').val($(this).val()).trigger('change');
    })

    $(formId + ' locForm .toggle-edit').on('click', function () {
        const model = $(this).parent('.model');
        model.find('.m-toggle').toggleClass('d-none');
    });

    $(formId + ' .addy').on('change', function () {
        setAddyLatLng();
    });

    $(formId + ' .btn-red').off('click').on('click', function () {
        const id = $(formId).data('id');
        const type = $(formId).data('type')
        onDelete(id, type);
    })

    $(formId).off('submit').on('submit', function (e) {
        e.preventDefault();
        onSubmitForm() // submit form
    });

    formUtil.setListeners(formId);
    formUtil.showHideBtns(formId);
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
    const locType = $(formId + ' #LocationType').val();
    const isCreate = action && action.includes('Create');

    //console.log('loc onSubmitForm objType: ', locType, ' action:', action);

    const response = await formUtil.submitForm(formId);
    console.log('loc onSubmitForm response', response, 'address', address);

    if (response && response.success) {
        if (isCreate) {
            addSitePoint($('.addy-lat').val(), $('.addy-lng').val(), $(formId + ' #Name').val());

            if (response.data) {
                console.log('response.data', response.data)
                $(formId + ' #Id').val(response.data.id);

                const tree = $('#locationTree').jstree(true);
                tree.create_node(response.data.parent, response.data, "last", function (newNode) {
                    //console.log('newnode:', newNode);

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
    const address =
        $('.addy-street1').val() + ',' +
        $('.addy-city').val() + ',' +
        $('.addy-state').val() + ' ' +
        $('.addy-zip').val();


    geocodeAddress(address, (err, result) => {
        if (err) {
            return;
        }

        const { lat, lng, name } = result;

        $('.addy-lat').val(lat);
        $('.addy-lng').val(lng);
    });
}

function geocodeAddress(address, callback) {
    const url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(address)}`;

    fetch(url, {
        headers: {
            'User-Agent': 'OptraxFarmingApp/1.0 (your@email.com)'
        }
    })
        .then(res => res.json())
        .then(data => {
            if (data.length > 0) {
                const lat = parseFloat(data[0].lat);
                const lon = parseFloat(data[0].lon);
                callback(null, { lat, lon, display_name: data[0].display_name });
            } else {
                callback("No results found");
            }
        })
        .catch(err => callback(err));
}