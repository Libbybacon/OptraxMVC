//import { formUtil } from '../utilities/form.js';
//import { onCreate, onDelete} from './mapUtility.js';


//export function init() {
//    formUtil.setListeners();
//    setFormListeners();
//}

//function setFormListeners() {


//    $(document).off('submit').on('submit', $(`#modelForm`), function (event) {
//        event.preventDefault();
//        onSubmitForm($('#modelForm')) // submit form
//    });

//    $(document).off('click', '.delete-btn').on('click', '.delete-btn', function () {
//        let id = $(this).data('id');
//        let type = $(this).data('type')
//        onDelete(id, type);
//    })

//    setStyleListeners();
//}

////export function setStyleListeners() {
////    $('.icon-coll-name').on('click', function () {
////        onSelectIconCollection($(this)); // change icon collection display
////    });

////    $('.point-info').on('input', function () {
////        let props = { marker: curLayer.val, title: $('#Name').val() }// Change point's tooltip content
////        iconUtil.updateIcon(props);
////    });

////    $('.icon-div').on('click', function () {
////        onSelectIcon($(this)); // Update point icon
////    });

////    $('#clr-picker input').on('change', function () {
////        drawUtil.updateStyle('color', $('#Color').val());
////    })
////    $('#clr-color-area').on('click', function () {
////        var color = $(this).find('#clr-color-marker').css('color')
////        drawUtil.updateStyle('color', color);
////    })
////    $('#clr-swatches').on('click', function () {
////        setTimeout(() => {
////            var color = $('#clr-color-marker').css('color')
////            drawUtil.updateStyle('color', color);
////        }, 50);
////    });

////    $('#Pattern').on('change', function () {
////        var pattern = $(this).val();
////        if (pattern == 'solid') {
////            $('#DashArray').val(null).change();
////            $('#DashArray').attr('readonly', 'readonly');
////        }
////        else {
////            $('#DashArray').val('5 5').change();
////            $('#DashArray').removeAttr('readonly');
////        }
////        setTimeout(() => {
////            drawUtil.updateStyle('dashArray', $('#DashArray').val());
////        }, 50);
////    })
////    $('#Name').on('input', function () {
////        drawUtil.updateStyle('name', $('#Name').val());
////    });
////    $('#DashArray').on('input', function () {
////        drawUtil.updateStyle('dashArray', $(this).val())
////    });
////    $('#Weight').on('change', function () {
////        drawUtil.updateStyle('weight', $(this).val())
////    });
    
////}



//async function onSubmitForm($form) {

//    let response = await formUtil.submitForm();

//    if (response.success) {

//        onCreate(response);

//        let objType = $form.data('obj');
//        let action = $form.attr('action').includes('Create') ? 'Created' : 'Updated';
//        window.showMessage({ msg: `${objType} ${action}!`, css: 'success', msgdiv: $('.map-msg') });
//    }
//    else {
//        alert('Error! Invalid form...')
//    }
//}