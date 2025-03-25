import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import { popupHandler } from '../utilities/popup.js';

$(document).ready(function () {

    if ($('#locations').data('hassite') === 'false') {
        showNewSite();
    }

    initializeTree();
});

function showNewSite() {

    const props = {
        title: 'Add Your First Site',
        url: '/Locations/Create/',
        data: {type: 'firstSite'}
    }

    popupHandler.loadPopup(props);
}
export const locFormUtil = {
    setFormListeners: function () {
        $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
            event.preventDefault();
            locFormUtil.onSubmitForm($('#modelForm')) // submit form
        });

        $(document).off('click', '.delete-btn').on('click', '.delete-btn', function () {
            const id = $(this).data('id');
            const type = $(this).data('type')
            onDelete(id, type);
        })
        formUtil.setListeners();
        locFormUtil.setStyleListeners();
    },
    setColorPicker(div, attr) {

    },
    setListeners: function () {

    },
    onSubmitForm: async function ($form) {

        let response = await formUtil.submitForm();

        if (response && response.success) {

            if (response.data) {
                addSiteNode(data)
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
        $('#locTree').jstree({
        'core': {
            'data': {
                'url': '/Locations/GetLocations',
                'dataType': 'json'
            }
        },
        'types': {
            'site': { 'icon': 'fas fa-building' },
            'field': { 'icon': 'fas fa-tractor' },
            'row': { 'icon': 'fas fa-tractor' },
            'bed': { 'icon': 'fas fa-tractor' },
            'plot': { 'icon': 'fas fa-tractor' },
            'greenhouse': { 'icon': 'fas fa-tractor' },
            'building': { 'icon': 'fas fa-tractor' },
            'room': { 'icon': 'fas fa-door-open' },
        },
        'plugins': ['types']
    });

    $('#locationTree').on("select_node.jstree", function (e, response) {
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