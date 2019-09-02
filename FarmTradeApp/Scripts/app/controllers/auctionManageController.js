var AuctionManageController = function (auctionSettleService) {
    var button;

    var init = function () {
        $(".js-settle").click(settle);
    };

    var settle = function (e) {
        button = $(e.target);

        bootbox.confirm({
            title: 'Διεκπεραίωση Τρέχουσας Αγοράς',
            message: "<p>Θέλετε σίγουρα να διεκπεραιώσετε την τρέχουσα αγορά;</p>",
            size: 'large',
            buttons: {
                cancel: {
                    label: "Όχι",
                    className: 'btn-default'
                },
                confirm: {
                    label: "Ναι",
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                if (result)
                    auctionSettleService.settleAuction(done, fail);
                else
                    bootbox.hideAll();
            }
        });
    };

    var done = function () {
        bootbox.dialog({
            title: 'Διεκπεραίωση Τρέχουσας Αγοράς',
            message: "<p>Η αγορά διακπεραιώθηκε επιτυχώς!</p>",
            buttons: {
                ok: {
                    label: "Εντάξει",
                    className: 'btn-default',
                    callback: function () {
                        location.reload(true);
                    }
                }
            }
        });
    };

    var fail = function () {
        bootbox.dialog({
            title: 'Διεκπεραίωση Τρέχουσας Αγοράς',
            message: "<p>Κάτι πήγε στραβά!</p>"
        });
    };

    return {
        init: init
    }
}(AuctionSettleService);