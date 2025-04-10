import 

function makeDatatable() {
    $itemsTable = $(`#grp-table`).DataTable({
        ajax: {
            type: "POST",
            url: '/Inventory/Resources/GetResources/',
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
                    Id: arr[1],
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
            { targets: 3, data: 'resourceName', sortable: false },
            { targets: 4, data: 'resourceDesc' },
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
                        text: 'Add Resource',
                        className: 'add-btn table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addNewResource();
                        }
                    },
                ]
            }
        },
        createdRow: function (row, data, dataIndex) {
            let arr0 = data.cat0.split('-');
            let arr1 = data.cat1.split('-');

            $(row).attr('id', 'item-' + data.resourceId);
            $(row).addClass(`item-row d-none f-xs ${arr0[0].replace(/\s+/g, "")} ${arr1[0].replace(/\s+/g, "")}`);

            $(row).hover(
                function () {
                    $(this).children().addClass('item-hover');
                },
                function () {
                    $(this).children().removeClass('item-hover');
                }
            );

            $(row).find('td').on('click', function () {
                getResourceDetails(data);
            })
        },
        initComplete: function (settings, json) {
            setRowGroupHover();
        }
    })

    $(window).on('resize', function () {
        $itemsTable.columns.adjust();
        $itemsTable.responsive.recalc();
    });
}

function makeHeaderToggle(props) {

    let $div = makeRowToggleDiv(props)
    let $colorIcon = $('<i/>').addClass('bi bi-square-fill m-0 me-2').css('color', props.Color)
    let $txtSpan = $('<span/>').addClass('head-txt flex-fill ps-2').append(props.Name);

    props.IsTop ? $div.append($txtSpan) : $div.append($colorIcon).append($txtSpan);

    let $th = $('<th/>').attr('colspan', 7).append($div);
    let $tr = $('<tr/>').attr('data-id', props.Id).addClass(`grp-row cat${props.Level}-head`)

    return props.IsTop ? $tr.append($th.css(bg, props.Color)) : $tr.append($th);
}

function setCategoryListeners() {

    $(document).on('change', '#top-cat-check', function () {
        if ($('#top-cat-check').prop('checked') == true) {
            $('#ParentId').attr('disabled', 'disabled');
        }
        else {
            $('#ParentId').removeAttr('disabled')
        }
    })

    if ($('#top-cat-check').prop('checked') == true) {
        $('#ParentId').attr('disabled', 'disabled');
    }

    let colorSwatches = [
        '#FF3333',
        '#EF7A1A',
        '#F9C04D',
        '#328532',
        '#1D52D7',
        '#9E6DD9',
        '#DA6565',
        '#F9AA8A',
        '#F8DEA0',
        '#97CA91',
        '#9BB2E3',
        '#C4ADCA'
    ]
    let bwSwatches = ["#000000", "#FFFFFF"]

    $('.cat-name-edit').on('input', function () {
        $('.hex-prev').val($(this).val());
    });

    $('.color-picker').on('click', function () {
        Coloris({
            alpha: true,
            swatches: colorSwatches,
            onChange: (color) => $('.hex-prev').css('background-color', color)
        });
    });

    $('.color-picker-bw').on('click', function () {
        Coloris({
            alpha: false,
            swatches: bwSwatches,
            onChange: (color) => $('.hex-prev').css('color', color)
        });
    });
}

function addNewCategory() {
    let props = {
        type: 'GET',
        url: `/Inventory/Categories/Create/`,
        title: `New Inventory Category`,
    }
    loadPopup(props);
}

function getCategoryDetails($grp) {
    let props = {
        type: 'POST',
        url: '/Inventory/Categories/Details/',
        data: { catId: $grp.parents('tr').data('id') },
        title: `Edit Category: ${$grp.text()}`
    }
    loadPopup(props);
}

function editCategorySuccess() {
    $itemsTable.ajax.reload().draw();

    setTimeout(function () {
        setRowGroupHover();
    }, 500);
}

function addNewResource() {
    let props = {
        type: 'GET',
        url: `/Inventory/Resources/Create/`,
        title: `New Resource`,
    }
    loadPopup(props);
}

function addResourcesSuccess(response) {

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

function getResourceDetails(rowData) {

    let props = {
        type: 'POST',
        url: `/Inventory/Resources/Details/`,
        data: { rsrcId: rowData.resourceId },
        title: rowData.resourceName,
    }
    loadPopup(props);
}

function editResourceSuccess(response) {

    let resourceData = response.data;
    var row = $itemsTable.row(function (idx, data, node) {
        return data.resourceId === resourceData.resourceId
    });

    if (row.any()) {
        tblRow = row.data(resourceData).draw(false).node();
        $(tblRow).addClass("highlight");
        setTimeout(function () {
            $(tblRow).removeClass("highlight");
        }, 5000);
    }
    setTimeout(function () {
        setRowGroupHover();
    }, 500);
}