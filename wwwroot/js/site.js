$(document).ready(function () {
    $('#inputnumber').hide();
    // 當下拉選單的值改變時觸發
    let selectValue = $('#mySelect').val();// 獲取下拉選單中所選擇的值    
    let inputValue = $('#inputtext').val(); // 獲取輸入框中的值
    $('#searchButton').on('click', function () {
        inputValue = $('#inputtext').val();
    })

    $('#mySelect').change(function () {
        selectValue = $(this).val(); // 獲取所選值
    });

    $('#searchButton').click(function () {
        // 使用 AJAX 發送請求
        $.ajax({
            url: '/Home/Index?field=' + selectValue + '&value=' + inputValue,
            method: 'Post',
            dataType: "json",
            success: function (response) {


                $('#table tbody').find('tr:not(:first)').remove();

                // 遍歷資料，並將每一行插入到表格中
                $.each(response, function (index, row) {
                    var tr = $('<tr>');
                    $.each(row, function (key, value) {
                        tr.append($('<td>').text(value));
                    });
                    $('#table').append(tr);
                });
            },
            error: function (error) {
                // 處理錯誤
                console.error("error:", error);
            }
        });
    });
});