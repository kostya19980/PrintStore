var scale = 1;
var targetElement = ["", ""];
var move = false;
var deleteId = "";
$(document).ready(function () {
    $(".editor_toolbar").val(false);
    //Начальный скролинг рабочей области до середины
    $(".editor_work_space")[0].scrollLeft += ($(".hidden_layer").width() - $(".editor_work_space")[0].clientWidth) / 2;
    $(".editor_work_space")[0].scrollTop += ($(".hidden_layer").height() - $(".editor_work_space")[0].clientHeight) / 2;
//скролинг блока с изображениями
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
    var b = false;
    for (var i = $(".image_block").length - 1; i > 0; i--) {
        if (isVisible($(".image_block")[i]) == -1) {
            $(".image_list")[0].scrollLeft -= $(".image_list").width() - left;
            b = true;
            break;
        }
        left = $($(".image_block")[i]).position().left;
    }
    if (b == false) {
        $(".image_list")[0].scrollLeft -= 936;
    }
})
//Развернуть на весь экран
    var fullscreenFlag = false;
    var posLeft;
    var posTop;
$(".full_screen_button").click(function () {
    if (fullscreenFlag == false) {
        posLeft = $(".editor_block").css("Left");
        posTop = $(".editor_block").css("Top");
        $("#Render").css({ "top": "0","height":"100%"});
        $(".editor_wrapper").css({"position":"absolute","top": "0", "height":"calc(100% + 72px)","width":"100%"});
        $(".editor_block").css({ "width": "100%","height":"100%" });
        fullscreenFlag = true;
    }
    else {
        $("#Render").css({ "top": "208px" });
        $(".editor_wrapper").css({ "position": "relative","top": "37px", "width": "1128px"});
        $(".editor_block").css({ "width": "1128px", "height": "640px" });
        fullscreenFlag = false;
    }
})
//Перемещение по рабочей области
$(".editor_work_space").on("mousedown", function (e) {
    if (!$(e.target).closest(".text_area").length) {
        move = true;
        var posX_begin = e.pageX;
        var posY_begin = e.pageY;
        $(this).on("mousemove", function (e) {
            if (move == true) {
                var posX_end = e.pageX;
                var posY_end = e.pageY;
                $(this)[0].scrollLeft -= (posX_end - posX_begin) / 15;
                $(this)[0].scrollTop -= (posY_end - posY_begin) / 15;
            }
            $(this).on("mouseup", function (e) {
                move = false;
            });
            $(this).on("mouseleave", function (e) {
                move = false;
            });
        });
    }
})
$(".editor_work_space").on("mouseup", function (e) {
    $(this).off("mousemove");
});
//Масштабирование
$("#zoom_in").on("click", function () {
    if (scale < 2) {
        scale += 0.25;
        $(".template").css({ "transform": "scale(1)" });
        $(".template").css({ "transition-duration": ".5s","transform": "scale(" + scale + ")" });
        $("#zoom_info").text("Масштаб " + scale * 100 + "%");
    }
});
$("#zoom_out").on("click", function () {
    if (scale > 0.25) {
        scale -= 0.25;
        $(".template").css({ "transform": "scale(1)" });
        $(".template").css({ "transition-duration": ".5s", "transform": "scale(" + scale + ")" });
        $("#zoom_info").text("Масштаб " + scale * 100 + "%");
    }
});
    //Удаление элементов
    $("#delete_button").mousedown(function (e) {
        e.preventDefault();
        $("#" + deleteId).remove();
    })
    //отслеживаем клик вне активного элемента
    $(".editor_block").on('click', function (e) {
        if (!$(e.target).closest(targetElement).length) {
                   
        }
    });
    //сохранение
    $("#save_template").on("click", function () {
        if (type == "3d") {
            realtimeChangeTexture();
        }
        else {
            SaveTemplate(false);
        }
    });
})
function SaveTemplate() {
    var Id = $(".template").attr("id");
    var template_JSON = { templateId: Id, Width: "", Height: "", Images: [], Texture: {}, TextBlocks: [] };
    if (type == "3d") {
        var Texture = {
            TextureName: Id + TextureName,
            ModelName: ModelName,
            TextureSrc: TextureBaseUrl,
            ModelSrc: ModelSrc,
            Width: TextureWidth,
            Height: TextureHeight,
            TextureAreas: [{
                Name: TextureAreaName,
                Width: TextureAreaWidth,
                Height: TextureAreaHeight,
                Top: TextureAreaTop,
                Left: TextureAreaLeft
            }]
        }
        template_JSON.Texture = Texture;
    }
    var images = $('.template').children(".draggable_image_block");
    images.sort(function (a, b) {
        return (Number(a.style.zIndex) - Number(b.style.zIndex));
    });
    var textBlocks = $('.template').children(".text_block");
    for (var i = 0; i < images.length; i++) {
        var image_src = $(images[i]).children().attr("src");
        var image_name = $(images[i]).attr("id");
        var src_base_string = image_src.replace(/^data:image\/[a-z]+;base64,/, "");
        template_JSON.Images.push({
            name: image_name,
            src: src_base_string,
            width: $(images[i]).width(),
            height: $(images[i]).height(),
            top: $(images[i]).position().top,
            left: $(images[i]).position().left,
            Zindex: $(images[i]).css("z-index")
        });
    }
    for (var i = 0; i < textBlocks.length; i++) {
        var currentBlock = $(textBlocks[i]);
        var currentLines = $($(currentBlock.children(".text_area")).children());
        var Lines = [];
        for (var j = 0; j < currentLines.length; j++) {
            var nodes = currentLines[j].childNodes;
            Lines.push({ Text: [] });
            for (var m = 0; m < nodes.length; m++) {
                pushText(currentBlock, nodes[m], m, Lines[j].Text);
            }
        }
        template_JSON.TextBlocks.push({
            left: currentBlock.position().left,
            top: currentBlock.position().top,
            Lines: Lines,
            Zindex: currentBlock.css("z-index")
        });
    }
    template_JSON.Width = $(".template").width();
    template_JSON.Height = $(".template").height();
    console.log(template_JSON);
    template_JSON = JSON.stringify(template_JSON);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Editor/SaveTemplate",
        dataType: 'json',
        data: template_JSON,
        success: function (response) {
            console.log(response)
        }
    });
}
//Видимость элемента в блоке с изображениями
function isVisible(e) {
    var left = $(e).position().left;
    var width = $(e).width();
    if (left + width > $(".image_list").width()) {
        return 1;
    }
    else if (left < 0) {
        return -1;
    }
};
//Парсинг SVG
function parseSVG(s) {
    var div = document.createElementNS('http://www.w3.org/1999/xhtml', 'div');
    div.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg">' + s + '</svg>';
    var frag = document.createDocumentFragment();
    while (div.firstChild.firstChild)
        frag.appendChild(div.firstChild.firstChild);
    return frag;
}
function pushText(TextBlock,node,pos,objectToPush) {
    var FontFamily, FontSize, width, height, Left, Top, FontWeight, FontStyle, TextDecorationLine,TextAlign;
    var data = $(node).text();
    var parentNodes = node.parentNode.childNodes;
    var parentChildren = $(node.parentElement).children();
    //для #text
    if (node.nodeType == 3) {
        FontFamily = $(node.parentElement).css("font-family").replace(/["']/g, '');
        FontSize = parseInt($(node.parentElement).css("font-size"));
        FontWeight = $(node.parentElement).css("font-weight");
        FontStyle = $(node.parentElement).css("font-style");
        TextDecorationLine = $(node.parentElement).css("text-decoration-line");
        TextAlign = $(node.parentElement).css("text-align");
        height = $(node.parentElement).height();
        Left = TextBlock.position().left + $(node.parentElement).position().left + 1;
        Top = TextBlock.position().top + $(node.parentElement).position().top + 1;
        if (parentChildren.length) {
            if (pos > 0 && pos < parentNodes.length - 1) {
                Left += $(node.previousElementSibling).position().left + $(node.previousElementSibling).width();
                width = $(node.nextElementSibling).position().left - $(node.previousElementSibling).position().left;
            }
            if (pos == 0) {
                width = $(node.nextElementSibling).position().left - $(node.parentElement).position().left;
            }
            if (pos == parentNodes.length - 1) {
                Left = TextBlock.position().left + 1;
                Left += $(node.previousElementSibling).position().left + $(node.previousElementSibling).width();
                width = $(node.parentElement).width() -($(node.previousElementSibling).position().left + $(node.previousElementSibling).width());
            }
        }
        else {
            width = $(node.parentElement).width();
        }
        if (width >= 0 && height >= 0) {
            objectToPush.push({
                data: data, FontFamily: FontFamily, FontSize: FontSize,
                FontWeight: FontWeight, FontStyle: FontStyle, TextDecorationLine: TextDecorationLine, TextAlign: TextAlign, Left: Left, Top: Top, width: width, height: height
            });
        }
    }
    //Для Span
    if (node.nodeType == 1) {
        if (node.parentNode.nodeName == "DIV") {
            var nodes = node.childNodes;
            for (var i = 0; i < nodes.length; i++) {
                pushText(TextBlock, nodes[i], i, objectToPush);
            }
        }
        else {
            Left = TextBlock.position().left + $(node).position().left + 1;
            Top = TextBlock.position().top + $(node).position().top + 1;
            width = $(node).width();
            height = $(node).height();
            FontFamily = $(node).css("font-family").replace(/["']/g, '');
            FontWeight = $(node).css("font-weight");
            FontStyle = $(node).css("font-style");
            TextDecorationLine = $(node).css("text-decoration-line");
            TextAlign = $(node).css("text-align");
            FontSize = parseInt($(node).css("font-size"));
            if (width >= 1 && height >= 1) {
                objectToPush.push({
                    data: data, FontFamily: FontFamily, FontSize: FontSize,
                    FontWeight: FontWeight, FontStyle: FontStyle, TextDecorationLine: TextDecorationLine, TextAlign: TextAlign, Left: Left, Top: Top, width: width, height: height
                });
            }
        }
    }
}