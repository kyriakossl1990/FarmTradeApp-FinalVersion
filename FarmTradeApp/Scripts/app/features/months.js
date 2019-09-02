var MonthsFeature = function () {
    function distinct(value, index, self) {
        return self.indexOf(value) === index;
    }

    var allMonths = [];

    var months = function (data) {
        for (let i = 0; i < data.length; i++) {
            var date = new Date(data[i].auctionEndDate);
            var month = date.getMonth();
            allMonths.push(month);
        }

        return allMonths.filter(distinct);
    };

    var greekMonths = ["Ιανουάριος", "Φεβρουάριος", "Μάρτιος", "Απρίλιος", "Μάιος", "Ιούνιος",
        "Ιούλιος", "Αύγουστος", "Σεπτέμβριος", "Οκτώβριος", "Νοέμβριος", "Δεκέμβριος"];

    return {
        months: months,
        greekMonths: greekMonths
    }
}();