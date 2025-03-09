var $plantsTable;
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
            [3, "asc"],
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
                    NameNoSpace: level == 0 ? name.replace(/\s+/g, "") : name,
                }
                let $tr = makeHeaderToggle(props);
                return $tr
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, sortable: false },
            {visible: false, targets: [1,2,3]},
            { className: "all", targets: [4, 5, 6,7] },
            { sortable: false, targets: [0, 1, 2, 3, 4, 5, 6,7] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'strain' },
            { targets: 2, data: 'isMother'},
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
            $(row).addClass(`item-row f-xs d-none ${data.strain.split('-')[0].replace(/\s+/g, "")} ${data.cropID.replace(/\s+/g, "") }`);

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

function makeHeaderToggle(props) {

    let $div = makeRowToggleDiv(props);
    let $txtSpan = $('<span/>').addClass('head-txt flex-fill ps-2').append(props.Name);
    $div.append($txtSpan);

    let $th = $('<th/>').attr('colspan', 7).addClass(`plant${props.Level}`).append($div);

    return $('<tr/>').attr('data-id', props.ID).addClass(`grp-row cat${props.Level}-head`).append($th);
}

function setPlantListeners() {

    $('#StartPhase').on('change', function () {
        let phase = $(this).val();
        $('#Crop_CurrentPhase').val(phase);
    });

    $('#StrainID').on('change', function () {
        let strain = $('#StrainID option:selected').text();
        $('#Crop_BatchID').removeAttr('readonly').val(strain + '-Mothers').attr('readonly', 'readonly');
    });

    $('#IsMother').off('change').on('change', function () {

        if ($(this).prop('checked') == true) {
            let strain = $('#StrainID option:selected').text();

            $('#Quantity').val(1);
            $('#MotherName').removeAttr('disabled');

            $('#Crop_Name').val('Mothers').attr('readonly', 'readonly');
            $('#Crop_BatchID').val(strain + '-Mothers').attr('readonly', 'readonly');
        }
        else {
            $('#MotherName').val('').prop('readonly', 'readonly');
            $('#Crop_Name').val('').removeAttr('readonly');
            $('#Crop_BatchID').val('').removeAttr('readonly');
        }
    });
}

function addPlants() {
    let props = {
        type: 'GET',
        url: `/Inventory/Plants/Create/`,
        title: `New Plant(s)`,
    }
    loadPopup(props);
}

function addPlantsSuccess() {

    $plantsTable.ajax.reload();
    //let data = response.data;
    //console.log('data', data);

    //$.each(data, function (d) {
    //    $plantsTable.row.add(data);
    //})
    //let newRow = $plantsTable.row.add(data).draw(false).node();

    //setTimeout(function () {

    //    let tableDiv = $(".dt-scroll-body");

    //    if (tableDiv.length) {
    //        let rowPos = $(newRow).position().top + tableDiv.scrollTop();

    //        tableDiv.animate({
    //            scrollTop: rowPos
    //        }, 500);
    //    }

    //    $(newRow).addClass("highlight");

    //    setTimeout(function () {
    //        $(newRow).removeClass("highlight");
    //    }, 5000);

    //}, 100);

    closePopup();
}