var MarketController = function (marketEntryService, datatablesOptions, auctionService, monthsFeature) {
    var buyersInit = function (container, auctionId, userId, isActive, editAction) {
        $(container).DataTable({
            language: datatablesOptions.languageOptions,
            ajax: marketEntryService.getActiveBuyerMarketEntries(auctionId),
            columns: datatablesOptions.buyerColumns(userId, isActive, editAction),
            initComplete: datatablesOptions.initBuyerComplete,
            rowCallback: datatablesOptions.rowCallback(userId)
        });
    };

    var sellersInit = function (container, auctionId, userId, isActive, editAction) {
        $(container).DataTable({
            language: datatablesOptions.languageOptions,
            ajax: marketEntryService.getActiveSellerMarketEntries(auctionId),
            columns: datatablesOptions.sellerColumns(userId, isActive, editAction),
            initComplete: datatablesOptions.initSellerComplete,
            rowCallback: datatablesOptions.rowCallback(userId)
        });
    };

    var auctionsDropdown = function (currentYear, auctionId) {
        
        var success = function (data) {
            var months = monthsFeature.months(data);
            var greekMonths = monthsFeature.greekMonths;

            var option = "";

            for (var i = 0; i < months.length; i++) {
                var value = months[i];
                var month = greekMonths[value];
                option += '<option disabled>' + month + " " + currentYear + '</option>';

                for (var j = 0; j < data.length; j++) {
                    var date = new Date(data[j].auctionEndDate);
                    if (date.getMonth() === months[i]) {
                        option += '<option value="' + data[j].id + '">' + moment(data[j].auctionEndDate).subtract(1, 'seconds').format('DD/MM/YYYY') + '</option>';
                    }
                }
            }

            $("#searchAuction").html(option);
            $("#searchAuction").val(auctionId);

        }

        var error = function (data) {
            console.log("Failure")
        };

        auctionService.getAuctions(currentYear, success, error);
    };

    return {
        buyersInit: buyersInit,
        sellersInit: sellersInit,
        auctionsDropdown: auctionsDropdown
    }
}(MarketEntryService, DatatablesOptions, AuctionService, MonthsFeature);