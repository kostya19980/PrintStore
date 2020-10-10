$(document).ready(function () {
    ///////////////////////////////////////////
    //AccountModalToogle
    $(".phone_input").inputmask('+7 (999) 999-99-99'/*, { jitMasking: true}*/);

    $(".modal_header_button").click(function () {
        $(this).parent().find('.modal_header_button').css({ "background": "none", "color": "#494C57" });
        $(this).css({ "background": "#FFFFFF", "color": "#FF6700" });
        if ($(this).attr("value") == "login") {
            $("#login_block").css({"display":"flex"});
            $("#register_block").css({ "display": "none" });
        }
        if ($(this).attr("value") == "register") {
            $("#login_block").css({ "display": "none" });
            $("#register_block").css({ "display": "flex" });
        }
    })
    $(".modal_header_close").click(function () {
        $(".account_modal_background").toggle();
    })
    $(".profile_a").click(function () {
        if ($(this).attr("value") =="login_register") {
            $(".account_modal_background").toggle();
            $(".account_modal_background").css({ "display": "flex" });
            $(".modal_header_button")[0].click();
        }
    })
    $("#logout_button").click(function () {
        $.ajax({
            url: "/Account/Logout",
            type: 'POST',
            success: function (result) {
                if (result == "success") {
                    location.reload();
                }
            }
        });
    })
    $(".input_block > input").change(function () {
        if ($(this).val()) {
            $(this).parent().children("label").attr("class", "placeholder_label_after");
        }
        else {
            $(this).parent().children("label").attr("class", "placeholder_label");
        }
    })
    var inputs = $(".input_block > input");
    for (var i = 0; i < inputs.length; i++) {
        if ($(inputs[i]).val()) {
            $(inputs[i]).parent().children("label").attr("class", "placeholder_label_after");
        }
    }
    $(".input_clear").mousedown(function (e) {
        e.preventDefault();
        $(this).parent().children("input").val("");
    })
    //$("input").keyup(function () {
    //    if ($(this).val()) {
    //        if ($(this).attr("id") == "phone_input") {
    //            if ($(this).val().includes('_')) {
    //                $(this).parent().children(".input_success").css({ "display": "none" });
    //            }
    //            else {
    //                $(this).parent().children(".input_success").css({ "display": "block" });
    //            }
    //        }
    //        else {
    //            $(this).parent().children(".input_success").css({ "display": "block" });
    //        }
    //    }
    //    else {
    //        $(this).parent().children(".input_success").css({ "display": "none" });
    //    }
    //})
    //$("#phone_input").focus(function () {
    //    if (!$(this).val()) {
    //        $(this).val("+7(9");
    //    }
    //})
    $(".auth_block").children("form").submit(function (e) {
        var error_summary = $(this).children(".account_form_block").children("#error_summary");
        var formdata = new FormData($(this).get(0));
        $.ajax({
                url: $(this).attr("href"),
                type: 'POST',
                data: formdata,
                processData: false,
                contentType: false,
            success: function (result) {
                if (result.error != null) { 
                    error_summary.css({ "display": "flex" });
                    error_summary.text(result.error);
                    }
                else if (result.success =="true") {
                    location.reload();
                    }
            }
        });
        e.preventDefault();            
    })
    ///////////////////////////////////////
    //$.post("/UserDetail/GetUserImage",
    //    function (data) {
    //        if (data == "Image is null") {
    //            console.log(data);
    //        }
    //        else {
    //            $("#ProfileImg").attr('src',"data:image/jpeg;base64,"+data);
    //        }

    //    });
    $("#menuToggle").click(function () {
        $("#menu").toggleClass("menu-open");
        $("#renderBody").toggleClass("renderBody-open");
    });
    var dropdown = false;
    $("#dropProfile").click(function (){
        if (dropdown == false) {
            $("#DropAuth").css({ "display": "inline-block" });
            dropdown = true;
        }
        else if (dropdown == true) {
            $("#DropAuth").css({ "display": "none" });
            dropdown = false;
        }
    });
    $('#file-input').on("change", function () {
        $("#profileImageForm").submit();
    });
});
function Delete(id) {
   var table=($("#delete-" + id).attr('value'));
    $.post("/Admin/Delete", { "id": id, "table": table },
        function (data) {
            console.log(data);
            $("#" + data).remove();
        });
};
function GetUser(id) {
    $.post("/Admin/GetUser", { "id": id },
        function (data) {
            console.log(data);
            $("#Id").val(data["id"]);
            $("#Login").val(data["login"]);
            $("#Email").val(data["email"]);
            $("#Password").val(data["password"]);
            $("#RoleId").val(data["roleId"]);
            console.log($("#RoleId").val());
        });
};
function GetProduct(id) {
    $.post("/Admin/GetProduct", { "id": id },
        function (data) {
            $("#Id").val(data["id"]);
            $("#Name").val(data["name"]);
            $("#CategoryId").val(data["categoryId"]);
            $("#size").val(data["size"]);
            $("#PictureName").val(data["pictureName"]);
        });
};
var contactFlag = false;
function Contact() {
    if (contactFlag == false) {
        $("#Addresss").prop('disabled', false);
        $("#City").prop('disabled', false);
        $("#Phone").prop('disabled', false);
        $("#FirstName").prop('disabled', false);
        $("#SecondName").prop('disabled', false);
        contactFlag = true;
    }
    else {
        $("#Addresss").prop('disabled', true);
        $("#City").prop('disabled', true);
        $("#Phone").prop('disabled', true);
        $("#FirstName").prop('disabled', true);
        $("#SecondName").prop('disabled', true);
        contactFlag = false;
    }
};
 //Корзина//////////////////////////////////////
function AddToCart(id) {
    $('#update-message').removeClass('showMessage');
    $.post("/ShoppingCart/AddToCart", { "id": id },
        function (data) {
            $('#update-message').addClass('showMessage');
            $('#update-message').text(data);
        });
}
function RemoveFromCart(id) {
    $('#update-message').removeClass('showMessage');
    $.post("/ShoppingCart/RemoveFromCart", { "id": id },
        function (data) {
            $('#update-message').addClass('showMessage');
            $('#update-message').text(data);
            $("#" + id).remove();
        });
}
///////////////////////////////////////////////