let map = null;
let activeL = null;
let layersReady = false;
const subscribers = [];
const layerSubs = [];
const layerIndex = new Map();

export function setMap(newMap) {
    map = newMap;
    notifySubscribers();
}

export function onMapReady(callback) {
    if (map !== null) {
        callback(map); 
    } else {
        subscribers.push(callback);
    }
}
function notifySubscribers() {
    for (const cb of subscribers) {
        cb(map);
    }
    subscribers.length = 0;
}

export function setLayersReady(ready) {
    //console.log('setLayersReady', ready);
    layersReady = ready;
    notifyLayerSubscribers();
 }
export function onLayersReady(callback) {
    if (layersReady) {
        callBack(layersReady);
    }
    else {
        layerSubs.push(callback);
    }
}

export function notifyLayerSubscribers() {
    for (const cb of layerSubs) {
        cb(layersReady);
    }
    layerSubs.length = 0;
}

export function getMap() {
    return map;
}

export function setActive(layer) {
    activeL = layer;
}

export function getActive() {
    return activeL;
}

export function deleteActive() {
    activeL.remove();
}


export function setIndex(id, layer) {
    layerIndex.set(id, layer);
}

export function getIndex(id) {
    return layerIndex.get(id);
}

export function deleteIndex(id) {
    layerIndex.delete(id);
}

export function hasIndex(id) {
    return layerIndex.has(id);
}