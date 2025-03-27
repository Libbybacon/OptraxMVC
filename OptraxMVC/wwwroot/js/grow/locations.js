import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import popupHandler from '../utilities/popup.js';
import { map } from '../map/map.js';


$(document).ready(function () {

    console.log('hassite', $('#locations').data('hassite'))
    if ($('#locations').data('hassite') === 'False') {
        showNewSite();
    }
    initializeTree();
    setResizer();
    setLocListeners();
});

function setLocListeners() {
    $(document).on('click', '.toggle-edit', function () {
        const model = $(this).closest('.model');
        model.find('.m-toggle').toggleClass('d-none');
    });
}

function setResizer() {
    const resizer = document.getElementById('resizer');
    const col2 = document.getElementById('loc-details');
    const col3 = document.querySelector('.loc-map');
    let isResizing = false;

    resizer.addEventListener('mousedown', (e) => {
        e.preventDefault();
        isResizing = true;
        document.body.style.cursor = 'col-resize';
        col3.style.pointerEvents = 'none';
    });

    document.addEventListener('mousemove', (e) => {
        if (!isResizing) return;
        e.preventDefault();
        const newWidth = e.clientX - col2.getBoundingClientRect().left;

        $('#loc-details').css('width', newWidth + 'px');
        map.invalidateSize();
    });

    document.addEventListener('mouseup', (e) => {
        console.log('mouseup', e);


        isResizing = false;
        document.body.style.cursor = 'default';
        col3.style.pointerEvents = 'auto'; // re-enable Leaflet
        map.invalidateSize(); // fix Leaflet map rendering after resize
    });
}

async function showNewSite() {

    const props = {
        title: 'Add Your First Site',
        url: '/Grow/Locations/LoadLocation',
        data: { type: 'firstSite' }
    }

    await popupHandler.loadPopup(props).then(() => locFormUtil.setFormListeners());
}
export const locFormUtil = {
    setFormListeners: function () {
        $(document).off('submit').on('submit', $(`#locForm`), function (event) {
            event.preventDefault();
            locFormUtil.onSubmitForm($('#locForm')) // submit form
        });

        $(document).off('click', '.delete-btn').on('click', '.delete-btn', function () {
            const id = $(this).data('id');
            const type = $(this).data('type')
            onDelete(id, type);
        })
        formUtil.setListeners('#locForm');
        locFormUtil.setListeners();
    },
    setColorPicker(div, attr) {

    },
    setListeners: function () {
        $('#Name').on('input', function () {
            $('#Address_Name').val($(this).val()).change();
        })
    },
    onSubmitForm: async function ($form) {

        let response = await formUtil.submitForm('#locForm');

        console.log('loc onSubmitForm response', response);
        if (response && response.success) {

            if (response.data) {
                addSiteNode(response.data)
            }

            let objType = $form.data('obj');
            let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';
            window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.msg-div') });
        }
        else {
            alert('Error! ' + response.error);
        }
    }
}

function initializeTree() {
    $('#locationTree').jstree({
        'core': {
            'data': {
                'url': './Locations/GetLocationTreeData',
                'dataType': 'json'
            }
        },
        'types': {
            'site': { 'icon': 'fa-regular fa-font-awesome' },
            'field': { 'icon': 'fas fa-tractor' },
            'row': { 'icon': 'bi bi-layout-split' },
            'bed': { 'icon': 'bi bi-grid-3x2-gap' },
            'plot': { 'icon': 'bi bi-grip-horizontal' },
            'greenhouse': { 'icon': 'fas fa-tractor' },
            'building': { 'icon': 'fas fa-building' },
            'room': { 'icon': 'bi bi-door-open' },
        },
        'plugins': ['types']
    });

    $('#locationTree').on("select_node.jstree", function (e, data) {
        var locationId = data.node.id;
        // do something with selected location
    });
}
function addSiteNode(data) {
    $('#locationTree').jstree().create_node(
        '#', // root
        {
            id: data.id,
            text: data.text,
            type: 'site'
        },
        'last'
    );
}