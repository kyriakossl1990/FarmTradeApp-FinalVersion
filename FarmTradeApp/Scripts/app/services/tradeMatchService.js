var TradeMatchService = function () {

    var getUserTradeMatches = function (userId) {
        var api = "/api/tradeMatches?userid="
        var url = api.concat(userId);
        return {
            url: url,
            dataSrc: ""
        }
    };

    return {
        getUserTradeMatches: getUserTradeMatches,
    }
}();