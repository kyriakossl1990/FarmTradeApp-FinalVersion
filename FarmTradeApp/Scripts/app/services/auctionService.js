var AuctionService = function () {
    var getAuctions = function (currentYear, success, error) {
        $.ajax({
            url: "/api/auctions?year=" + currentYear,
            type: "GET",
            success: success,
            error: error
        });
    };

    return {
        getAuctions: getAuctions
    }
}();