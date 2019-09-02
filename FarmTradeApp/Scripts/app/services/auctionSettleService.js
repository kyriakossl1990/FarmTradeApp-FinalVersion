var AuctionSettleService = function () {
    var settleAuction = function (done, fail) {
        $.ajax({
            url: "/api/auctions",
            method: "POST"
        })
            .done(done)
            .fail(fail);
    };

    return {
        settleAuction: settleAuction
    }
}();