$(document).ready(function () {
    $.post("/UserDetail/GetUserImage",
        function (data) {
            if (data == "Image is null") {
                console.log(data);
            }
            else {
                $("#ProfileImg").attr('src',"data:image/jpeg;base64,"+data);
            }

        });
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
        $("#Address").prop('disabled', false);
        $("#City").prop('disabled', false);
        $("#Phone").prop('disabled', false);
        $("#FirstName").prop('disabled', false);
        $("#SecondName").prop('disabled', false);
        contactFlag = true;
    }
    else {
        $("#Address").prop('disabled', true);
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
