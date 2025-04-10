
var none = 'd-none';
var bg = 'background-color';
var $itemsTable;

$(function () {

    makeDatatable();

    $('.toggle-all').off('click').on('click', function () {
        showHide($(this));
    })
});

function setRowGroupHover() {
    $(document).find('.head-txt').on('mouseenter',
        function () {
            $(this).addClass('item-hover');
        }).on('mouseleave',
            function () {
                $(this).removeClass('item-hover');
            });

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

function makeRowToggleDiv(props) {
    let $hidei = $('<i/>').addClass(`bi bi-chevron-up hide-i  d-none`)
    let $showi = $('<i/>').addClass(`bi bi-chevron-down show-i ${(props.IsTop ? 'show2' : 'show1')}`);

    let $btn = $('<button/>').addClass(`toggle ${props.IsTop ? '' : 'tgi'}`)
        .data('grp', props.NameNoSpace)
        .append($showi)
        .append($hidei)
        .on('click', function () { showHide(this) });

    let $div = $('<div/>').addClass('d-flex w-100').append($btn)

    return ($div);
}


