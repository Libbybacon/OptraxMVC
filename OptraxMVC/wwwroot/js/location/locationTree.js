import { loadCreate } from './locationUtil.js';

const levelMap = {
    site: 0,
    greenhouse: 1,
    field: 1,
    row: 2,
    bed: 3,
    plot: 4,
    building: 1,
    room: 2,
}
const childTypes = {
    site: ["Field", "Greenhouse", "Building"],
    greenhouse: ["Row"],
    field: ["Row"],
    row: ["Bed"],
    bed: ["Plot"],
    plot: [],
    building: ["Room"],
    room: [],
};

export function initializeTree() {
    $('#locationTree').jstree({
        'core': {
            'data': {
                'url': './Locations/GetLocationTreeData',
                'dataType': 'json'
            },
            "check_callback": true
        },
        'types': {
            'site': { 'icon': 'fa-regular fa-font-awesome' },
            'field': { 'icon': 'fas fa-tractor' },
            'row': { 'icon': 'bi bi-layout-split' },
            'bed': { 'icon': 'bi bi-grid-3x2-gap' },
            'plot': { 'icon': 'bi bi-grip-horizontal' },
            'greenhouse': { 'icon': 'bi bi-house' },
            'building': { 'icon': 'fas fa-building' },
            'room': { 'icon': 'bi bi-door-open' },
        },
        'plugins': ['types', 'contextmenu'],
        'contextmenu': {
            'select_node': false,
            'items': nodeMenu,
        }

    });

    //for (const [chType, chLevel] of Object.entries(levelMap)) {
    //    for (const [parType, parLevel] of Object.entries(levelMap)) {
    //        if (chLevel === parLevel + 1) {
    //            if (!childTypes[parType]) childTypes[parType] = [];
    //            childTypes[parType].push(chType);
    //        }
    //    }
    //}
}

export function nodeMenu(node) {
   
    const nodeType = node.type;
    const childOpts = childTypes[nodeType] || [];
    console.log('nodeMenu node', node, ' type ', nodeType, ' opts ', childOpts);

    const items = {};

    childOpts.forEach(type => {
 
        items[`add_${type}`] = {
            label: `Add ${type}`,
            action: function () {
                loadCreate(node.id, type);
            }
        }
    });

     console.log('nodeMenu items');
    return items
}

function deleteNode(id, type) {
    const tree = $('#locationTree').jstree(true);
    const node = tree.get_node(id);
    const parentId = tree.get_parent(node)

    tree.delete_node(node);

    if (parentId != '#') {
        tree.select_node(parentId);
    }
    else {
        var firstSite = allNodes.find(node => node.type === 'site');
        if (firstSite) {
            tree.deselect_all();
            tree.select_node(firstSite.id);
        }
    }
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

