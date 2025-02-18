var isExpanded = false;
$(document).ready(function () {

    $(document).on('click', '.editable-field', function () {
        var $cell = $(this);

        if (!$cell.attr('contenteditable')) {
            $cell.attr('contenteditable', 'true').addClass('editing').focus();
        }
    });

    $(document).on('blur', '.editable-field', function () {
        var $cell = $(this);

        $cell.removeAttr('contenteditable').removeClass('editing');  // Remove the contenteditable state and editing class

        var newValue = $cell.text().trim();
        var field = $cell.data('field');
        var rowId = $cell.closest('tr').data('id');

        // Optionally, you can check here if the value actually changed before sending an update

        var data = {
            ID: rowId
        };
        data[field] = newValue;

        $.ajax({
            url: 'Inventory/Inventory/UpdateItem',
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
    });


    $(".toggle-btn").click(function () {
        var toggleId = $(this).data("toggle-id");
        $(this).find("span .show-i").toggleClass('d-none');
        $(this).find("span .hide-i").toggleClass('d-none');
        $("#" + toggleId).toggle();
    });

    $(".toggle-all").click(function () {
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
    $(".add-cat").click(function () {
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
    $(".edit-cat").click(function () {
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
    $(".remove-cat").click(function () {
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
    $(".add-item").click(function () {
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
    $(".edit-item").click(function () {
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
    $(".remove-item").click(function () {
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

$('.saveBtn').off('click').on('click', function () {
    $('#editForm').submit()
});

$("#editForm").off('submit').on('submit', function (event) {
    event.preventDefault();
    var form = document.querySelector('#editForm');

    if (!this.checkValidity()) {
        event.stopPropagation();
        form.reportValidity();
    }
    else {
        saveChanges($(this));
    }
});

function saveChanges(form) {

    var job = formToObject($(form).serializeArray());

    $.ajax({
        url: '/Jobs/Job/SaveChanges',
        type: 'POST',
        data: { job: job },
        success: function (response) {

            if (response.Success == true) {
                closeModal('edit');
                $('#jobSuccess').empty().append('Job added successfully').show().delay(3000).fadeOut();
                Table.ajax.reload();
            }
            else {
                $('.modalError').empty().append(response.Message).show().delay(5000).fadeOut();
            }
        }
    });
}

//Operator = formToObject($('#opForm').find('.itemAttr').serializeArray()); formToObject($(form).serializeArray());
function formToObject(formArray) {
    var modelObj = {};

    for (var i = 0; i < formArray.length; i++) {

        modelObj[formArray[i]['name']] = formArray[i]['value'];
    }
    return modelObj;
}