import apiService from '../utilities/api.js';

const urlBase = '/Grow/Locations/';


export async function loadPartial(props) {
    const response = await apiService.get(`${urlBase}${props.action}/`, props.data);
    console.log('locjs loadPartial response', response);

    if (!response.success == true) {
        window.showMesage({ msg: 'Error loading location', msgdiv: $('.loc-msg'), css: 'error' });
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
    }

    const view = await response.data;
    $("#loc-partial").html(view);
}