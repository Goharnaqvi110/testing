$(document).ready(function () {
    $('input[type="checkbox"]').click(function () {
        var selection = {
            Type: [],
            Feature: [],
            Rent: [],
            Bed: [],
            sortorder: 1
        };
        // Uncheck single, double and triple bed if option 5 or More bed is checked
        if ($(this).attr('id') == 'chk5bed' && $(this).is(':checked')) {
            $('.not5filter').prop('checked', false);
        }
        else if ($(this).attr('id') === 'single' || $(this).attr('id') === 'double'
            || $(this).attr('id') === 'triple') {
            $('#chk5bed').prop('checked', false);
        }

        // Collect selected checkbox values
        $('input[type="checkbox"]:checked').each(function () {
            if ($(this).hasClass('type')) {
                selection.Type.push($(this).val());
            } else if ($(this).hasClass('feature')) {
                selection.Feature.push($(this).val());
            } else if ($(this).hasClass('rent')) {
                selection.Rent.push($(this).val());
            } else if ($(this).hasClass('bed')) {
                selection.Bed.push($(this).val());
            }
        });
        selection.sortorder = $('#ddlsort').val();
        $('#message').empty();
      //  console.log(selection);
        // Make AJAX call passing selected checkbox values
        $.ajax({
            url: '/search/filter',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify({ selection: selection }), // pass an array with one element
            success: function (data) {
                //debugger;
                $('#propertyList').empty();
                $('#paging').empty();
                if (data.properties.length>0)
                    createPropertyList(data.properties);
                else
                    $('#message').text('no record found');
                if (data.pager.totalPages > 1) {
                    recreatePaging(data.pager.currentPage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                        data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                        data.pager.sortOrderNum,data.pager.functionName, data.pager.searchPhrase, "event");
                }
                window.scrollTo({
                    top: "200",
                    behavior: "smooth",
                });

            } //success function ends
        });
    });
});
