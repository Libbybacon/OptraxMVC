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
    /*        [1, "asc"],*/
        ],
        rowGroup: {
            dataSrc: ["locationType"],
            startRender: function (rows, group, level) {
               console.log('group', group, ' level ', level)
                let props = {
                    Level: 1,
                    IsTop: level == 1,
                    ID: group,
                    Name: group,
                    NameNoSpace: group.replace(/\s+/g, ""),
                }
                return makeHeaderToggle(props);
            }
        },
        columnDefs: [
            { className: "dt-control", data: null, targets: 0, visible: false, sortable: false },
            //{ visible: false, targets: [1] }, 
            { sortable: false, targets: [0, 1, 2, 3] }
        ],
        columns: [
            { targets: 0, data: null, defaultContent: '', className: "dt-control" },
            { targets: 1, data: 'locationType', render: function () { return ''} },
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

            $(row).attr('id', 'item-' + data.id);
            $(row).addClass(`item-row f-xs ${data.locationType}`);

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

function makeHeaderToggle(props) {

    let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i  d-none`)
    let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i ${(props.IsTop ? 'show2' : 'show1')}`);

    let $btn = $('<button/>').addClass(`toggle ${props.IsTop ? '' : 'tgi'}`)
        .data('grp', props.NameNoSpace)
        .append($showi)
        .append($hidei)
        .on('click', function () { showHide(this) });

    let $div = $('<div/>').addClass('d-flex w-100').append($btn)
    let $txtSpan = $('<span/>').addClass('head-txt flex-fill ps-2').append(props.Name);
    $div.append($txtSpan);

    let $th = $('<th/>').attr('colspan', 7).addClass(`plant${props.Level}`).append($div);

    return $('<tr/>').attr('data-id', props.ID).addClass(`grp-row cat${props.Level}-head`).append($th);
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
    let props = {
        type: 'GET',
        url: `/Inventory/Locations/LoadCreate/`,
        title: `New ${type} Location`,
        data: { type: type }
    }
    loadPopup(props);
}

function addLocationSuccess(response) {
    console.log('add loc success  response', response);
    closePopup();
    let data = response.data;
    let newRow = $locTable.row.add(data).draw(false).node();

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


}

function getLocationDetails(data) {

}