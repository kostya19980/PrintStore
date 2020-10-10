$(document).ready(function () { 
    //Загрузка изображений и создание блоков с ними
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
                    //Блок-обертка для изображения
                    $('<div>', { class: "image_block", id: ImageName, value: 0 }).
                        prependTo('.image_list');
                    $('<img>', { src: image.src}).appendTo('#' + ImageName);
                    //кнопки удаления и копирования блока
                    $('<div>', { class: "image_event_block", id: ImageName + "Events" }).appendTo('#' + ImageName);
                    $('<a>', { href: "#" + ImageName, id: "Copy" + ImageName }).appendTo('#' + ImageName + "Events").click(function (e) {
                        //Клонируем блок с изображение и делаем его перетаскиваемым
                        var cloneNumber = parseInt($("#" + ImageName).attr("value")) + 1;
                        var cloneId = ImageName + "_" + cloneNumber;
                        var BlockWidth = $("#" + ImageName).children("img").width();
                        var BlockHeight = $("#" + ImageName).children("img").height();
                        CreateImageBlock(cloneId, BlockWidth, BlockHeight, 0, 0, image.src);
                        $("#" + ImageName).attr("value", Number($("#" + ImageName).attr("value")) + 1);
                    });
                    $('<svg width="18" height="18" viewBox="0 0 18 18" fill="none" xmlns="http://www.w3.org/2000/svg"></svg >').appendTo("#" + "Copy" + ImageName)[0]
                        .appendChild(parseSVG('<path d="M10 17L17 10M10 17V11C10 10.7348 10.1054 10.4804 10.2929 10.2929C10.4804 10.1054 10.7348 10 11 10H17M10 17H3C2.46957 17 1.96086 16.7893 1.58579 16.4142C1.21071 16.0391 1 15.5304 1 15V3C1 2.46957 1.21071 1.96086 1.58579 1.58579C1.96086 1.21071 2.46957 1 3 1H15C15.5304 1 16.0391 1.21071 16.4142 1.58579C16.7893 1.96086 17 2.46957 17 3V10" stroke="#20222D" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />'));
                    $('<a>', { href: "#delete_" + ImageName, id: "Delete" + ImageName }).appendTo('#' + ImageName + "Events").click(function (e) {
                        $("#delete_modal").attr("id", "delete_" + ImageName);
                        $(".modal_confirm_button").on("click", function (e) {
                            $("#" + ImageName).remove();
                            $("#delete_" + ImageName).attr("id", "delete_modal");
                        });
                        $(".modal_close").on("click", function (e) {
                            $(".modal_confirm_button").off("click");
                            $("#delete_" + ImageName).attr("id", "delete_modal");
                        });
                        $(".modal_cancel_button").on("click", function (e) {
                            $(".modal_confirm_button").off("click");
                            $("#delete_" + ImageName).attr("id", "delete_modal");
                        });
                    })
                    $('<svg width="18" height="20" viewBox="0 0 18 20" fill="none" xmlns="http://www.w3.org/2000/svg"></svg >').appendTo("#" + "Delete" + ImageName)[0]
                        .appendChild(parseSVG('<path d="M1 5H17M7 9V15M11 9V15M2 5L3 17C3 17.5304 3.21071 18.0391 3.58579 18.4142C3.96086 18.7893 4.46957 19 5 19H13C13.5304 19 14.0391 18.7893 14.4142 18.4142C14.7893 18.0391 15 17.5304 15 17L16 5M6 5V2C6 1.73478 6.10536 1.48043 6.29289 1.29289C6.48043 1.10536 6.73478 1 7 1H11C11.2652 1 11.5196 1.10536 11.7071 1.29289C11.8946 1.48043 12 1.73478 12 2V5" stroke="#20222D" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>'));
                }
            }
        }
    })
})
//Чтение изображений
function readImage(file) {
    var reader = new FileReader;
    var image = new Image;
    reader.readAsDataURL(file);
    reader.onload = function (file) {
        image.src = file.target.result;
    }
}
function CreateImageBlock(Id, width, height, left, top, imgSrc) {
    $("<div>", { width: width, height: height, id: Id, class: "draggable_image_block", tabindex: -1 })
        .css({
            "position":"absolute",
            "left": left + "px",
            "top": top + "px",
            "width": width + "px",
            "z-index": "auto"
        })
        .click(function () {
            $(this).focus();
        })
        .focus(function () {
            deleteId = $(this).attr("id");
        })
        .blur(function () {
            deleteId = "";
        })
        .appendTo('.template');
    $("<img>", { src: imgSrc }).appendTo('#' + Id);
    BlockUi($("#" + Id));
}