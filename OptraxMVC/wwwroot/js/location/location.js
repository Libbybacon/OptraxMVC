import { addSitePoint } from '../map/map.js';
import { getMap, onMapReady, onLayersReady } from '../map/mapState.js';
import * as tree from './locationTree.js';
import * as util from './locationUtil.js';

let map = null;

$(function () {


    tree.initializeTree(map);
    util.setLocListeners();

    onMapReady((loadedMap) => {
        map = loadedMap;
        setResizer();
    });

    onLayersReady((ready) => {
        setTimeout(() => {
            util.zoomToSite(map);
        }, 500);
    });
});

function setResizer() {
   
    //console.log('setResizer map', map)
    const $resizer = $('#resizer');
    const col2 = document.getElementById('loc-details');
    const col3 = document.getElementById('loc-map');

    $resizer.on('mousedown', function (e) {
        map = getMap();
        e.preventDefault();
        document.body.style.cursor = 'col-resize';
        col3.style.pointerEvents = 'none';

        const resize = (e) => {
            const newWidth = e.clientX - col2.getBoundingClientRect().left;
            $('#loc-details').css('width', newWidth + 'px');
            map.invalidateSize();
        };

        const stopResize = () => {
            col3.style.pointerEvents = 'auto';
            document.body.style.cursor = 'default';
            map.invalidateSize();

            document.removeEventListener('mousemove', resize);
            document.removeEventListener('mouseup', stopResize);
        };

        document.addEventListener('mousemove', resize);
        document.addEventListener('mouseup', stopResize);
    });
}

