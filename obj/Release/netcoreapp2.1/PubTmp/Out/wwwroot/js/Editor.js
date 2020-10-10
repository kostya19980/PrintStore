$(document).ready(function () {
    $("#uploadImage").change(function () {
        var image = new Image;
        var file = this.files;
        if (file && file[0]) {
            var ImageName = file[0].name.split('.')[0];
            var reader = new FileReader;
            reader.readAsDataURL(file[0]);
            reader.onload = function (file) {
                image.src = file.target.result;
                image.onload = function () {
                    $('<div>', { class: "image_block", id: ImageName, width: this.width / (this.height / 72) }).prependTo('.image_list');
                    $('<img>', { src: image.src, style: 'object-fit: contain;margin-top:0.5px', width: this.width / (this.height / 71), height: "70px" }).appendTo('#' + ImageName);
                }
            }
            //$('#' + ImageName).children("img")[0].addEventListener('click', chooseImage);
        }
    })
    $("#arrow_forward").click(function () {
        for (var i = 0; i < $(".image_block").length; i++) {
            if (isVisible($(".image_block")[i]) == 1) {
                $(".image_list")[0].scrollLeft += $($(".image_block")[i]).position().left;
                break;
            }
        }
    })
    $("#arrow_back").click(function () {
        var left = 0;
        for (var i = $(".image_block").length-1; i > 0; i--) {
            if (isVisible($(".image_block")[i]) == -1) {
                console.log(i);
                $(".image_list")[0].scrollLeft -= $(".image_list").width()-left;
                break;
            }
            left = $($(".image_block")[i]).position().left;
        }
    })
})
function readImage(file) {
    var reader = new FileReader;
    var image = new Image;
    reader.readAsDataURL(file);
    reader.onload = function (file) {
        image.src = file.target.result;
    }
}
function isVisible(e) {
    var left = $(e).position().left;
    var width = $(e).width();
    if (left + width > $(".image_list").width()) {
        return 1;
    }
    else if (left<0) {
        return -1;
    }
};