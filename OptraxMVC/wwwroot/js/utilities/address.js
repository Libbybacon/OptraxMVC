$(document).ready(function () {
    var phone = document.querySelector('.phone');
    var maskOpts = {
        mask: '(000) 000-0000'
    };
    var mask = IMask(phone, maskOpts);
});