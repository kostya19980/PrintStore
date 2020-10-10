$(document).ready(function () {
    $(".add_product").click(function () {
        //$(".product_modal_content").load("/Admin/AddProduct");
        $.ajax({
            url: "/Admin/AddProduct",
            type: 'GET',
            success: function (result) {
                $(".product_modal_content").html(result);
                location.href = "#product_modal";
                $("#product_price").keydown(function () {
                    var value = $(this).val();
                    if (value.indexOf('.')) {
                        $(this).val(value.replace('.', ","));
                    }
                })
                $.validator.methods.range = function (value, element, param) {
                    var globalizedValue = value.replace(",", ".");
                    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
                }

                $.validator.methods.number = function (value, element) {
                    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
                }
                $("#uploadImage").change(function () {
                    var image = new Image;
                    var file = this.files;
                    if (file && file[0]) {
                        var reader = new FileReader;
                        reader.readAsDataURL(file[0]);
                        reader.onload = function (file) {
                            image.src = file.target.result;
                            image.onload = function () {
                                $("#img_product_create").attr("src", image.src);
                                var width = String(image.width / 100).replace('.', ",");
                                var height = String(image.height / 100).replace('.', ",");
                                $("#Width").val(width);
                                $("#Height").val(height);
                                $("#Width").parent().children("label").attr("class", "placeholder_label_after");
                                $("#Height").parent().children("label").attr("class", "placeholder_label_after");
                            }
                        }
                    }
                });
            }
        });
    })
})