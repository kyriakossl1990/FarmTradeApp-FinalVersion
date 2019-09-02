var MarketEntryDetailsController = function (marketEntryService) {
    var init = function (marketEntryId) {
        marketEntryService.getMarketEntry(marketEntryId, showDetails);
    };

    var showDetails = function (data) {
        $("#entryDate").html("<b>ΗΜΕΡΟΜΗΝΙΑ ΚΑΤΑΧΩΡΙΣΗΣ:</b> " + moment(data.entryDate).format('DD/MM/YYYY'));
        $("#auction").html("<b>MARKET:</b> " + moment(data.auction.auctionEndDate).format('DD/MM/YYYY'));
        $("#product").html("<b>ΠΡΟΪΟΝ:</b> " + data.finalProduct.product.name + " " + data.finalProduct.quality.grade);
        $("#quantity").html("<b>ΠΟΣΟΤΗΤΑ:</b> " + data.entryQuantity + " kg");
        $("#price").html("<b>ΤΙΜΗ</b>: " + data.entryPrice + " €");
        $("#delivery").html("<b>ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΔΟΣΗΣ:</b> " + moment(data.deliveryDate).format('DD/MM/YYYY'));
        if (data.deliveryLocation !== null)
            $("#location").html("<b>ΤΟΠΟΘΕΣΙΑ ΠΑΡΑΔΟΣΗΣ:</b> " + data.deliveryLocation);
        else
            $("#location").remove();
    };

    return {
        init: init
    }
}(MarketEntryService);