$(document).ready(function () {

    $('#invItemsTable').dataTable({
        "paging": true,
        "ordering": true,
        "info": true,
        "searching": true
    });

    // Toggle categories
    $(document).on("click", ".toggle-btn", function () {
        var nestedList = $(this).siblings("ul.nested");

        if (nestedList.is(":visible")) {
            nestedList.hide();
            $(this).text("[+]");
        }
        else {
            nestedList.show();
            $(this).text("[-]");
        }
    });

    // Add root category
    $("#add-root-cat").click(function () {
        var catName = prompt("Enter new root category name:");

        if (catName) {
            $.ajax({
                url: "/InventoryCategory/AddCategoryAsync",
                type: "POST",
                data: { name: catName, parentID: null },
                success: function (response) {
                    $("#cat-tree").append(response);
                },
                error: function () {
                    alert("Error adding root category.");
                }
            });
        }
    });

    // Add child category
    $(document).on("click", ".add-cat-btn", function () {
        var parentID = $(this).data("parent-id");
        var catName = prompt("Enter new category name:");

        if (catName) {
            $.ajax({
                url: "/InventoryCategory/Add",
                type: "POST",
                data: { name: catName, parentID: parentID },
                success: function (response) {
                    if (parentID) {

                        $("#cat-" + parentID + " > ul").append(response); // Append category inside parent 
                    }
                    else {

                        $("#cat-tree").append(response);// Append root category to main list
                    }
                },
                error: function () {
                    alert("Error adding category.");
                }
            });
        }
    });


});