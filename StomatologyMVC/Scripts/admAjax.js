$(document).ready(function () {
    $('#submitDate').click(function (e) {
        e.preventDefault();
        var name = $('#Date').val();
        name = encodeURIComponent(name);
        $('#results').load("http://localhost:51361/Admin/Index?name=" + name);
    });
});