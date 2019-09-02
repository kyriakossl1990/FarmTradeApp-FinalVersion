var MarketEntryService = function () {
    var removeMarketEntry = function (marketEntryId, done, fail) {
        $.ajax({
            url: "/api/marketEntries/" + marketEntryId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    var getUserMarketEntries = function (userId) {
        var api = "/api/marketEntries?userid="
        var url = api.concat(userId);
        return {
            url: url,
            dataSrc: ""
        }   
    };

    var getMarketEntry = function (marketEntryId, showDetails) {
        $.ajax({
            url: '/api/marketEntries/' + marketEntryId,
            type: 'GET',
            success: showDetails
        });
    };

    var getActiveBuyerMarketEntries = function (auctionId) {
        return {
            url: '/api/marketentries?auctionid=' + auctionId + '&type=demand',
            dataSrc: ""
        } 
    };

    var getActiveSellerMarketEntries = function (auctionId) {
        return {
            url: '/api/marketentries?auctionid=' + auctionId + '&type=supply',
            dataSrc: ""
        }
    };

    return {
        removeMarketEntry: removeMarketEntry,
        getUserMarketEntries: getUserMarketEntries,
        getMarketEntry: getMarketEntry,
        getActiveBuyerMarketEntries: getActiveBuyerMarketEntries,
        getActiveSellerMarketEntries: getActiveSellerMarketEntries
    }
}();