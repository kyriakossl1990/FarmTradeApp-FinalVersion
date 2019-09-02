var MyMarketEntriesController = function (marketEntryService, datatablesOptions) {
    var init = function (container, userId, editAction, detailsAction) {
        $(container).DataTable({
            language: datatablesOptions.languageOptions,
            ajax: marketEntryService.getUserMarketEntries(userId),
            columns: datatablesOptions.myMarketEntriesColumns(editAction, detailsAction)
        });
    };

    return {
        init: init
    };
}(MarketEntryService, DatatablesOptions);