import { loadPartial } from './locationUtil.js';

export function initializeTree() {
    $('#locationTree').jstree({
        'core': {
            'data': {
                'url': './Locations/GetLocationTreeData',
                'dataType': 'json'
            }
        },
        'types': {
            'site': { 'icon': 'fa-regular fa-font-awesome' },
            'field': { 'icon': 'fas fa-tractor' },
            'row': { 'icon': 'bi bi-layout-split' },
            'bed': { 'icon': 'bi bi-grid-3x2-gap' },
            'plot': { 'icon': 'bi bi-grip-horizontal' },
            'greenhouse': { 'icon': 'fas fa-tractor' },
            'building': { 'icon': 'fas fa-building' },
            'room': { 'icon': 'bi bi-door-open' },
        },
        'plugins': ['types']
    });

    $('#locationTree').on("select_node.jstree", function (e, data) {
        const props = { action: 'GetDetails', data: { id: data.node.id } }
        loadPartial(props)
    });
}



function addNode(data) {
    console.log('addSiteNode');

    $('#locationTree').jstree().create_node(
        data.parent, 
        {
            id: data.id,
            text: data.text,
            type: data.type,
            children: false,
        },
        'last'
    );
}

