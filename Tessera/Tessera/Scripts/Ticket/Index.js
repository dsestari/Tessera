//Load all the tickets from User
$(document).ready(function () {

    var table = $("#ticketsUser").DataTable({

        ajax: {
            url: "/api/GetTicketsFromUser",
            dataSrc: ""

        },
        columns: [
            {
                data: "id",
                render: function (data, type, ticket) {
                    return "<a href='/tickets/edit/" + ticket.id + "'>" + ticket.id + "</a>";
                }
            },
            {
                data: "group.name"
            },
            {
                data: "userName"
            },
            {
                data: "openingDate"
            },
            {
                data: "summary"
            },
            {
                data: "ticketStatus.name"
            },
            {
                data: "priority.name"
            }
        ]
    });
});

//Load all the tickets from Group
$(document).ready(function () {

    var table = $("#ticketsGroup").DataTable({

        ajax: {
            url: "/api/GetTicketsFromGroup",
            dataSrc: ""

        },
        columns: [
            {
                data: "id",
                render: function (data, type, ticket) {
                    return "<a href='/tickets/edit/" + ticket.id + "'>" + ticket.id + "</a>";
                }
            },
            {
                data: "group.name"
            },
            {
                data: "user.name"
            },
            {
                data: "userName"
            },
            {
                data: "openingDate"
            },
            {
                data: "summary"
            },
            {
                data: "ticketStatus.name"
            },
            {
                data: "priority.name"
            }
        ]
    });
});