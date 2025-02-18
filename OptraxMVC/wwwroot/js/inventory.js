var isExpanded = false;
$(document).ready(function () {

    $(document).on('click', '.editable-field', function () {
        var $cell = $(this);

        if (!$cell.attr('contenteditable')) {
            $cell.attr('contenteditable', 'true').addClass('editing').focus();
        }
    });

    $(document).off('blur').on('blur', '.attr', function () {

        var $cell = $(this);

    });


    $(".toggle-btn").off('click').on('click', function () {
        var toggleId = $(this).data("toggle-id");

        $(`#${toggleId}-btn span`).toggleClass('d-none');

        $("#" + toggleId).toggle();
    });

    $(".toggle-all").off('click').on('click', function () {
        if (isExpanded) {
            $(".items-row").hide();
            $(".toggle .show-i").removeClass('d-none');
            $(".toggle .hide-i").addClass('d-none');
        }
        else {
            $(".items-row").show();
            $(".toggle .hide-i").removeClass('d-none');
            $(".toggle .show-i").addClass('d-none');
        }

        isExpanded = !isExpanded;
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

    // Edit Category
    $(".edit-cat").off('click').on('click', function () {
        const categoryId = $(this).data("id");
        const newCategoryName = prompt("Enter new category name");

        if (newCategoryName) {
            $.ajax({
                url: '/Inventory/InventoryCategories/Edit',
                type: 'POST',
                data: { id: categoryId, name: newCategoryName },
                success: function () {
                    // Update the category name on the page
                    $(`#category-${categoryId} .category-name`).text(newCategoryName);
                },
                error: function () {
                    alert("Error editing category.");
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

    // Edit Item
    $(".edit-item").off('click').on('click', function () {
        const itemId = $(this).data("id");
        const newItemName = prompt("Enter new item name");
        const newItemQuantity = prompt("Enter new item quantity");

        if (newItemName && newItemQuantity) {
            $.ajax({
                url: '/Inventory/InventoryItems/Edit',
                type: 'POST',
                data: { id: itemId, name: newItemName, quantity: newItemQuantity },
                success: function () {
                    $(`#item-${itemId} .item-name`).text(newItemName);
                    $(`#item-${itemId} .item-quantity`).text(newItemQuantity);
                },
                error: function () {
                    alert("Error editing item.");
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

function editAttribute($cell, modelType) {

    $cell.removeAttr('contenteditable').removeClass('editing');  // Remove the contenteditable state and editing class

    var newVal = $cell.text().trim();
    var oldVal = $cell.data('val').trim();

    if (newVal === oldVal) {
        return;
    }

    var $row = $cell.closest('tr')

    var data = new FormData();
    data.append('ClassType', $row.data('class'));
    data.append('ID', $row.data('id'));
    data.append('ParentID', $row.data('parent-id'));
    data.append('Field', $cell.data('field'));

    data[field] = newValue;

    $.ajax({
        url: '/Inventory/Inventory/UpdateAttribute',
        type: 'POST',
        data: data,
        success: function (response) {
            if (response.success) {

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

