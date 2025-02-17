$(document).ready(function () {

    var doc = $(document);

    // Toggle categories
    doc.on("click", ".toggle-btn", function () {

        var nest = $(this).siblings("ul.nested");

        if (nest.is(":visible")) {
            nest.hide();
            $(this).text("[+]");
        }
        else {
            nest.show();
            $(this).text("[-]");
        }
    });

    // Add root category
    $("#add-root-node").click(function () {
        var catName = prompt("Enter new root category name:");

        if (catName) {
            $.ajax({
                url: "/Inventory/Categories/AddAsync",
                type: "POST",
                data: { name: catName, parentID: null },
                success: function (node) {
                    $("#cat-tree").append(node);
                },
                error: function () {
                    alert("Error adding root category.");
                }
            });
        }
    });

    // Add child category
    doc.on("click", ".add-cat-btn", function () {
        var parentID = $(this).data("parent-id");
        var catName = prompt("Enter new category name:");

        if (catName) {
            $.ajax({
                url: "/Inventory/Categories/AddAsync",
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

    // Edit Category
    doc.on("click", ".edit-node", function () {
        let li = $(this).closest("li");
        li.find(".node-name, .edit-node, .delete-node").hide();
        li.find(".edit-form").show();
    });

    // Cancel Edit
    doc.on("click", ".cancel-edit", function () {
        let li = $(this).closest("li");
        li.find(".node-name, .edit-node, .delete-node").show();
        li.find(".edit-form").hide();
    });

    // Save Edit
    doc.on("click", ".save-edit", function () {
        let li = $(this).closest("li");
        let id = li.data("id");
        let newName = li.find(".edit-input").val();

        $.post("/Inventory/Categories/EditCategory", { id: id, name: newName }, function (response) {
            if (response.success) {
                li.find(".node-name").text(response.name).show();
                li.find(".edit-form").hide();
                li.find(".edit-node, .delete-node").show();
            }
        });
    });

    // Delete Category
    doc.on("click", ".delete-node", function () {
        if (!confirm("Are you sure you want to delete this category?")) return;

        let li = $(this).closest("li");
        let id = li.data("id");

        $.post("/Inventory/Categories/DeleteCategory", { id: id }, function (response) {
            if (response.success) {
                li.remove();
            }
        });
    });
});
