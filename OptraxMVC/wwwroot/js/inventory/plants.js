function makeDatatable() {
    $plantsTable = $(`#plant-table`).DataTable({
        ajax: {
            type: "GET",
            url: '/Inventory/Plants/GetPlants/',
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
        ],
        rowGroup: {
            dataSrc: ["strain", "cropID"],
            startRender: function (rows, group, level) {
                let name = level == 0 ? group.split('-')[0] : group;
                let props = {
                    Level: level,
                    IsTop: level == 0,
                    ID: level == 0 ? group.split('-')[1] : group,
                    Name: name,
                    NameNoSpace: name.replace(/\s+/g, ""),
                }

                let $tr = makeHeaderToggle(props);
                return $tr
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, sortable: false },
            { className: "all", targets: [3, 5, 6] },
            { sortable: false, targets: [0, 1, 2, 3, 4, 5, 6] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'strain' },
            { targets: 2, data: 'cropID' },
            { targets: 3, data: 'isMother', sortable: false },
            { targets: 4, data: 'startType' },
            { targets: 5, data: 'growthPhase' },
            { targets: 6, data: 'location' },
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
            $(row).addClass(`item-row f-xs ${data.strain.replace(/\s+/g, "")} ${data.cropID}`);

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

function makePlantHeaderToggle() {
    let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i hide1`)
    let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i d-none`);

    let $btn = $('<button/>').addClass(`toggle ${props.IsTop ? '' : 'tgi'}`)
        .data('grp', props.NameNoSpace)
        .append($showi)
        .append($hidei)
        .on('click', function () { showHide(this) });

    let $txtSpan = $('<span/>').addClass('head-txt flex-fill ps-2').append(props.Name);

    let $div = $('<div/>').addClass('d-flex w-100').append($btn).append($txtSpan)

    let $th = $('<th/>').attr('colspan', 7).append($div);

    return $('<tr/>').attr('data-id', props.ID).addClass(`grp-row cat${props.Level}-head`).append($th);

}

function addPlants() {
    let props = {
        type: 'GET',
        url: `/Inventory/Plants/Create/`,
        title: `New Inventory Category`,
    }
    loadPopup(props);
}