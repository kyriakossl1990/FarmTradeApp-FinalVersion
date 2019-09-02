var StorageController = function (storageService, datatablesOptions) {
    var initTable = function (container) {
        $(container).DataTable({
            language: datatablesOptions.languageOptions,
            ajax: storageService.getStorages(),
            columns: datatablesOptions.storageColumns()
        });
    };

    var initDelete = function (container) {
        $(container).on("click", ".js-delete", delStorage);
    };

    var delStorage = function (e) {
        var button = $(e.target);
        var storageId = button.attr("data-storage-id");

        bootbox.confirm({
            title: "Διαγραφή αποθήκης",
            message: "<p>Θέλετε σίγουρα να διαγράψετε αυτή την αποθήκη;</p>",
            size: "large",
            buttons: {
                cancel: {
                    label: "Όχι!",
                    className: 'btn-default'
                },
                confirm: {
                    label: "Ναι",
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result)
                    storageService.deleteStorage(storageId, success, fail)
                else {
                    bootbox.hideAll();
                }
            }
        });

        var success = function () {
            button.parents("tr").fadeOut(function () {
                $(this).remove();
            });
        };

        var fail = function () {
            alert("Something failed");
        };

    };

    return {
        initTable: initTable,
        initDelete: initDelete
    }
}(StorageService, DatatablesOptions);