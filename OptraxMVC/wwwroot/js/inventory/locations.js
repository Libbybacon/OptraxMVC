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
            { className: "dt-control", data: null, targets: 0, visible: false, sortable: false },
            { sortable: false, targets: [0, 1, 2, 3] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'locationType' },
            { targets: 2, data: 'name' },
            { targets: 3, data: 'description' },
        ],
        layout: {
            topStart: {
                buttons: [
                    {
                        extend: 'collection',
                        text: 'Add Location',
                        className: 'add-btn table-btn btn-clear',
                        buttons: [
                            { text: 'Building', action: function () { addLocation('Building') } },
                            { text: 'Room', action: function () { addLocation('Room') } },
                            { text: 'Container', action: function () { addLocation('Container') } },
                            { text: 'Offsite', action: function () { addLocation('Offsite') } }
                        ]
                    }
                ]
            }
        },
        createdRow: function (row, data, dataIndex) {

            $(row).attr('id', 'item-' + data.ID);
            $(row).addClass(`item-row f-xs d-none`);

            $(row).hover(
                function () {
                    $(this).children().addClass('item-hover');
                },
                function () {
                    $(this).children().removeClass('item-hover');
                }
            );

            $(row).find('td').on('click', function () {
                getLocationDetails(data);
            })
        },
        initComplete: function (settings, json) {
            setRowGroupHover();
        }
    })

    $(window).on('resize', function () {
        $locTable.columns.adjust();
        $locTable.responsive.recalc();
    });
}

function makeHeaderToggle() {

}

function SetLocationHandlers() {
    $('#LocationType').on('change', function () {
        if ($(this).find('option:selected').text() == "Building") {
            $('.address-div').removeClass(none);
        }
        else {
            $('.address-div').addClass(none);
        }
    })
}

function addLocation(type) {
    console.log('add loc', type)
    let props = {
        type: 'GET',
        url: `/Inventory/Locations/LoadCreate/`,
        title: `New ${type} Location`,
        data: { type: type }
    }
    loadPopup(props);
}

function getLocationDetails(data) {

}