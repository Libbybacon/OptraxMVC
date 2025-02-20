var showAll = false;
var $popout;

$(document).ready(function () {

    $('.item-row').off('click').on('click', function (e) {
        e.stopPropagation();
        var $row = $(this).closest('tr');
        loadPopout($row)
    });


    $(".toggle-btn").off('click').on('click', function () {
        var toggleId = $(this).data("toggle-id");

        $(`#${toggleId}-btn span`).toggleClass('d-none');

        $("#" + toggleId).toggle();
    });

    $(".toggle-all").off('click').on('click', function () {

        showAll ? $(".items-row").hide() : $(".items-row").show();

        $(`.toggle .${(showAll ? 'show' : 'hide')}-i`).removeClass('d-none');
        $(`.toggle .${(showAll ? 'hide' : 'show')}-i`).addClass('d-none');

        showAll = !showAll;
    });

    $(document).on('change', '.attr', function () {
        editAttribute($(this));
    });
});

function loadPopout($row) {

    // Going through this whole rigamarole so that the inputs layout can be more responsive than in the single row
    // Also, some columns might be hidden or truncated in smaller views, this way everything fits nicely.
    // Also it's just kind of cool.

    let id = $($row).data('itemid'); // get item id

    $.each($(`#item-${id} .attr-edit`), function () {
        $(this).addClass('attr').removeClass('attr-edit').removeClass('d-none');

        let field = $(this).data('field');
        let $fieldDiv = $('<div>').text(field).addClass('name-div'); // label
        let $editDiv = $('<div>').addClass('pop-col col-xl-2 col-md-4 col-6'); // item div

        $editDiv.append($fieldDiv).append($(this)); // label and input into item div

        $(`#pop-row-${id}`).append($editDiv); // item div into row
    });

    $('.cat-body').removeClass('d-block'); // allow row to overflow table borders
    $(`#item-${id} td`).addClass('d-none');   // hide all row cells
    $(`#edit-td-${id}`).removeClass('d-none');  // show edit cell  

    $(document).off('click').on('click', function (event) {
        if (!$(event.target).closest($(`#edit-td-${id}`)).length) {
            hidePopout($(`#edit-td-${id}`))
        }
    });
}

function hidePopout($cell) {
    let id = $cell.data('id');
    
    console.log('hide', id);

    // reverse everything from before.
    $(`#item-${id} .vtd`).removeClass('d-none');

    $.each($(`#item-${id} .attr`), function () {
        let field = $(this).data('field');
        let val = $(this).data('val');

        $(`#item-${id} .${field} .attr-txt`).html(val);
        $(`#item-${id} .${field}`).append($(this));
        $(this).removeClass('attr').addClass('attr-edit').addClass('d-none');
    })
    $(`#pop-row-${id}`).html('');
    $(`#edit-td-${id}`).addClass('d-none');
    $('.cat-body').addClass('d-block');

    $(document).off('click'); // remove doc click event
}

function editAttribute($input) {
    var newVal = $input.val();
    var oldVal = $input.data('val');

    if (newVal === oldVal) {
        return;
    }

    var $row = $input.closest('tr');
    var id = $row.data('itemid');
    let field = $input.data('field')

    var data = {
        ID: id,
        Field: field,
        Value: newVal,
        ClassType: $row.data('classtype')
    }

    $.ajax({
        url: '/Inventory/Inventory/UpdateAttribute/',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {

                $input.data('val', newVal);
                $input.attr('data-val', newVal); // store new val in data attr 

                showUpdateMessage($input, true);
            }
            else {
                $input.text(oldVal);
                showUpdateMessage($input, false);
                alert('Update failed: ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error updating field:', error);
            alert('An error occurred while saving the changes.');
        }
    });
}

function showUpdateMessage($input, success) {

    let text = success ? "Changes Saved!" : "Error Updating"
    const $div = $('<div>')
        .text(text)
        .css({
            display: 'none',      
            background: success ? '##579585' : 'E72C2C',
            color: success ? '#195C4B' : 'B11E1E',
            fontSize: '10px',
            padding: '1px'
        });

    $input.parents('.pop-col').append($div);

    // make lil update message fade in then out
    $div.fadeIn(500, function () {
        setTimeout(function () {
            $div.fadeOut(500, function () {
                $div.remove();
            });
        }, 1000);
    });
}


//// Add Category
//$(".add-cat").off('click').on('click', function () {
//    const categoryName = prompt("Enter new category name");
//    if (categoryName) {
//        $.ajax({
//            url: '/Inventory/Inventory/AddCategory',
//            type: 'POST',
//            data: { name: categoryName },
//            success: function (data) {
//                $('#category-list').append(data);
//            },
//            error: function () {
//                alert("Error adding category.");
//            }
//        });
//    }
//});

//// Remove Category
//$(".remove-cat").off('click').on('click', function () {
//    const categoryId = $(this).data("id");

//    if (confirm("Are you sure you want to delete this category?")) {
//        $.ajax({
//            url: '/Inventory/InventoryCategories/Delete',
//            type: 'POST',
//            data: { id: categoryId },
//            success: function () {
//                // Remove the category row from the table
//                $(`#category-${categoryId}`).remove();
//            },
//            error: function () {
//                alert("Error deleting category.");
//            }
//        });
//    }
//});

//// Add Item
//$(".add-item").off('click').on('click', function () {
//    const categoryId = $(this).data("parent-id");
//    const itemName = prompt("Enter new item name");
//    const itemQuantity = prompt("Enter item quantity");

//    if (itemName && itemQuantity) {
//        $.ajax({
//            url: '/Inventory/InventoryItems/Add',
//            type: 'POST',
//            data: { categoryId: categoryId, name: itemName, quantity: itemQuantity },
//            success: function (data) {
//                // On success, append the new item to the category
//                $(`#item-list-${categoryId}`).append(data);
//            },
//            error: function () {
//                alert("Error adding item.");
//            }
//        });
//    }
//});

//// Remove Item
//$(".remove-item").off('click').on('click', function () {
//    const itemId = $(this).data("id");

//    if (confirm("Are you sure you want to delete this item?")) {
//        $.ajax({
//            url: '/Inventory/InventoryItems/Delete',
//            type: 'POST',
//            data: { id: itemId },
//            success: function () {
//                $(`#item-${itemId}`).remove();
//            },
//            error: function () {
//                alert("Error deleting item.");
//            }
//        });
//    }
//});