var showAll = false;
var $popout;

$(document).ready(function () {

    $(document).on('change', '.attr', function () {
        editAttribute($(this));
    });

    loadToggleHandlers();
    setItemHandlers();
    makeDatatables();
});

function makeDatatables() {

    let tableID = $(this).attr('id');

    let invTable = $(`#cat-table`).DataTable({
        info: false,
        paging: false,
        responsive: true,
        scrollX: false,
        scrollY: '70vh',
        overflowY: 'auto',
        scrollCollapse: true,
        order: [
            [1, "asc"],
            [2, "asc"]
        ],
        rowGroup: {
            dataSrc: [1, 2],
            startRender: function (rows, group, level) {
                if (level == 0) {
                    var color = $(`#cat-table .${group}`).val() || 'var(--gray-md)';
                    return $('<tr/>').append(`<th colspan="7" class="parent-head" style="background-color:${color};">${group}</th>`);
                }
                if (level == 1) {
                    var childColor = $(`#cat-table .${group}`).val() || 'var(--gray-lt)';
                    return $('<tr/>').append(`<th colspan="7" class="child-head"><span class="w-25 p-1 px-5" style="background-color:${childColor};">${group}</span></th>`);
                }
            }
        },
        columnDefs: [
            { classname: "dt-control", targets: [0]},
            { classname: "never", visible: false, targets: [1, 2] },
            { classname: "all", targets: [3, 4, 5] },
            { classname: "desktop", targets: [6] },
            { classname: "min-tablet-l", targets: [7]},
        ],
    })
}

function loadToggleHandlers() {

    $(".toggle-btn").off('click').on('click', function () {
        var toggleId = $(this).data("toggle-id");

        $(`#${toggleId}-btn span`).toggleClass('d-none');

        $("#" + toggleId).toggle();
    });

    $('.toggle-cats').off('click').on('click', function () {
        $(this).parents('.top-row').nextAll('.child-row').addClass('d-none');
    })

    $(".toggle-all").off('click').on('click', function () {

        if ($(this).hasClass('all')) {
            showAll ? $(".items-row").hide() : $(".items-row").show();
            showAll ? $(".child-row").hide() : $(".child-row").show();
        }
        else {
            $(".items-row").hide()
            showAll ? $(".child-row").show() : $(".child-row").hide();
        }

        $(`.toggle .${(showAll ? 'show' : 'hide')}-i`).removeClass('d-none');
        $(`.toggle .${(showAll ? 'hide' : 'show')}-i`).addClass('d-none');

        showAll = !showAll;
    });
}

function setItemHandlers() {

    $(`.add-item`).off('click').on('click', function () {
        addItemRow($(this))
    });

    //$(`.item-row`).off('click').on('click', function (e) {
    //    e.stopPropagation();
    //    loadPopout($(this))
    //});

    // each edit cell is form that can be validated then serialized before sending - for new items
    $(`.item-form`).off('submit').on('submit', function (event) {
        event.preventDefault();

        let $row = $(this).closest('.item-row')
        let rowID = $row.attr('id');
        var form = document.querySelector(`${rowID} .item-form`);

        if (!this.checkValidity()) {
            event.stopPropagation();
            form.reportValidity();
        }
        else {
            saveNewItem($row, $(this));
        }
    });
}

function setPopoutHandler($cell) {
    $(document).off('click').on('click', function (event) {
        if (!$(event.target).closest($cell).length) {
            hidePopout($cell);
        }
    });
}

function addItemRow($btn) {
    let catID = $btn.data('catid');
    let $table = $btn.parents('.items-table')
    let $newRow = $table.find('.new-row');

    if ($newRow.length > 0) {
        loadPopout($newRow);
    }
    else {
        let $cloneRow = $table.find('.item-row').first().clone().addClass('new-row');
        $table.find('tbody').prepend($cloneRow)

        let $newRow = $table.find('tbody .new-row').first();

        $newRow.attr('id', `new-row-${catID}`)
        $newRow.data('itemid', '')

        $($newRow).unbind('click');

        $.each($newRow.find('.attr-edit'), function () {
            $(this).val('');

            $(this).attr('val', '')
            $(this).attr('data-val', '')
        })
        setItemHandlers();
        loadPopout($newRow);
    }
}

function loadPopout($row) {
    $('.item-row').off('click');

    // Going through this whole rigamarole so that the inputs layout can be more responsive than in the single row
    // Also, some columns might be hidden or truncated in smaller views, this way everything fits nicely.
    // Also it's just kind of cool.

    let isNew = $row.hasClass('new-row');
    let attrClass = isNew ? "new-attr" : "attr";
    let rowID = '#' + $($row).attr('id');

    let cats = $row.parents('.items-table').find('.cat-string').val();
    let $catsDiv = $('<div>').text(`${cats}`).addClass('cats-div w-100'); // show the categories, why not

    $row.find('.pop-row').append($catsDiv);

    // move the hidden edit inputs to edit cell
    // originally was cloning, but this way is faster and easier and removes the need for updating the orginal inputs with any new values.
    $.each($row.find('.attr-edit'), function (i, input) {

        $(input).addClass(attrClass).removeClass('attr-edit').removeClass('d-none');

        let field = $(input).attr('name');
        let $fieldDiv = $('<div>').text(field).addClass('name-div');
        let $attrDiv = $('<div>').addClass('pop-col col-xl-2 col-md-4 col-6');

        $attrDiv.append($fieldDiv).append($(input));
        $row.find('.pop-row').append($attrDiv);
    });

    if (isNew) {
        $row.find('.save-row').removeClass('d-none');
    }

    $row.find('td').addClass('d-none');
    $row.find('.edit-td').removeClass('d-none');

    $('.body').addClass('show-y'); // make page scrollable so row doesn't get cut off
    $('.cat-body').removeClass('d-block'); // allow row to overflow table borders

    $(`${rowID}`).get(0).scrollIntoView({
        behavior: 'smooth',
        block: 'center'
    });

    setTimeout(function () {
        setPopoutHandler($(rowID + ' .edit-td'))
    }, 0);

}

function hidePopout($cell) {
    let $row = $cell.parents('.item-row')
    let rowID = '#' + $row.attr('id');

    let isNew = $row.hasClass('new-row');
    let attr = isNew ? 'new-attr' : 'attr'

    // reverse everything from before.
    $row.find('.vtd').removeClass('d-none');

    $.each($(`${rowID} .${attr}`), function () {

        let field = $(this).attr('name');
        let val = $(this).data('val');

        $row.find(`.${field} .attr-txt`).html(val); // update text value
        $row.find(`.${field}`).append($(this)); // move input back to it's cell

        $(this).removeClass(attr).addClass('attr-edit').addClass('d-none');
    });

    $row.find('.pop-row').html('');
    $row.find('.edit-td').addClass('d-none');

    $('.cat-body').addClass('d-block');
    $('.body').removeClass('show-y');

    $(document).off('click'); // remove doc click event

    setItemHandlers();
}

function saveNewItem($row, $form) {
    let itemModel = arrayToModel($($form).serializeArray());
    let rowID = $row.attr('id');

    $.ajax({
        url: '/Inventory/Inventory/AddItem/',
        type: 'POST',
        data: { invItem: itemModel },
        success: function (response) {
            if (response.success) {

                let itemID = response.itemID;
                rowID = `item-${itemID}`;

                // update row, cell and input IDs & classes
                $row.attr('id', rowID);
                $row.data('itemid', `${itemID}`);
                $row.removeClass('new-row');

                let $inputs = $row.find('.new-attr');

                $.each($inputs, function () {
                    $(this).data('val', $(this).val());
                    $(this).attr('data-val', $(this).val());
                    $(this).addClass('attr').removeClass('new-attr');
                })

                $row.find('.save-row').addClass('d-none');

                showUpdateMessage($row.find('.popout'), true, 'f-md p-1')
                setPopoutHandler($row.find('.edit-td'));
            }
            else {
                showUpdateMessage($(`#${rowID} .popout`), false, 'f-md p-1');
                alert('Update failed: ' + response.msg);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error updating field:', error);
            alert('An error occurred while saving the changes.' + status);
        }
    });
}



function editAttribute($input) {
    var newVal = $input.val();
    var oldVal = $input.data('val');

    if (newVal === oldVal) {
        return;
    }

    var $row = $input.closest('tr');
    var id = $row.data('itemid');
    let field = $input.attr('name')

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
            $parentDiv = $input.parents('.pop-col');
            if (response.success) {

                $input.data('val', newVal);
                $input.attr('data-val', newVal); // store new val in data attr 

                showUpdateMessage($parentDiv, true);
            }
            else {
                $input.text(oldVal);
                showUpdateMessage($parentDiv, false);
                alert('Update failed: ' + response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error updating field:', error);
            alert('An error occurred while saving the changes.');
        }
    });
}




