import { loadPartial } from './locationUtil.js';

import { formUtil } from '../utilities/form.js';
import { getMap, onMapReady } from '../map/mapState.js';
import * as tree from './locationTree.js';

const urlBase = '/Grow/Locations/';
const formID = '#locForm';
let map = null;

$(document).ready(function () {
    setResizer();
    setLocListeners();
    tree.initializeTree();
    onMapReady((loadedMap) => {
        map = loadedMap;
        console.log('map loaded');
    });
});

function setLocListeners() {

    $('#add-new-loc').on('click', function () {
        const props = { action: 'LoadCreate', data: { type: 'Field' } }
        loadPartial(props).then = () => {
            locFormUtil.setFormListeners();
        };
    })

    $('#locForm .toggle-edit').on('click', function () {
        const model = $(this).parent('.model');
        model.find('.m-toggle').toggleClass('d-none');
    });


    locFormUtil.setFormListeners(formID)
}

function setResizer() {
   
    console.log('setResizer map', map)
    const $resizer = $('#resizer');
    const col2 = document.getElementById('loc-details');
    const col3 = document.getElementById('loc-map');

    $resizer.on('mousedown', function (e) {
        map = getMap();
        e.preventDefault();
        document.body.style.cursor = 'col-resize';
        col3.style.pointerEvents = 'none';

        const resize = (e) => {
            const newWidth = e.clientX - col2.getBoundingClientRect().left;
            $('#loc-details').css('width', newWidth + 'px');
            map.invalidateSize();
        };

        const stopResize = () => {
            col3.style.pointerEvents = 'auto';
            document.body.style.cursor = 'default';
            map.invalidateSize();

            document.removeEventListener('mousemove', resize);
            document.removeEventListener('mouseup', stopResize);
        };

        document.addEventListener('mousemove', resize);
        document.addEventListener('mouseup', stopResize);
    });
}



export const locFormUtil = {
    setFormListeners: function () {
        $(formID).off('submit').on('submit', function (e) {
            e.preventDefault();
            locFormUtil.onSubmitForm() // submit form
        });

        $(formID + ' .btn-red').off('click').on('click', function () {
            const id = $(formID).data('id');
            const type = $(formID).data('type')
            onDelete(id, type);
        })

        formUtil.setListeners(formID);
        formUtil.showHideBtns(formID);

        locFormUtil.setListeners();
    },
    onSubmitForm: async function () {
        const action = $(formID).attr('action');
        const locType = $(formID + ' #LocationType').val();
        const isCreate = action && action.includes('Create');
        console.log('loc onSubmitForm objType: ', locType, ' action:', action);

        const response = await formUtil.submitForm(formID);
        console.log('loc onSubmitForm response', response);

        if (response && response.success) {

            if (isCreate) {
                var nodeData = response.data;
                $(formID + ' .m-toggle').toggleClass('d-none');
            }

            if (response.data) {
                addSiteNode(response.data)
            }


            let msgTxt = isCreate ? 'Created' : 'Updated';

            window.showMessage({ msg: `${objType} ${msgTxt}!`, css: 'success', msgdiv: $('.msg-div') });
        }
        else {
            alert('Error! ' + response.error);
        }
    },
    setListeners: function () {
        $(formID + ' #Name').on('input', function () {
            $(formID + ' #Address_Name').val($(this).val()).change();
        })
    }
}