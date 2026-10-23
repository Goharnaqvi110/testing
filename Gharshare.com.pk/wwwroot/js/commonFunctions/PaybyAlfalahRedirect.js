$(function () {
    $("#handshake").click(function (e) {
        e.preventDefault();
        debugger;
        $("#handshake").attr('disabled', 'disabled');
        submitRequest("HandshakeForm");
        if ($("#HS_IsRedirectionRequest").val() == "1") {
            document.getElementById("HandshakeForm").submit();
        }
        else {
            var myData = {
                HS_MerchantId: $("#HS_MerchantId").val(),
                HS_StoreId: $("#HS_StoreId").val(),
                HS_MerchantHash: $("#HS_MerchantHash").val(),
                HS_MerchantUsername: $("#HS_MerchantUsername").val(),
                HS_MerchantPassword: $("#HS_MerchantPassword").val(),
                HS_IsRedirectionRequest: $("#HS_IsRedirectionRequest").val(),
                HS_ReturnURL: $("#HS_ReturnURL").val(),
                HS_RequestHash: $("#HS_RequestHash").val(),
                HS_ChannelId: $("#HS_ChannelId").val(),
                HS_TransactionReferenceNumber: $("#HS_TransactionReferenceNumber").val(),
            }

            $.ajax({
                type: 'POST',
                url: 'https://sandbox.bankalfalah.com/HS/HS/HS',
                contentType: "application/x-www-form-urlencoded",
                data: myData,
                dataType: "json",
                beforeSend: function () {
                },
                success: function (r) {
                    if (r != '') {
                        if (r.success == "true") {
                            $("#AuthToken").val(r.AuthToken);
                            $("#ReturnURL").val(r.ReturnURL);
                            alert('Success: Handshake Successful');
                        }
                        else {
                            alert('Error: Handshake Unsuccessful');
                        }
                    }
                    else {
                        alert('Error: Handshake Unsuccessful');
                    }
                },
                error: function (error) {
                    alert('Error: An error occurred');
                },
                complete: function (data) {
                    $("#handshake").removeAttr('disabled', 'disabled');
                }
            });
        }

    });

    $("#run").click(function (e) {
        e.preventDefault();
        submitRequest("PageRedirectionForm");
        document.getElementById("PageRedirectionForm").submit();
    });
});

function submitRequest(formName) {

    var mapString = '', hashName = 'RequestHash';
    if (formName == "HandshakeForm") {
        hashName = 'HS_' + hashName;
    }

    $("#" + formName + " :input").each(function () {
        if ($(this).attr('id') != '') {
            mapString += $(this).attr('id') + '=' + $(this).val() + '&';
        }
    });

    $("#" + hashName).val(CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(mapString.substr(0, mapString.length - 1)), CryptoJS.enc.Utf8.parse($("#Key1").val()),
        {
            keySize: 128 / 8,
            iv: CryptoJS.enc.Utf8.parse($("#Key2").val()),
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        }));
}