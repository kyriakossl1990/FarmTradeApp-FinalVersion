var DatatablesOptions = function () {
    var languageOptions = {
        lengthMenu: "Προβολή _MENU_ καταχωρίσεων",
        zeroRecords: "Δε βρέθηκαν καταχωρίσεις.",
        info: "Προβολή Σελίδας _PAGE_ από _PAGES_",
        infoEmpty: "Χωρίς περιεχόμενο",
        infoFiltered: "(φιλτράρισμα από _MAX_ αρχικές καταχωρίσεις)",
        search: "Αναζήτηση:",
        paginate:
        {
            first: "Πρώτη",
            last: "Τελευταία",
            next: "Επόμενη",
            previous: "Προηγούμενη"
        }
    };

    // My Market Entries
    var myMarketEntriesColumns = function (editAction, detailsAction) {
        return [
            {
                data: "tableId"
            },
            {
                data: "auction.auctionEndDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: "finalProduct.product.name"
            },
            {
                data: "finalProduct.quality.grade"
            },
            {
                data: "entryQuantity"
            },
            {
                data: "entryPrice",
                render: function (data) {
                    return data + "€"
                }
            },
            {
                data: "deliveryDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: "entryDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: "id",
                render: function (data, type, row) {
                    if (!row.auction.isCompleted)
                        return '<a href="' + editAction + "/" + row.id + '">Επεξεργασία</a>';
                    else
                        return "-"
                },
                orderable: false
            },
            {
                data: "id",
                render: function (data, type, row) {
                    return '<a href="' + detailsAction + "/" + row.id + '">Λεπτομέρειες</a>';
                },
                orderable: false
            },
            {
                data: "id",
                render: function (data, type, row) {
                    if (!row.auction.isCompleted)
                        return "<button class='btn-link js-remove-marketEntry' data-marketEntry-id=" + data + ">Αφαίρεση</button>"
                    else
                        return "-"
                },
                orderable: false
            }
        ];
    };

    // Market
    // Buyer Table
    var buyerColumns = function (userId, isActive, editAction) {
        return [
            {
                data: "tableId",
                render: function (data, type, row) {
                    const viewModel = {
                        userId: userId,
                        isActive: isActive === "True"
                    };

                    if (viewModel.isActive && viewModel.userId === row.userId)
                        return '<a href="' + editAction + "/" + row.id + '">' + data + '</a>';
                    else {
                        return data;
                    }
                }
            },
            {
                data: "user.companyName"
            },
            {
                data: "finalProduct.product.name"
            },
            {
                data: "finalProduct.quality.grade"
            },
            {
                data: "entryQuantity"
            },
            {
                data: "entryPrice",
                render: function (data) {
                    return data + "€"
                }
            },
            {
                data: "deliveryDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            }
        ];
    };
    var initBuyerComplete = function () {
        this.api().columns([1, 2, 3, 4, 5, 6]).every(function () {
            var column = this;

            var select = $('<select><option value="">Όλα</option></select>')
                .appendTo($("#filters").find("th").eq(column.index()))
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val());

                    column.search(val ? '^' + val + '$' : '', true, false)
                        .draw();
                });

            console.log(select);

            column.cells('', column[0]).render('display')
                .sort().unique().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
        });

    };

    // Seller Table
    var sellerColumns = function (userId, isActive, editAction) {
        return [
            {
                data: "tableId",
                render: function (data, type, row) {
                    let viewModel = {
                        userId: userId,
                        isActive: isActive === "True"
                    };

                    if (viewModel.isActive && viewModel.userId === row.userId)
                        return '<a href="' + editAction + "/" + row.id + '">' + data + '</a>';
                    else {
                        return data;
                    }
                }
            },
            {
                data: "user.firstName",
                render: function (data, type, row) {
                    return row.user.firstName + " " + row.user.lastName;
                }
            },
            {
                data: "finalProduct.product.name"
            },
            {
                data: "finalProduct.quality.grade"
            },
            {
                data: "entryQuantity"
            },
            {
                data: "entryPrice",
                render: function (data) {
                    return data + "€"
                }
            },
            {
                data: "deliveryDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            }
        ];
    };
    var initSellerComplete = function () {
        this.api().columns([1, 2, 3, 4, 5, 6]).every(function () {
            var column = this;

            var select = $('<select><option class="malakia" value="">Όλα</option></select>')
                .appendTo($("#filters2").find("th").eq(column.index()))
                .on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val());

                    column.search(val ? '^' + val + '$' : '', true, false)
                        .draw();
                });

            console.log(select);

            column.cells('', column[0]).render('display')
                .sort().unique().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
        });

    };

    var rowCallback = function (userId) {
        return function (row, data, dataIndex) {
            if (data.userId == userId)
                $(row).css('background-color', '#f5b3b37d');
        }
    };

    // Storages Table
    var storageColumns = function () {
        return [
            {
                data: "name",
                render: function (data, type, storage) {
                    return "<a style='color:#3eb16f;' href='/storages/edit/" + storage.id + "'>" + storage.name + "</a>";
                }
            },
            {
                data: "location.city"
            },
            {
                data: "street"
            },
            {
                data: "location.postalCode"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-storage-id=" + data + ">Delete</button>";
                }
            }
        ];
    };

    //My Trade Matches
    var myTradeMatchesColumns = function (userRole) {
        return [
            {
                data: "auction.auctionEndDate",
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY');
                }
            },
            {
                data: "buyerEntry.finalProduct.product.name"
            },
            {
                data: "buyerEntry.finalProduct.quality.grade",
                render: function (data) {
                    $('td').css('text-align', 'center');
                    return data;
                }

            },
            {
                data: userRole === "buyer" ? "sellerEntry.user.fullName" : "buyerEntry.user.companyName"
            },
            {
                data: "quantityExecuted"
            },
            {
                data: "priceExecuted",
                render: function (data) {
                    return data + "€"
                }
            },
            {
                data: "tradeSummary.isPaid",
                render: function (data) {
                    if (!data) {
                        return "Εκκρεμεί";
                    }
                    else {
                        $(td).css('color', 'green');
                        return "Ολοκληρώθηκε";
                    }
                }
            },
            {
                data: "tradeSummary.isDelivered",
                render: function (data, row) {
                    if (data == false) {
                        return "Εκκρεμεί";
                    }
                    else {
                        return "Ολοκληρώθηκε"
                    }
                }
            },
        ]
    }

    return {
        languageOptions: languageOptions,
        myMarketEntriesColumns: myMarketEntriesColumns,
        buyerColumns: buyerColumns,
        sellerColumns: sellerColumns,
        initBuyerComplete: initBuyerComplete,
        initSellerComplete: initSellerComplete,
        rowCallback: rowCallback,
        storageColumns: storageColumns,
        myTradeMatchesColumns: myTradeMatchesColumns
    }

}();



