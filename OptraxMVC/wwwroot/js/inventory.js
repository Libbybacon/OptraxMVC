
var $popout;
var none = 'd-none';
var bg = 'background-color';
var $itemsTable

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

    setItemHandlers();
    makeDatatable();
});

function makeDatatable() {

    $itemsTable = $(`#cat-table`).DataTable({
        ajax: {
            type: "POST",
            url: '/Inventory/InventoryItems/GetItems/',
            dataSrc: function (data) {
                return data; 
            }
        },
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
            [2, "asc"],
            [3, "asc"]
        ],
        rowGroup: {
            dataSrc: ["cat0", "cat1"],
            // Html for group header rows - toggle buttons, colors, text
            startRender: function (rows, group, lvl) {      
                let arr = group.split('-'); // 0: Name, 1: ID, 2: HexColor

                let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i hide1`)
                let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i d-none`);
                let $btn = $('<button/>').addClass(`toggle ${lvl == 1 ? 'tgi' : ''}`).data('grp', arr[0].replace(/\s+/g, "")).append($showi).append($hidei).on('click', function () { showHide(this) });

                let $th = $('<th/>').attr('colspan', 7).append($btn)
                let $tr = $('<tr/>').attr('data-id', arr[1]).addClass(`grp-row cat${lvl}-head`)

                return lvl == 0 ? $tr.append($th.css(bg, arr[2]).append(arr[0])) : $tr.append($th.append($('<span/>').css(bg, arr[2])).append(arr[0]));
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, sortable: false },
            { className: "never", visible: false, targets: [1, 2,4] },
            { className: "all", targets: [3, 5, 6] },
            { className: "desktop", targets: [7] },
            { className: "min-tablet-l", targets: [8] },
            { sortable: false, targets: [0,1, 2, 3, 4, 5, 6, 7, 8] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'cat0' },
            { targets: 2, data: 'cat1' },
            { targets: 3, data: 'itemName', sortable: false },
            { targets: 4, data: 'itemDesc' },
            { targets: 5, data: 'brand' },
            { targets: 6, data: 'sku' },
            { targets: 7, data: 'uoM' },
            { targets: 8, data: 'stockType' },
        ],
        layout: {
            topStart: {
                buttons: [
                    {
                        text: 'Add Category',
                        className: 'add-btn table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNew('Category');
                        }
                    },
                    {
                        text: 'Add Item',
                        className: 'add-btn table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNew('Item');
                        }
                    },
                ]
            }
        },
        createdRow: function (row, data, dataIndex) {
            let arr0 = data.cat0.split('-');
            let arr1 = data.cat1.split('-');
            $(row).attr('id', 'item-' + data.itemID);
            $(row).addClass(`item-row f-xs ${arr0[0].replace(/\s+/g, "")} ${arr1[0].replace(/\s+/g, "") }`);
        },
        drawCallback: function () {
        },
    })

    $(window).on('resize', function () {
        $itemsTable.columns.adjust();
        $itemsTable.responsive.recalc();
    });
}

function showHide(btn, isItems = false) {

    let isAll = $(btn).hasClass('toggle-all');

    let grp = isAll ? '' : $(btn).data('grp').replace(/\s+/g, ""); // Remove white space from multi-word categories
    let itemClass = isAll ? '.item-row' : `.item-row.${grp}`;

    let $hidei = $(btn).find('.hide-i');
    let $showi = $(btn).find('.show-i');

    if ($(btn).hasClass('tgi')) {

        $(`.item-row.${grp}`).removeClass(none).addClass($hidei.hasClass(none) ? '' : none);

        $(btn).find('i').toggleClass('d-none');
    }
    else {

        let $children = isAll ? $('.cat1-head') : $(btn).parents('tr').nextUntil('.dtrg-level-0', '.dtrg-level-1');

        let show1 = $showi.hasClass('show1');
        let show2 = $showi.hasClass('show2');
        let hide1 = $hidei.hasClass('hide1');
        let hide2 = $hidei.hasClass('hide2');

        $(itemClass).removeClass(none).addClass(show2 ? '' : none) // Hide items

        $.each($children, function () {
            $(this).removeClass(none).addClass(hide2 ? none : ''); // Hide children
            $(this).find('.hide-i').removeClass(none).addClass(show2 ? '' : none); // Update cat1 toggle icons
            $(this).find('.show-i').removeClass(none).addClass(show2 ? none : '');
        });

        if (isAll) {
            $.each($('.cat0-head'), function () { // Update cat0 toggle icons
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
    let catIDs = $('.cat1-head').map(function () { return $(this).data('id'); }).get();

    let props = {
        url: `/Inventory/InventoryItems/Create/`,
        data: { catIDs: catIDs, classType: classType },
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

            setTimeout(function () {
                setSelectDrops()
            }, 0)
        }
    })
}

function closePopup() {
    $('#overlay').hide();
    $('#popupContent').html();
    $('#popup').hide();
}

function setItemHandlers() {

    $('.form-save').off('click').on('click', function () {
        saveItem($(this));
    })

    //$(`.add-item`).off('click').on('click', function () {
    //    addItemRow($(this))
    //});

    $(document).off('submit').on('submit', $(`#item-form`) ,function (event) {
        event.preventDefault();

        var form = document.querySelector(`#item-form`);

        if (!form.checkValidity()) {
            event.stopPropagation();
            form.reportValidity();
        }
        else {
            saveNewItem($(`#item-form`));
        }
    });
}

function saveNewItem($form) {
    let itemModel = arrayToModel($($form).serializeArray());

    $.ajax({
        url: '/Inventory/InventoryItems/CreateItem/',
        type: 'POST',
        data: { item: itemModel },
        success: function (response) {
            if (response.success) {
                let data = response.data;
                let $newRow = $itemsTable.row.add(data).draw(false);
                //setTimeout(function () {
                //    $newRow.scrollIntoView({ behavior: 'smooth', block: 'center' });
                //}, 200);
                closePopup();
                //showUpdateMessage($row.find('.popout'), true, 'f-md p-1')
            }
            else {
                //showUpdateMessage($(`#ta`), false, 'f-md p-1');
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