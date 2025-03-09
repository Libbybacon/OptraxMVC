var $locTable;

function makeDatatable() {
    $locTable = $(`#loc-table`).DataTable({
        ajax: {
            type: "GET",
            url: '/Inventory/Locations/GetLocations/',
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
        ],
        rowGroup: {
            dataSrc: ["locationType"],
            startRender: function (rows, group, level) {
                let name = level == 0 ? group.split('-')[0] : group;
                let props = {
                    Level: level,
                    IsTop: level == 0,
                    ID: group,
                    Name: name,
                    NameNoSpace: name.replace(/\s+/g, ""),
                }
                let $tr = makeHeaderToggle(props);
                return $tr
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, sortable: false },
            { visible: false, targets: [1, 2, 3] },
            { className: "all", targets: [4, 5, 6, 7] },
            { sortable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'strain' },
            { targets: 2, data: 'isMother' },
            { targets: 3, data: 'cropID' },
            {
                targets: 4,
                data: null,
                render: function (data, type, row) {

                    return row.isMother ? `${row.motherName} - ${row.trackingID}` : row.trackingID;

                }
            },
            { targets: 5, data: 'startType' },
            { targets: 6, data: 'currentPhase' },
            { targets: 7, data: 'locationName' },
        ],
        layout: {
            topStart: {
                buttons: [
                    {
                        text: 'Add Plants',
                        className: 'add-btn table-btn btn-clear',
                        action: function (e, dt, node, config) {
                            addPlants();
                        }
                    }
                ]
            }
        },
        createdRow: function (row, data, dataIndex) {

            $(row).attr('id', 'item-' + data.plantID);
            $(row).addClass(`item-row f-xs d-none ${data.strain.split('-')[0].replace(/\s+/g, "")} ${data.cropID.replace(/\s+/g, "")}`);

            $(row).hover(
                function () {
                    $(this).children().addClass('item-hover');
                },
                function () {
                    $(this).children().removeClass('item-hover');
                }
            );

            $(row).find('td').on('click', function () {
                getPlantDetails(data);
            })
        },
        initComplete: function (settings, json) {
            setRowGroupHover();
        }
    })

    $(window).on('resize', function () {
        $plantsTable.columns.adjust();
        $plantsTable.responsive.recalc();
    });
}