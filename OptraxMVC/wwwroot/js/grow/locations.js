﻿import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import popupHandler from '../utilities/popup.js';
import { map } from '../map/map.js';


$(document).ready(function () {
    setResizer();
    initializeTree();
    setLocListeners();
});

function setLocListeners() {
    $('#locForm .toggle-edit').on('click', function () {
        const model = $(this).closest('.model');
        model.find('.m-toggle').toggleClass('d-none');
    });

    locFormUtil.setFormListeners('#locForm')
}

function setResizer() {
    const $resizer = $('#resizer');
    const col2 = document.getElementById('loc-details');
    const col3 = document.getElementById('loc-map');
    let isResizing = false;

    $resizer.on('mousedown', function (e) {
        e.preventDefault();

        document.body.style.cursor = 'col-resize';
        col3.style.pointerEvents = 'none';

        // Mousemove
        const resize = (e) => {
            const newWidth = e.clientX - col2.getBoundingClientRect().left;
            //col2.style.width = newWidth + 'px';
            $('#loc-details').css('width', newWidth + 'px');
            map.invalidateSize();
        };

        // Mouseup
        const stopResize = () => {
            document.body.style.cursor = 'default';
            col3.style.pointerEvents = 'auto';
            map.invalidateSize();

            // Cleanup
            document.removeEventListener('mousemove', resize);
            document.removeEventListener('mouseup', stopResize);
        };

        document.addEventListener('mousemove', resize);
        document.addEventListener('mouseup', stopResize);
    });

    //resizer.on('mousedown', function (e) {
    //    e.preventDefault();
    //    isResizing = true;
    //    document.body.style.cursor = 'col-resize';
    //    col3.style.pointerEvents = 'none';
    //});

    //document.addEventListener('mousemove', (e) => {
    //    if (!isResizing) return;
    //    e.preventDefault();
    //    const newWidth = e.clientX - col2.getBoundingClientRect().left;

    //    $('#loc-details').css('width', newWidth + 'px');
    //    map.invalidateSize();
    //});

    //document.addEventListener('mouseup', (e) => {
    //    console.log('mouseup', e);
    //    if (!isResizing) return;
    //    isResizing = false;
    //    document.body.style.cursor = 'default';
    //    col3.style.pointerEvents = 'auto'; // re-enable Leaflet
    //    map.invalidateSize(); // fix Leaflet map rendering after resize
    //});
}


export const locFormUtil = {
    setFormListeners: function (formID) {
        console.log('locFormUtil setFormListeners formID', formID);
        $(formID).on('submit', function (event) {
            event.preventDefault();
            locFormUtil.onSubmitForm(formID) // submit form
        });

        $(formID + ' .delete-btn').on('click', function () {
            const id = $(formID).data('id');
            const type = $(formID).data('type')
            onDelete(id, type);
        })
        formUtil.setListeners(formID);
        locFormUtil.setListeners();
    },
    setListeners: function () {
        $('#Name').on('input', function () {
            $('#Address_Name').val($(this).val()).change();
        })
    },
    onSubmitForm: async function (formID) {
        console.log('loc onSubmitForm formID', formID);
        let response = await formUtil.submitForm(formID);

        console.log('loc onSubmitForm response', response);
        if (response && response.success) {

            if (response.data) {
                addSiteNode(response.data)
            }

            let objType = $(formID).data('obj');
            let action = $(formID).attr('action').includes('Create') ? 'Created' : 'Updated';
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