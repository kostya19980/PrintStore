var recoupLeft, recoupTop;
function dragFix(event, ui) {
    var changeLeft = ui.position.left - ui.originalPosition.left; // find change in left
    var newLeft = ui.originalPosition.left + changeLeft / scale; // adjust new left by our zoomScale

    var changeTop = ui.position.top - ui.originalPosition.top; // find change in top
    var newTop = ui.originalPosition.top + changeTop / scale; // adjust new top by our zoomScale

    ui.position.left = newLeft;
    ui.position.top = newTop;
}
function resizeFix(event, ui) {
    var changeWidth = ui.size.width - ui.originalSize.width; // find change in width
    var newWidth = ui.originalSize.width + changeWidth / scale; // adjust new width by our zoomScale

    var changeHeight = ui.size.height - ui.originalSize.height; // find change in height
    var newHeight = ui.originalSize.height + changeHeight / scale; // adjust new height by our zoomScale

    ui.size.width = newWidth;
    ui.size.height = newHeight;
    // here
    var posOrigin = ui.originalPosition;
    if (posOrigin.left !== ui.position.left) {
        ui.position.left = posOrigin.left - changeWidth / scale;
    }
    if (posOrigin.top !== ui.position.top) {
        ui.position.top = posOrigin.top - changeHeight / scale;
    }
}
function BlockUi(block) {
    block.draggable({
        stack: "div",
        start: function (event, ui) {
            move = false;
            //jumping fix
            var left = parseInt($(this).css('left'), 10);
            left = isNaN(left) ? 0 : left;
            var top = parseInt($(this).css('top'), 10);
            top = isNaN(top) ? 0 : top;
            recoupLeft = left - ui.position.left;
            recoupTop = top - ui.position.top;
        },
        drag: function (event, ui) {
            //speed fix
            dragFix(event, ui);
            //jumping fix
            ui.position.left += recoupLeft;
            ui.position.top += recoupTop;
        }
    })
        .resizable({
            resize: resizeFix,
            start: function () {
                move = false;
            },
            aspectRatio: true,
            handles: 'n, e, s, w, se, sw, nw, ne'
        })
        .find("div.ui-resizable-se").removeClass("ui-icon");
}