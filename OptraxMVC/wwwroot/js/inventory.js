var isExpanded = false;
$(document).ready(function () {

    $(".toggle-btn").click(function () {
        var toggleId = $(this).data("toggle-id");
        $(this).find(".show-i").toggleClass('d-none');
        $(this).find(".show-i").toggleClass('d-none');
        $("#" + toggleId).toggle(); 
    });

    $(".toggle-all").click(function () {
        if (isExpanded) {
            $(".child-row").hide();
            $(".toggle .show-i").removeClass('d-none');
            $(".toggle .hide-i").addClass('d-none');
        }
        else {
            $(".child-row").show();
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
                url: '/InventoryCategories/Add',
                type: 'POST',
                data: { name: categoryName },
                success: function (data) {
                    // On success, append the new category to the list
                    $('#category-list').append(data);
                },
                error: function () {
                    alert("Error adding category.");
                }
            });
        }
    });

    // Edit Category
    $(".edit-category-btn").click(function () {
        const categoryId = $(this).data("id");
        const newCategoryName = prompt("Enter new category name");

        if (newCategoryName) {
            $.ajax({
                url: '/InventoryCategories/Edit',
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
    $(".remove-category-btn").click(function () {
        const categoryId = $(this).data("id");

        if (confirm("Are you sure you want to delete this category?")) {
            $.ajax({
                url: '/InventoryCategories/Delete',
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
    $(".add-item-btn").click(function () {
        const categoryId = $(this).data("parent-id");
        const itemName = prompt("Enter new item name");
        const itemQuantity = prompt("Enter item quantity");

        if (itemName && itemQuantity) {
            $.ajax({
                url: '/InventoryItems/Add',
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
    $(".edit-item-btn").click(function () {
        const itemId = $(this).data("id");
        const newItemName = prompt("Enter new item name");
        const newItemQuantity = prompt("Enter new item quantity");

        if (newItemName && newItemQuantity) {
            $.ajax({
                url: '/InventoryItems/Edit',
                type: 'POST',
                data: { id: itemId, name: newItemName, quantity: newItemQuantity },
                success: function () {
                    // Update the item details on the page
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
    $(".remove-item-btn").click(function () {
        const itemId = $(this).data("id");

        if (confirm("Are you sure you want to delete this item?")) {
            $.ajax({
                url: '/InventoryItems/Delete',
                type: 'POST',
                data: { id: itemId },
                success: function () {
                    // Remove the item row from the category
                    $(`#item-${itemId}`).remove();
                },
                error: function () {
                    alert("Error deleting item.");
                }
            });
        }
    });
});