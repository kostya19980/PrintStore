$(document).ready(function () {
    $.ajax({
        url: "/ShoppingCart/GetCartQuantity",
        success: function (result) {
            if (parseInt(result) > 0) {
                $("#shopping_cart_count").css({ "display": "flex" });
                $("#shopping_cart_count").text(result);
            }
        }
    });
    $(".delete_cart_button").click(function () {
        var itemId = $(this).val();
        $.ajax({
            url: "/ShoppingCart/RemoveFromCart",
            data: { DeleteId: itemId},
            type: 'POST',
            success: function (result) {
                if (parseInt(result.quantity) > 0) {
                    $("#shopping_cart_count").text(result.quantity);
                }
                else {
                    $("#shopping_cart_count").css({ "display": "none" });
                }
                $("#" + itemId).fadeOut();
                $("#TotalCost").text(result.total + " ₽");
                $("#TotalWithoutDiscount").text(result.total + " ₽");
                $("#quantity_confirm_block").text("Товары ("+result.quantity+")");
            }
        });
    })
    $(".cart_item").submit(function (e) {
        var formdata = new FormData($(this).get(0));
        var Data = { ItemId: $(this).attr("id") };
        formdata.forEach(function (value, key) {
            Data[key] = value;
        });
        console.log(Data);
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/ShoppingCart/CalculateCost",
            dataType: 'json',
            data: JSON.stringify(Data),
            success: function (result) {
                $("#price_" + result.id).text(result.itemPrice + " руб");
                $("#TotalCost").text(result.total + " ₽");
                $("#TotalWithoutDiscount").text(result.total + " ₽");
            }
        });
        e.preventDefault();
    })
    //////////////////Select Scripts////////////////////////
    $(".select_options").children("label").mousedown(function () {
        $(this).parent().parent().children(".select_title").children("label").text($(this).text());
        $(this).prev("input").prop("checked", true);
        var ItemId = $(this).parent().attr("cart-item-id");
        $("#" + ItemId).submit();
        console.log($(this).prev("input"));
    })
    $(".select_title").focus(function () {
        $(this).parent().css({ "box-shadow": "0px 0px 8px rgba(73, 76, 87, 0.15)" });
    })
    $(".select_title").blur(function () {
        $(this).parent().css({ "box-shadow": "none" });
    })
})