var MyTradeMatchesController = function (tradeMatchService, datatablesOptions) {
    var init = function (container, userId, userRole) {
        $(container).DataTable({
            language: datatablesOptions.languageOptions,
            ajax: tradeMatchService.getUserTradeMatches(userId),
            columns: datatablesOptions.myTradeMatchesColumns(userRole),
            rowCallback: datatablesOptions.rowCallback2
        });
    };

    return {
        init: init
    };
}(TradeMatchService, DatatablesOptions);