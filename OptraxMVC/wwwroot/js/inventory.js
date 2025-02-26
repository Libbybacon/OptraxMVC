
var $popout;
var none = 'd-none';
var bg = 'background-color';

$(document).ready(function () {

    $(document).on('change', '.attr', function () {
        editAttribute($(this));
    });

    $('.toggle-all').off('click').on('click', function () {
        showHide($(this));
    })

    $('#popupClose').off('click').on('click', function () {
        closePopup();
    });

    //setItemHandlers();
    makeDatatable();
});

function makeDatatable() {

    let invTable = $(`#cat-table`).DataTable({
        info: false,
        paging: false,
        responsive: true,
        scrollX: false,
        scrollY: true,
        scrollY: '65vh',
        overflowY: 'auto',
        scrollCollapse: true,
        order: [
            [1, "asc"],
            [2, "asc"]
        ],
        rowGroup: {
            dataSrc: [1, 2],
            startRender: function (rows, group, level) {
                let grpArr = group.split('-');
                let is1 = level == 1;
                let colData = is1 ? 'childcol' : 'catcol'
                let id = grpArr[1];
                let grp = grpArr[0].replace(/\s+/g, "");
                let color = $(`#cat-table .item-row.${grp}`).first().data(colData) || 'var(--gray-lt)';

                let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i hide1 ${is1 ? 'item-hide' : ''}`)
                let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i d-none ${is1 ? 'item-show' : ''}`);
                let $btn = $('<button/>').addClass('toggle').data('grp', grp).append($showi).append($hidei).on('click', function () { showHide(this) });

                let $th = $('<th/>').attr('colspan', 7).append($btn)

                if (level == 0) {
                    $th.css(bg, color).append(grpArr[0])
                    return $('<tr/>').attr('data-id', id).addClass('parent-head').append($th);
                }
                if (level == 1) {
                    $btn.addClass('toggle-items');
                    return $('<tr/>').attr('data-id', id).addClass('child-head').append($th.append($('<span/>').css(bg, color)).append(grpArr[0]));
                }
            }
        },
        columnDefs: [
            { className: "dt-control", targets: 0, sortable: false },
            { className: "never", visible: false, targets: [1, 2] },
            { className: "all", targets: [3, 4, 5] },
            { className: "desktop", targets: [6] },
            { className: "min-tablet-l", targets: [7] },
            { sortable: false, targets: [1, 2, 3, 4, 5, 6, 7] }
        ],
        layout: {
            topStart: {
                buttons: [
                    {
                        text: 'New Category',
                        className: 'add-cat table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNew('Category');
                        }
                    },
                    {
                        text: 'New Item',
                        className: 'add-item table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNew('Item');
                        }
                    },
                ]
            }
        },
        initComplete: function () {
            let $span = $('<span>').addClass('add-plus').text('+')
            $('.table-btn').prepend($span);
        }
    })

    $(window).on('resize', function () {
        invTable.columns.adjust();
        invTable.responsive.recalc();
    });
}

function showHide(btn, isItems = false) {

    let isAll = $(btn).hasClass('toggle-all');

    let grp = isAll ? '' : $(btn).data('grp').replace(/\s+/g, ""); // Remove white space from multi-word categories
    let itemClass = isAll ? '.item-row' : `.item-row.${grp}`;

    let $hidei = $(btn).find('.hide-i');
    let $showi = $(btn).find('.show-i');

    if ($(btn).hasClass('toggle-items')) {

        $(`.item-row.${grp}`).removeClass(none).addClass($hidei.hasClass(none) ? '' : none);

        $(btn).find('i').toggleClass('d-none');
    }
    else {

        let $children = isAll ? $('.child-head') : $(btn).parents('tr').nextUntil('.dtrg-level-0', '.dtrg-level-1');

        let show1 = $showi.hasClass('show1');
        let show2 = $showi.hasClass('show2');
        let hide1 = $hidei.hasClass('hide1');
        let hide2 = $hidei.hasClass('hide2');

        $(itemClass).removeClass(none).addClass(show2 ? '' : none) // Hide items

        $.each($children, function () { 
            $(this).removeClass(none).addClass(hide2 ? none : ''); // Hide children
            $(this).find('.item-hide').removeClass(none).addClass(show2 ? '' : none); // Update child toggle icons
            $(this).find('.item-show').removeClass(none).addClass(show2 ? none : '');
        });

        if (isAll) {
            $.each($('.parent-head'), function () { // Update parent toggle icons
                $(this).find('.hide-i').removeClass('d-none hide1 hide2').addClass(hide1 ? 'hide2' : (show2 ? 'hide1' : none));
                $(this).find('.show-i').removeClass('d-none show1 show2').addClass(hide2 ? 'show1' : (show1 ? 'show2' : none));
            });
        }

        // Button icons
        $hidei.removeClass('d-none hide1 hide2').addClass(show2 ? 'hide1' : (hide1 ? 'hide2' : none));
        $showi.removeClass('d-none show1 show2').addClass(hide2 ? 'show1' : (show1 ? 'show2' : none));
    }
}


function addNew(classType) {
    let catIDs = $('.child-head').map(function () { return $(this).data('id'); }).get();

    let props = {
        url: '/Inventory/InventoryItems/Create/',
        data: { catIDs: catIDs },
        title: `New Inventory ${classType}`
    }
    loadPopup(props);
}

function loadPopup(props) {
    $.ajax({
        url: props.url,
        data: props.data,
        type: 'POST',
        success: function (view) {
            $('#overlay').show();
            $('#popupContent').html(view);
            $('#popupTitle').html(props.title)
            $('#popup').show();
        }
    })
}

function closePopup() {
    $('#overlay').hide();
    $('#popupContent').html();
    $('#popup').hide();
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


// Save updates whenever input value changes
function editAttribute($input) {
    var newVal = $input.val();
    var oldVal = $input.data('val');

    if (newVal === oldVal) {
        return; // Don't hit controller if no change
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
                $input.attr('data-val', newVal); 

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