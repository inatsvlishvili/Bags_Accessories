//$(document).ready(function () {
//    alert();
//}

$('#txtSearch').keyup(function () {
    debugger
    var typevalue = $(this).val();
    $('tbody tr').each(function () {
        if ($(this).text().search(new RegExp(typevalue, "i")) < 0) {
            $(this).fadeOut();
        }
        else {
            $(this).show();
        }
    })
});