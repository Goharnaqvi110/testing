function ViewApplication(ID) {
    $.ajax({
        url: '/tenant/viewapplication',
        type: "POST",
        dataType: "JSON",
        data: { AID: ID },
        success: function (result) {
            $('#dvapplication').empty();
            let e = '<embed src="' + result.documentPath + '" width="840" height="900" />';
            $('#dvapplication').append(e);
            $('#divstatus').empty();
            $('#divdocument').removeClass('d-none');
            //debugger;
            var appStatus = "";
            if (result.application.status == 1)
                appStatus = '<i class="fa fa-check-circle" style="font-size:15px;color:darkorange" > </i>' +
                    '<span> Application submitted </span>';
            else if (result.application.status == 2)
                appStatus = '<i class="fa fa-check-circle" style="font-size:15px;color:rgb(5, 184, 5)" > </i>' +
                    '<span> Application approved </span>';
            else if (result.application.status == 3)
                appStatus = '<i class="fa fa-times" style="font-size:15px;color:#EE3232" > </i>' +
                    '<span> Application rejected</span>';                            
            $('#divstatus').append(appStatus);
        }
    })
}