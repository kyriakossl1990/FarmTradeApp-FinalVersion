var MarketEntryFormValidations = function () {
    var deliveryDateValidation = function () {
        $.validator.addMethod("validdate", function (value) {
            var today = new Date();
            var fiveDays = today.setDate(today.getDate() + 5)

            return Date.parse(value) > fiveDays;
        }, "Η Ημερομηνία Παράδοσης πρέπει να είναι τουλάχιστον 5 μέρες απο σήμερα");
    };

    var entryQuantityValidation = function () {
        $.validator.addMethod("validquantity", function (value) {
            return value >= 500 && value <= 10000;
        }, "Η Ποσότητα πρέπει να είναι μεταξύ 500 - 10000 κιλών");
    };

    var deliveryLocationValidation = function () {
        $.validator.addMethod("requiredlocation", function (value) {
            return value.length > 3;
        }, "Εισάγετε τοποθεσία παράδοσης");
    };

    return {
        deliveryDateValidation: deliveryDateValidation,
        entryQuantityValidation: entryQuantityValidation,
        deliveryLocationValidation: deliveryLocationValidation
    }
}();