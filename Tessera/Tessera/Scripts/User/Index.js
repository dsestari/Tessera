//load all the users

$(document).ready(function () {
    var table = $("#users").DataTable({
        ajax: {
            url: "/api/users",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, user) {
                    return "<a href='/users/edit/" + user.id + "'>" + user.name + "</a>";
                }
            },
            {
                data: "email"
            },
            {
                data: "group.name"
            },
            {
                data: "userStatus.name"
            }
        ]
    });
});