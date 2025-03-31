import apiService from '../utilities/api.js';
import { formUtil } from '../utilities/form.js';

const urlBase = '/Grow/Locations/';
const formID = '#locForm';


export function loadCreate(parentID, type) {

    const props = { action: 'LoadCreate', data: { type: type, parentID: parentID } }

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
        $("#loc-partial").html(view);
        setFormListeners();
    }
}

export function setLocListeners() {
    $('#add-new-loc').on('click', function () {
        loadCreate(null, 'site');
    })

    $('#locationTree').on("select_node.jstree", function (e, data) {
        const props = { action: 'GetDetails', data: { id: data.node.id } }
        loadPartial(props)
    });
    setFormListeners();
}

export function setFormListeners() {
    $(formID + ' #Name').on('input', function () {
        $(formID + ' #Address_Name').val($(this).val()).change();
    })

    $('#LocationType').off('change').on('change', function () {

    })

    $(formID + ' locForm .toggle-edit').on('click', function () {
        const model = $(this).parent('.model');
        model.find('.m-toggle').toggleClass('d-none');
    });

    $(formID + ' .btn-red').off('click').on('click', function () {
        const id = $(formID).data('id');
        const type = $(formID).data('type')
        onDelete(id, type);
    })

    $(formID).off('submit').on('submit', function (e) {
        e.preventDefault();
        onSubmitForm() // submit form
    });

    formUtil.setListeners(formID);
    formUtil.showHideBtns(formID);
}

export async function onDelete(id, type) {



}

export async function onSubmitForm(){
    const action = $(formID).attr('action');
    const locType = $(formID + ' #LocationType').val();
    const isCreate = action && action.includes('Create');
    console.log('loc onSubmitForm objType: ', locType, ' action:', action);

    const response = await formUtil.submitForm(formID);
    console.log('loc onSubmitForm response', response);

    if (response && response.success) {

        if (isCreate) {
            if (response.data) {
                console.log('response.data', response.data)
                $(formID + ' #ID').val(response.data.id);

                const tree = $('#locationTree').jstree(true);
                tree.create_node(response.data.parent, response.data, "last", function (newNode) {
                    console.log('newnode:', newNode);
                    newNode.parents.forEach(id => {
                        tree.open_node(id);
                    });
                    tree.deselect_all();
                    tree.select_node(newNode.id);
                });
            }
           
        }
        $(formID + ' .m-toggle').toggleClass('d-none');

        let msgTxt = isCreate ? 'Created' : 'Updated';
        window.showMessage({ msg: `${locType} ${msgTxt}!`, css: 'success msg', msgdiv: $('.loc-msg') });
    }
    else {
        alert('Error! ' + response.error);
    }
}