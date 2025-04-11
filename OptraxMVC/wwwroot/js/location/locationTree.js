import { loadCreate } from './locationUtil.js';

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

export function initializeTree(map) {
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
    $('#locationTree').on('select_node.jstree', function (e, data) {
        console.log('initializeTree data', data);
        var node = data.node;

        if (node.data.lat && node.data.lng) {
            map.setView[node.data.lng, node.data.lat, 19]
        }
    });
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

