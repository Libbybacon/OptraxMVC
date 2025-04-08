﻿import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';
import choicesOpts from '../utilities/dropdown.js';

var childTypes = {
    pt: ['Species Group'],
    cn: ['Species', 'Variety', 'Cultivar'],
    species: ['Variety', 'Cultivar'],
}

const formId = '#plantForm';
const urlBase = '/Grow/Plants/';

$(document).ready(function () {
    console.log('plant.js document ready');
    initializeTree();
})

function initializeTree() {
    $('#plantTree').jstree({
        'core': {
            'data': {
                'url': function (node) {
                    if (node.id === '#') {
                        return `${urlBase}GetPlantNodes/`;
                    }
                    return `${urlBase}/GetPlantNodes?comName=${node.id}`;
                }
            }
        },
        'types': {
            'species': { 'icon': 'fa-light fa-crown' },
            'variety': { 'icon': 'bi bi-asterisk' },
            'cultivar': { 'icon': 'fa-regular fa-flask' },
            'pt': { 'icon': '' },
            'cn': { 'icon': '' }
        },
        'plugins': ['types', 'contextmenu'],
        'contextmenu': {
            'select_node': false,
            'items': plantMenu
        }
    });
}

function plantMenu(node) {
    const nodeType = node.type;
    const childOpts = childTypes[nodeType] || [];
    console.log('nodeMenu node', node, ' type ', nodeType, ' opts ', childOpts);

    const items = {};

    childOpts.forEach(type => {

        items[`add_${type}`] = {
            label: `Add ${type}`,
            action: function () {
                loadCreate(node.id, type);
            }
        }
    });

    console.log('nodeMenu items');
    return items
}

function loadCreate(parentId, type) {

    const props = { action: 'LoadCreate', data: { type: type, parentId: parentId } }

    loadPartial(props).then = () => {
        setFormListeners();
    };
}

async function loadPartial(props) {
    const response = await apiService.get(`${urlBase}${props.action}/`, props.data);
    console.log('plantjs loadPartial response', response);

    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading location', msgdiv: $('.loc-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    const view = await response.data;
    if (view) {
        $("#plant-details").html(view);
        setFormListeners();
    }
}

function setFormListeners() {

    $.each($(formId + ' .multi'), function (i, drop) {
        console.log('drop', drop)
        let drops = new choices(drop, choicesOpts);
    });

    $(formId + ' .name').on('input', function () {
        let cultName = $(formId + ' #Cultivar').val() ? $(" '" + formId + ' #Cultivar' + "'").val() : '';
        let varName = $(formId + ' #Variety').val() ? $(" var. " + formId + ' #Variety').val() : '';
        let sciName = `${$(formId + ' #Genus').val()} ${$(formId + ' #Species').val()}${varName}${cultName}`;
        $(formId + ' #ScientificName').val(sciName).change();
    })

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

async function onSubmitForm() {
    const action = $(formId).attr('action');
    const isCreate = action && action.includes('Create');
    const isGroup = action && action === 'CreateGroup';

    //console.log('loc onSubmitForm objType: ', locType, ' action:', action);

    const response = await formUtil.submitForm(formId);
    console.log('plant onSubmitForm response', response);

    if (response && response.success) {

        if (isCreate) {
            if (response.data) {
                console.log('response.data', response.data)
                $(formId + ' #Id').val(response.data.id);

                const tree = $('#plantTree').jstree(true);
                tree.create_node(response.data.parent, response.data, "last", function (newNode) {
                    //console.log('newnode:', newNode);

                    if (isGroup) {
                        $('#plant-details').html('');
                    }
                    else {
                        newNode.parents.forEach(id => {
                            tree.open_node(id);
                        });

                        tree.deselect_all();
                        tree.select_node(newNode.id);
                    }
                });
            }

        }
        $(formId + ' .m-toggle').toggleClass('d-none');

        let msgTxt = isCreate ? 'Created' : 'Updated';
        let type = isGroup ? 'Group' : 'Plant'
        window.showMessage({ msg: `${type} ${msgTxt}!`, css: 'success msg', msgdiv: $('.plant-msg') });
    }
    else {
        alert('Error! ' + response.error);
    }
}