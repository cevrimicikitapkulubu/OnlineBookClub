//const { error } = require("jquery");


//$(document).ready(function () {
//    GetEvents();
//});

//function GetEvents() {
//    $.ajax({
//        url: '/Event/GetEvents',
//        type: 'get',
//        dataType: 'json',
//        contentType: 'application/json;charset=utf-8',
//        success: function (response) {
//            if (response == null || response == undefined || response.length == 0) {
//                var object = '';
//                object += '<tr>';
//                object += '<td class="colspan="5">' + 'Product not available' +
//                    '</td>';
//                $('#tbody').html(object);
//            }

//            else {
//                var object = '';
//                $.each(response, function (index, item) {
//                    object += '<tr>';
//                    object += '<td>' + item.Id + '</td>';
//                    object += '<td>' + item.ISBN + '</td>';
//                    object += '<td>' + item.Title + '</td>';
//                    object += '<td>' + item.LocationId + '</td>';
//                    object += '<td>' + item.StartDate + '</td>';
//                    object += '<td> <a href="#" data-bs-toggle="modal" class="Red-Button" data-bs-target="#eventUpdateModal" style="float:right;" onclick="Edit(' + item.Id + ')">Değiştir</a> </td>';
//                });
//                $('#tbody').html(object);
//            }
//        },
//        error: function () {
//            alert('Unable to read the data')
//        }

//    })
//}


//function edit(id) {
//    $.ajax({
//        url: 'Event/Edit=' + id,
//        type: 'get',
//        contentType: 'application/json;charset=utf-8',
//        dataType: 'json',
//        success: function (response) {
//            if (response == null || response == undefined) {
//                alert('Unable to read the data.');
//            }
//            else if (response.length == 0) {
//                alert('Data not available with the id ' + id);
//            }
//            else {
//                $('#eventUpdateModal').modal("show");
//                $('#eventUpdateModalLabel').text("Update Event");
//                $('#EventUpdate').css('display', 'block');
//                $('#Id').val(response.id);
//                $('#ISBN').val(response.ISBN);
//                $('#Title').val(response.Title);
//                $('#LocationId').val(response.LocationId);
//                $('#StartDate').val(response.StartDate);

//            },
//            error: function() {
//                alert('Unable to read the data.');
//            }
//        }
//    });
//}