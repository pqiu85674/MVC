$(document).ready(function () {
    let selectValue = $('#mySelect').val();

    function getData() {
        let columns = [];
        switch (selectValue) {
            case "users":
                columns = [
                    { data: 'userId', title: "ID", orderable :true},
                    { data: 'userName', title: "使用者名稱", orderable: true },
                    { data: 'birthday', title: "出生年月日", orderable: true },
                    { data: 'email', title: "email", orderable: true },
                ];
                url = `/Home/GetUsersData`;
                break;
            case "products":
                columns = [
                    { data: 'productId', title: "ID" },
                    { data: 'productName', title: "產品名稱" },
                    { data: 'price', title: "價格" },
                ];
                url = `/Home/GetProductsData`;
                break;
            case "shopCar":
                columns = [
                    { data: 'shopCarId', title: "shopCarID" },
                    { data: 'userId', title: "userID" },
                    { data: 'productId', title: "productID" },
                    { data: 'count', title: "購買數量" },
                    { data: 'dateAdded', title: "購買日期" },
                ];
                url = `/Home/GetShopCarData`;
                break;
            case "join":
                columns = [
                    { data: 'userName', title: "使用者" },
                    { data: 'productName', title: "購買產品" },
                    { data: 'count', title: "購買數量" },
                    { data: 'price', title: "價格" },
                    { data: 'dateAdded', title: "購買日期" },
                ];
                url = `/Home/GetJoin`;
                break;

        }

        console.log("columns", columns);
        console.log("url", url);
        
        if ($.fn.DataTable.isDataTable('#table')) {
            $('#table').DataTable().clear().destroy();
            $('#table thead').remove();
            $('#table tbody').remove();
            $('#table').append('<thead></thead><tbody></tbody>');
            console.log("刪除資料並重置表頭");
        }

        $('#table').DataTable({
            "pageLength": 100,
            "processing": true,
            "serverSide": true,
            "paging": false, 
            "ajax": {
                url: url,
                method: "post",
                dataType: "json",
                contentType: 'application/json;charset=utf-8',
                data: function (e) {
                    console.log(e);
                    return JSON.stringify(e);
                },
                dataSrc: function (json) {
                    console.log(json);
                    return json.data;
                }, 
                error: function (xhr, error, thrown) {
                    console.error("Ajax error:", xhr.responseText);
                }
            },
            "columns": columns
        });
    }
    getData();

    $('#mySelect').change(function () {
        selectValue = $('#mySelect').val();
        console.log(selectValue);
        getData();
    });
});