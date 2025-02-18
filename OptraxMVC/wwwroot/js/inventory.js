var showAll = false;

$(document).ready(function () {

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

    $(document).on('click', '.attr', function () {
        var $cell = $(this);

        if (!$cell.attr('contenteditable')) {
            $cell.attr('contenteditable', 'true').addClass('editing').focus();
        }
    });

    $(document).off('blur').on('blur', '.attr', function () {

        editAttribute($(this));
    });



    // Add Category
    $(".add-cat").off('click').on('click', function () {
        const categoryName = prompt("Enter new category name");
        if (categoryName) {
            $.ajax({
                url: '/Inventory/Inventory/AddCategory',
                type: 'POST',
                data: { name: categoryName },
                success: function (data) {
                    $('#category-list').append(data);
                },
                error: function () {
                    alert("Error adding category.");
                }
            });
        }
    });

    // Remove Category
    $(".remove-cat").off('click').on('click', function () {
        const categoryId = $(this).data("id");

        if (confirm("Are you sure you want to delete this category?")) {
            $.ajax({
                url: '/Inventory/InventoryCategories/Delete',
                type: 'POST',
                data: { id: categoryId },
                success: function () {
                    // Remove the category row from the table
                    $(`#category-${categoryId}`).remove();
                },
                error: function () {
                    alert("Error deleting category.");
                }
            });
        }
    });

    // Add Item
    $(".add-item").off('click').on('click', function () {
        const categoryId = $(this).data("parent-id");
        const itemName = prompt("Enter new item name");
        const itemQuantity = prompt("Enter item quantity");

        if (itemName && itemQuantity) {
            $.ajax({
                url: '/Inventory/InventoryItems/Add',
                type: 'POST',
                data: { categoryId: categoryId, name: itemName, quantity: itemQuantity },
                success: function (data) {
                    // On success, append the new item to the category
                    $(`#item-list-${categoryId}`).append(data);
                },
                error: function () {
                    alert("Error adding item.");
                }
            });
        }
    });

    // Remove Item
    $(".remove-item").off('click').on('click', function () {
        const itemId = $(this).data("id");

        if (confirm("Are you sure you want to delete this item?")) {
            $.ajax({
                url: '/Inventory/InventoryItems/Delete',
                type: 'POST',
                data: { id: itemId },
                success: function () {
                    $(`#item-${itemId}`).remove();
                },
                error: function () {
                    alert("Error deleting item.");
                }
            });
        }
    });
});

function editAttribute($cell) {

    $cell.removeAttr('contenteditable').removeClass('editing');  // Remove the contenteditable state and editing class

    var newVal = $cell.text().trim();
    var oldVal = $cell.data('val').trim();

    if (newVal === oldVal) {
        return;
    }

    var $row = $cell.closest('tr')

    var data = new FormData();
    data.append('Value', newVal);
    data.append('ID', $row.data('id'));
    data.append('Field', $cell.data('field'));
    data.append('ParentID', $row.data('parent-id'));
    data.append('ClassType', $row.data('class-type'));

    $.ajax({
        url: '/Inventory/Inventory/UpdateAttribute',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {

                $cell.data('val', newVal);
                $cell.attr('data-val', newVal); // update val data

                $cell.addClass('update-success');

                setTimeout(function () { $cell.removeClass('update-success'); }, 1000);
            }
            else {
                alert('Update failed: ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error updating field:', error);
            alert('An error occurred while saving the changes.');
        }
    });
}

