var StorageService = function () {
    var deleteStorage = function (storageId, success, fail) {
        $.ajax({
            url: "/api/storages/" + storageId,
            method: "DELETE",
            success: success,
            fail: fail
        });
    };

    var getStorages = function () {
        return {
            url: "/api/storages",
            dataSrc: ""
        }
    };

    return {
        deleteStorage: deleteStorage,
        getStorages: getStorages
    }
}();