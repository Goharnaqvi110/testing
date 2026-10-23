$(document).ready(function () {
    $('#txtSearch').on('input', function () {
        var searchPhrase = $('#txtSearch').val();
        if (searchPhrase.length > 0)
            $('#btnSearchProp').removeClass('disabled');
        else
            $('#btnSearchProp').addClass('disabled');
    });
});