var textBlockCount = 0;
var fontFamily = [
    "Roboto",
    "Arial",
    "Helvetica",
    "Times New Roman",
    "Times",
    "Courier New",
    "Courier",
    "Verdana",
    "Georgia",
    "Palatino",
    "Garamond",
    "Bookman",
    "Comic Sans MS",
    "Trebuchet MS",
    "Arial Black",
    "Impact"]
var selectedText;
var fontSize = [8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72];
var selectedNode;
$(document).ready(function () {
    document.execCommand('defaultParagraphSeparator', false, 'div');
    for (var i = 0; i < fontFamily.length; i++) {
        $('<option>').text(fontFamily[i]).attr("value", fontFamily[i]).appendTo($(".font_family_select").children());
    }
    for (var i = 0; i < fontSize.length; i++) {
        $('<option>').text(fontSize[i]).attr("value", fontSize[i]).appendTo($(".font_size_select").children());
    }
    //Создание блока с текстом
    $("#add_text_button").on('click', function () {
        $(".template").css({ "cursor": "text" });
        $(".template").one('click', function (e) {
            var parentOffset = $(this).offset();
            var x = (e.pageX - parentOffset.left) / scale;
            var y = (e.pageY - parentOffset.top) / scale;
            $(this).css({ "cursor": "default" });
            $('<div>', { class: "text_block", id: "text_block_" + textBlockCount }).appendTo(".template").css({
                "top": y + "px",
                "left": x + "px",
            });
            BlockUi($("#text_block_" + textBlockCount));
            $("#text_block_" + textBlockCount).resizable({ disabled: true, handles: 'n, e, s, w, se, sw, nw, ne' });
            $('<div>', { class: "text_area", id: "text_area_" + textBlockCount })
                .attr('contenteditable', "true")
                .attr('placeholder', "Нажмите для редактирования")
                .one("click", function () {
                    selectElementContents(this);
                    document.execCommand('fontName', false, "Arial");
                })
                .focus(function () {
                    $(this).css({ "cursor": "text" });
                    $(this).parent().css({ "border": "1px solid #2299F9" });
                    $(this).parent().draggable("disable");
                    $(this).parent().children(".ui-resizable-handle").css({ "opacity": "1", "cursor": "default" });
                    selectedNode = $(this);
                    deleteId = $(this).parent().attr("id");
                })
                .blur(function () {
                    $(this).css({ "cursor": "pointer" });
                    $(this).parent().css({ "border": "none" });
                    $(this).parent().mousedown(function () {
                        $(this).css({ "border": "1px dashed black" });
                    });
                    $(this).parent().draggable("enable");
                    $(this).parent().children(".ui-resizable-handle").css({ "opacity": "0" });
                    $(this).one("click", function () {
                        selectElementContents(this);
                    });
                    deleteId = "";
                })
                .appendTo("#text_block_" + textBlockCount);
            document.execCommand('styleWithCSS', false, true);
            textBlockCount++;
        })
    })
    $(".font_family_select").children().change(function () {
        document.execCommand('fontName', false, $(this).val());
    })
    $(".font_size_select").children().change(function () {
        setFontSize($(this).val());
    })
    $("#bold_button").click(function () {
        document.execCommand('bold', false, null);
    })
    $("#Italic_button").click(function () {
        document.execCommand('italic', false, null);
    })
    $("#Underline_button").click(function () {
        document.execCommand('underline', false, null);
    })
    $("#Align_left").click(function () {
        document.execCommand('justifyLeft', false, null);
    })
    $("#Align_center").click(function () {
        document.execCommand('justifyCenter', false, null);
    })
    $("#Align_right").click(function () {
        document.execCommand('justifyRight', false, null);
    })
    $(".editor_toolbar").click(function () {
    })
})
function setFontSize(size) {
    document.execCommand("fontSize", false, "2");
    document.execCommand('styleWithCSS', false, true);
    var nodes = $(selectedNode.find($("span")));
    for (var i = 0; i < nodes.length; i++) {
        if ($(nodes[i]).css("font-size") == "13px") {
            $(nodes[i]).css({ "font-size": size + "px" });
        }
    }
}
function selectElementContents(el) {
    var range = document.createRange();
    range.selectNodeContents(el);
    var sel = window.getSelection();
    sel.removeAllRanges();
    sel.addRange(range);
}
function CreateTextBlock() {

}

