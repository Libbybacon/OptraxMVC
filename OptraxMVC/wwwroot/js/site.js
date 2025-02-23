function arrayToModel(arr) {
    var model = {};

    for (var i = 0; i < arr.length; i++) {

        model[arr[i]['name']] = arr[i]['value'];
    }
    return model;
}

function showUpdateMessage($parentDiv, success, classes) {

    let text = success ? "Changes Saved!" : "Error Updating";
    let classnames = (success ? "success " : "error ") + classes;
    const $div = $('<div>').text(text).addClass(classnames);

    $parentDiv.append($div);

    // make lil update message fade in then out
    $div.fadeIn(500, function () {
        setTimeout(function () {
            $div.fadeOut(500, function () {
                $div.remove();
            });
        }, 1000);
    });
}
