var MarketEntriesController = function (marketEntryService) {
    var link;

    var init = function (container) {
        $(container).on("click", ".js-remove-marketEntry", removeEntry);
    };

    var removeEntry = function (e) {
        link = $(e.target);

        var marketEntryId = link.attr("data-marketEntry-id");

        bootbox.confirm({
            title: "Αφαίρεση καταχώρισης",
            message: "<p>Είστε σίγουρος ότι θέλετε να αφαιρέσετε αυτή την καταχώριση;</p>",
            size: "large",
            buttons: {
                cancel: {
                    label: "Όχι!",
                    className: 'btn-default'
                },
                confirm: {
                    label: "Ναι",
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result)
                    marketEntryService.removeMarketEntry(marketEntryId, done, fail)
                else {
                    bootbox.hideAll();
                }
            }
        });
    };

    var done = function () {
        link.parents("tr").fadeOut(function () {
            $(this).remove();
        });
    };

    var fail = function () {
        alert("Something failed");
    };

    return {
        init: init
    };

}(MarketEntryService);