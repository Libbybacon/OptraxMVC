
var $popout;
var none = 'd-none';
var bg = 'background-color';
var $itemsTable;


$(document).ready(function () {

    makeDatatable();

    $(document).on('change', '#top-cat-check', function () {
        if ($('#top-cat-check').prop('checked') == true) {
            $('#ParentID').attr('disabled', 'disabled');
        }
        else {
            $('#ParentID').removeAttr('disabled')
        }
    })

    $('.toggle-all').off('click').on('click', function () {
        showHide($(this));
    })
});

function makeDatatable() {
    $itemsTable = $(`#cat-table`).DataTable({
        ajax: {
            type: "POST",
            url: '/Inventory/Items/GetItems/',
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
            startRender: function (rows, group, level) {
                let arr = group.split('-'); 
                let props = {
                    Level: level,
                    IsTop: level == 0,
                    ID: arr[1],
                    Name: arr[0],
                    NameNoSpace: arr[0].replace(/\s+/g, ""),                
                    Color: arr[2],
                }

                let $tr = makeHeaderToggle(props);
                return $tr
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, sortable: false },
            { className: "never", visible: false, targets: [1, 2, 4] },
            { className: "all", targets: [3, 5, 6] },
            { className: "desktop", targets: [7] },
            { className: "min-tablet-l", targets: [8] },
            { sortable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }
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
                            addNewCategory();
                        }
                    },
                    {
                        text: 'Add Item',
                        className: 'add-btn table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNewItem();
                        }
                    },
                ]
            }
        },
        createdRow: function (row, data, dataIndex) {
            let arr0 = data.cat0.split('-');
            let arr1 = data.cat1.split('-');

            $(row).attr('id', 'item-' + data.itemID);
            $(row).addClass(`item-row f-xs ${arr0[0].replace(/\s+/g, "")} ${arr1[0].replace(/\s+/g, "")}`);

            $(row).hover(
                function () {
                    $(this).children().addClass('item-hover');
                },
                function () {
                    $(this).children().removeClass('item-hover');
                }
            );

            $(row).find('td').on('click', function () {
                getItemDetails(data);
            })
        },
        initComplete: function (settings, json) {
            setRowGroupClick();
        }
    })

    $(window).on('resize', function () {
        $itemsTable.columns.adjust();
        $itemsTable.responsive.recalc();
    });
}
function makeHeaderToggle(props) {
    let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i hide1`)
    let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i d-none`);

    let $btn = $('<button/>').addClass(`toggle ${props.IsTop ? '' : 'tgi'}`)
        .data('grp', props.NameNoSpace)
        .append($showi)
        .append($hidei)
        .on('click', function () { showHide(this) });

    let $colorIcon = $('<i/>').addClass('bi bi-square-fill m-0 me-2').css('color', props.Color)
    let $txtSpan = $('<span/>').addClass('head-txt flex-fill ps-2').append(props.Name);

    let $div = $('<div/>').addClass('d-flex w-100').append($btn)
    props.IsTop ? $div.append($txtSpan) : $div.append($colorIcon).append($txtSpan);

    let $th = $('<th/>').attr('colspan', 7).append($div);
    let $tr = $('<tr/>').attr('data-id', props.ID).addClass(`grp-row cat${props.Level}-head`)

    return props.IsTop ? $tr.append($th.css(bg, props.Color)) : $tr.append($th);
}

function setRowGroupClick() {
    $(document).find('.head-txt').hover(
        function () {
            $(this).addClass('item-hover');
        },
        function () {
            $(this).removeClass('item-hover');
        }
    );

    $(document).find('.head-txt').on('click', function () {
        getCategoryDetails($(this));
    });
}

function showHide(btn) {

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

function addNewCategory() {
    let props = {
        type: 'GET',
        url: `/Inventory/Categories/Create/`,
        title: `New Inventory Category`,
    }
    loadPopup(props);
}

function addNewItem() {
    let props = {
        type: 'GET',
        url: `/Inventory/Items/Create/`,
        title: `New Inventory Item`,
    }
    loadPopup(props);
}

function addItemSuccess(response) {

    let data = response.data;
    let newRow = $itemsTable.row.add(data).draw(false).node();

    setTimeout(function () {

        let tableDiv = $(".dt-scroll-body");

        if (tableDiv.length) {
            let rowPos = $(newRow).position().top + tableDiv.scrollTop();

            tableDiv.animate({
                scrollTop: rowPos
            }, 500);
        }

        $(newRow).addClass("highlight");

        setTimeout(function () {
            $(newRow).removeClass("highlight");
        }, 5000);

    }, 100);

    closePopup();
}

function getItemDetails(rowData) {

    let props = {
        type: 'POST',
        url: `/Inventory/Items/Details/`,
        data: { itemID: rowData.itemID },
        title: rowData.itemName,
    }
    loadPopup(props);
}

function updateItemSuccess(response) {

    let itemData = response.data;
    var row = $itemsTable.row(function (idx, data, node) {
        return data.itemID === itemData.itemID
    });

    if (row.any()) {
        tblRow = row.data(itemData).draw(false).node();
        $(tblRow).addClass("highlight");
        setTimeout(function () {
            $(tblRow).removeClass("highlight");
        }, 5000);
    }
}


function getCategoryDetails($grp) {
    let props = {
        type: 'POST',
        url: '/Inventory/Categories/Details/',
        data: { catID: $grp.parents('tr').data('id') },
        title: `Edit Category: ${$grp.text() }`
    }
    loadPopup(props);
}

function updateCategorySuccess() {
    $itemsTable.ajax.reload().draw();

    setTimeout(function () {
        setRowGroupClick();
    }, 500);
}


