$(document).ready(function () {
    $('.application').each(function (index, elem) {
        $(elem).children().each(function (i, elmnt) // Get all divs in row
        {
            $(elmnt).change(function () {
                
                var applicationId;
                applicationId = $(this).children().attr('data-aid');

                //$(this).children().each(function (j, e) { // alternatively, we can get data-eid 
                                                            //of selected option by iterating thourgh options.iterating
                // enquiryId = $(e).attr('data-eid');
                //});
                var statusId = $(this).val();

                $.ajax({
                    url: '/application/updateApplicationStatus?statusId=' + statusId + '&&applicationId=' + applicationId,
                    success: function (result) {
                        window.location.reload();
                    }
                });
            });
        });
    });
});