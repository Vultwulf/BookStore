$(document).ready(function () {
    $('#book-table').DataTable({
        "processing": true,
        "ajax": {
            "url": "/api/book/",
            dataSrc: ''
        },
        "columns": [{
            "data": "rowKey"
        }, {
            "data": "jacket"
        }, {
            "data": "title"
        }, {
            "data": "series"
        }, {
            "data": "author"
        }, {
            "data": "price"
        }],
        "columnDefs": [
            {
                "targets": 0,
                "render": function (url, type, full) {
                    return '<a href="https://www.edelweiss.plus/#sku=' + full.rowKey + '" target="_blank">' + full.rowKey + '</a>';
                }
            },
            {
                "targets": 1,
                "className": 'dt-body-center'
            },
            {
                "targets": 1,
                "render": function (url, type, full) {
                    return '<img src="' + full.jacketUrl + '?width=50" title="'+full.title+'"/>';
                }
            },
            {
                "targets": 5,
                "className": 'dt-body-right',
                "render": function (url, type, full) {
                    // If there is no price, return a blank
                    if (!full.price) {
                        return "";
                    }

                    // Ensure full.price is a string, and split on decimal point
                    full.price += '';
                    x = full.price.split('.');
                    x1 = x[0];
                    x2 = x.length > 1 ? '.' + x[1] : '.00';

                    // Add thousand separater as needed
                    var rgx = /(\d+)(\d{3})/;
                    while (rgx.test(x1)) {
                        x1 = x1.replace(rgx, '$1' + ',' + '$2');
                    }

                    // Return formatted currency
                    return "$" + x1 + x2;
                }
            }
        ]
    });
});