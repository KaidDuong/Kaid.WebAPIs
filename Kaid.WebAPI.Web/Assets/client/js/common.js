var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#txtSearch").autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetProductsByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    }, success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtSearch").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtSearch").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")
            ._renderItem = function (ul, item) {
                return $("<li>").append("<a>" + item.label + "</a>")
                                .appendTo(ul);
            };
    }
};
common.init();