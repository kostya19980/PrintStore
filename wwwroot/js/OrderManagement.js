var CurrentOrderId;
$(document).ready(function () {
    $(".order_number").click(function () {
        var OrderId = $(this).attr("value");
        $.ajax({
            url: "/UserProfile/GetOrderDetails",
            data: { "OrderId":OrderId },
            type: 'GET',
            success: function (result) {
                $("#" + CurrentOrderId).css({ "border": "none" });
                CurrentOrderId = OrderId;
                $(".cart_confirm_wrapper").remove();
                $(".Cart_wrapper_row").append(result);
                $("#" + OrderId).css({ "border": "1px solid #FF6700" });
            }
        });
    })
    $(".order_phone_number").click(function () {
        var UserId = $(this).attr("value");
        $.ajax({
            url: "/Admin/GetUserInfo",
            data: {"UserId": UserId},
            type: 'GET',
            success: function (result) {
                $(".cart_confirm_wrapper").remove();
                $(".Cart_wrapper_row").append(result);
            }
        });
    })
    $(".status_select").change(function () {
        var status = $(this).val();
        var OrderId = $(this).attr("order-id");
        statusColor($(this)[0], status);
        $.ajax({
            url: "/Admin/ChangeOrderStatus",
            data: { "Status": status, "OrderId": OrderId },
            type: 'POST',
            success: function () {
                alert("Статус заказа успешно изменен!");
            }
        });
    })
    $("#Status").change(function () {
        var status = $(this).val();
        statusColor($(this)[0], status);
    })
    $(".product_options_select").change(function () {
        var data = $(this).val();
        var AllOption = $(this).children("option[value='0']");
        if (data != 0) {
            AllOption.text("Все").css({ "display": "flex" });
            if ($(this).attr("id") == "filter_list") {
                $("#Email").val("").css({ "display": "none" });
                $("#Phone").val("").css({ "display": "none" });
                $("#OrderId").val("").css({ "display": "none" });
                $("#"+data).css({ "display": "flex" });
            }
        }
        else {
            var SecondName = AllOption.attr("second-name");
            AllOption.text(SecondName).css({ "display": "none" });
            if ($(this).attr("id") == "filter_list") {
                $("#Email").val("").css({ "display": "none" });
                $("#Phone").val("").css({ "display": "none" });
                $("#OrderId").val("").css({ "display": "none" });
            }
        }
    })
    $.datepicker.regional['ru'] = {
        closeText: 'Закрыть',
        prevText: 'Предыдущий',
        nextText: 'Следующий',
        currentText: 'Сегодня',
        monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн', 'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
        dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
        dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
        dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        weekHeader: 'Не',
        dateFormat: 'dd.mm.yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['ru']);
    $("#datepicker").datepicker({
        changeMonth: true,
        changeYear: true
    });
    $("#Phone").inputmask('+7 (999) 999-99-99');
})
function statusColor(elem, status) {
    if (status == 0) {
        elem.style.color = "black";
    }
    if (status == 1) {
        elem.style.color = "#fed600";
    }
    if (status == 2) {
        elem.style.color = "blue"
    }
    if (status == 3) {
        elem.style.color = "forestgreen"
    }
    if (status == 4) {
        elem.style.color = "red"
    }
}