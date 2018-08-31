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
                "data": "ISBN",
                "render": function (url, type, full) {
                    return '<a href="https://www.edelweiss.plus/#sku=' + full.rowKey + '" target="_blank">' + full.rowKey + '</a>';
                }
            },
            {
                "targets": 1,
                "data": "jacket",
                "render": function (url, type, full) {
                    return '<img src="' + full.jacketUrl + '?width=50"/>';
                }
            },
            {
                "targets": 5,
                "data": "price",
                "render": function (url, type, full) {
                    return '$' + full.price;
                }
            }
        ]
    });
});