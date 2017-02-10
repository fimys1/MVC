function denied(valve) {
    $('#modalId').val(valve);
    $('#DeniedId').val(valve);
};

function change(valve) {
    $('#dateModalId').val(valve);
    $('#ChangeId').val(valve);
};

$(document).ready(function () {
    $('#submitDate').click(function (e) {
        e.preventDefault();
        var name = $('#Date').val();
        name = encodeURIComponent(name);
        $('#results').load("/Home/Time?date=" + name);
    });
});