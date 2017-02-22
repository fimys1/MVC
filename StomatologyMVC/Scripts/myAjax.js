$(document).ready(function () {
    $('#submitDate').click(function (e) {
        e.preventDefault();
        var name = $('#Date').val();
        name = encodeURIComponent(name);
        $('#IdTime').load("/Home/Time?date=" + name); 
    });
});