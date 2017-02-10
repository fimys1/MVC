$(document).ready(function () {
    $('#submitDate').click(function (e) {
        e.preventDefault();
        var name = $('#Date').val();
        name = encodeURIComponent(name);
        $('#Time').load("/Home/Time?date=" + name)
            .ajaxSuccess(Chang());
    });
});

Chang = function () {
    document.getElementById("Submit").style.visibility = 'visible';
}