//This file is used to implement chating in tenant log in.
//Connection with the hub is established on document.ready().
//User cliks the landlord to load messages in the chat window and start connection in 'initializeChatFunction' function.
//landlord-tenant group is created by invoking 'AddToGroup' method in chatHub.cs class.
//'btnSend' click envent invokes 'SendMessage' message in chatHub.cs which invokes 'ReceiveMessage' in this file.

"use strict";
$(document).ready(function () {
    //debugger;
    var connection1 = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    let tenantId = "";
    let landlordId = "";
    let landlordPic = "";
    let groupName = "";
    let landlordName = "";
    let currentUserId = "";
    $("a.userMessage").click(function (event) {
        event.preventDefault(); // prevent the default action of the link
        //debugger;
        landlordId = $(this).data("landlordid");
        landlordPic = $(this).data("landlordpic");
        tenantId = $(this).data("currentuserid");
        currentUserId = $(this).data("currentuserid");
        groupName = `Landlord_${landlordId}-Tenant_${tenantId}`;

        landlordName = "Chat with " + $(this).data("landlordname");
        $("#landLordName").html(landlordName);
        // console.log(lid+"----"+tenantPic + "----" + landlordPic + "----" + currentUserId);
        //debugger;
        $.ajax({
            url: '/tenant/GetMessages?id=' + landlordId,
            success: function (result) {
                // debugger;
                console.log(result);
                $('#DZ_W_Contacts_Body3').empty();
                //debugger;
                $.each(result, function (i, message) {
                    var html = '';
                    var sentOnDate = new Date(message.sentOn);
                    var formattedDate = sentOnDate.toLocaleDateString('en-GB'); // dd/mm/yyyy format
                    if (currentUserId == message.fromUserID) {
                        html = '<div class="d-flex justify-content-end mb-4">' +
                            '<div class="img_cont_msg">' +
                            '<img src="landlordPic" class="rounded-circle user_img_msg" alt="" />' +
                            '</div>' +
                            '<div class="msg_cotainer">' +
                            message.text +
                            '<div class="d-flex"><span class="msg_time pt-1">' + formattedDate + '</span>' +
                            (message.read ? "<span class='tick-seen'></span>" : "<span class='tick-sent'></span>") +
                            '</div></div>'
                        '</div>'
                    } else {
                        html = '<div class="d-flex justify-content-start mb-4">' +
                            '<div class="msg_cotainer_send">' +
                            message.text +
                            '<div class="d-flex"><span class="msg_time_send pt-1">' + formattedDate + '</span>' +
                            (message.read ? "<span class='tick-seen'></span>" : "<span class='tick-sent'></span>") +
                            '</div></div>' +
                            '<div class="img_cont_msg">' +
                            '<img src="tenantPic" class="rounded-circle user_img_msg" alt="" />' +
                            '</div>' +
                            '</div>'
                    }
                    $('#DZ_W_Contacts_Body3').append(html);
                });
                // Call the chat function here after the ajax call completes
                initializeChatFunction();
            }
        });
    });
    function initializeChatFunction() {
        connection1.start().then(function () {
            connection1.invoke("AddToGroup", groupName).catch(function (err) {
                return console.error(err.toString());
            });
        }).catch(function (err) {
            return console.error(err.toString());
        });
    }
    connection1.on("ReceiveMessage", function (user, message, sentOn, fromUserID1, msgID) {         
        console.log(user);
        //debugger;
        var html;
        if (currentUserId == fromUserID1) {
            html = '<div class="d-flex justify-content-end mb-4">' +
                '<div class="img_cont_msg">' +
                '<img src="landlordPic" class="rounded-circle user_img_msg" alt="" />' +
                '</div>' +
                '<div class="msg_cotainer">' +
                message +
                '<span class="msg_time">' + sentOn + '</span>' +
                '</div>' +
                '</div>'
        }
        else {
            html = '<div class="d-flex justify-content-start mb-4">' +
                '<div class="msg_cotainer_send">' +
                message +
                '<span class="msg_time_send">' + sentOn + '</span><span class="tick-seen"></span>' +
                '</div>' +
                '<div class="img_cont_msg">' +
                '<img src="tenantPic" class="rounded-circle user_img_msg" alt="" />' +
                '</div>' +
                '</div>'
            // const audio = new Audio('http://smartpropertymanager.pk/assets/audio/notification.mp3');
            const audio = new Audio(`${window.location.origin}/assets/audio/notification.mp3`);
            audio.play();
        }
        $('#DZ_W_Contacts_Body3').append(html);
        $('#txtMessage').val('');
    });
    connection1.on("MessageUpdated", function (isRead) {
        // Update the sender UI to show the second tick (received)
        if (isRead) {
            // Add code to show the received tick
            var messagesList = document.getElementById("messagesList");
            var lastMessage = messagesList.querySelector("li:last-child");
            //Find and remove span with class 'Tick-sent'
            var sentTick = lastMessage.querySelector(".tick-sent");
            lastMessage.removeChild(sentTick);
            // Add a span that contains class with two ticks
            var tickSent = document.createElement("span");
            tickSent.classList.add("tick-seen");
            lastMessage.appendChild(tickSent);
        }        
    });

    // document.getElementById("btnSend").disabled = false;
    document.getElementById("btnSend").addEventListener("click", function (event) {
        //debugger;
        event.preventDefault();
        let message = document.getElementById("txtMessage").value;
        if (message !== null && message !== '') {
            var currentDate = new Date();
            var options = {
                year: "numeric",
                month: "2-digit",
                day: "2-digit",
                hour: "2-digit",
                minute: "2-digit",
                second: "2-digit",
                hour12: true
            };
            var formattedDate = currentDate.toLocaleString("en-US", options);
            connection1.invoke("SendMessage", groupName, null, message, tenantId,
                landlordId, formattedDate).catch(function (err) {
                    return console.error(err.toString());
                });
            $('#txtMessage').val('');
        }
        //event.preventDefault();
    });

    // Add an event listener for the "keyup" event on the txtMessage input box
    const messageInput = document.getElementById("txtMessage");
    messageInput.addEventListener("keyup", function (event) {
        // Check if the "Enter" key was pressed
        if (event.keyCode === 13) {
            // Trigger the same function as the "click" event of the "sendButton1"
            let message = document.getElementById("txtMessage").value;
            if (message !== null && message !== '') {
                var currentDate = new Date();
                var options = {
                    year: "numeric",
                    month: "2-digit",
                    day: "2-digit",
                    hour: "2-digit",
                    minute: "2-digit",
                    second: "2-digit",
                    hour12: true
                };
                var formattedDate = currentDate.toLocaleString("en-US", options);
                connection1.invoke("SendMessage", groupName, null, message, tenantId,
                    landlordId, formattedDate).catch(function (err) {
                        return console.error(err.toString());
                    });
                $('#txtMessage').val('');
            }
            event.preventDefault();
        }
    });
    //Keyup of messageInput1 ends
    window.addEventListener("unload", function (event) {
        connection1.invoke("RemoveFromGroup", groupName).catch(function (err) {
            return console.error(err.toString());
        });
    });

});