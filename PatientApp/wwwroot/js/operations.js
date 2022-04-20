function getDiagnoseView(id) {
    $.ajax({
        url: '/Patient/getDiagnose?id=' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('#diagnosetbody').empty();
            $('#diagnosetbody').append("<tr><td>" + response["id"] + "</td><td>" + response["diagnose"] + "</td><td>" + response["description"] + "</td><td>"
                + response["exp_date"] + "</td><td><button class='btn btn-primary' onclick='getMedicinesView(" + response["id"] + ")'>Details</button></td></tr>");
            $('#addDiagnoseModelOpen').on("click", function () {
                addDiagnoseModelOpen(id);
            });
            $('.diagnosemodal').modal('show');
        }
    });
}

function getDiagnoseEdit(id) {
    $.ajax({
        url: '/Patient/getDiagnose?id=' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('#diagnosetbody').empty();
            $('#diagnosetbody').append("<tr><td>" + response["id"] + "</td><td>" + response["diagnose"] + "</td><td>" + response["description"] + "</td><td>"
                + response["exp_date"] + "</td><td><button class='btn btn-primary' onclick='getMedicinesEdit(" + response["id"] + ")'>Details</button></td></tr>");
            $('#addDiagnoseModelOpen').on("click", function () {
                addDiagnoseModelOpen(id);
            });
            $('.diagnosemodal').modal('show');
        }
    });
}

function getMedicinesView(id) {
    $.ajax({
        url: '/Patient/getMedicines?diagnoseid=' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('#medicinesbody').empty();
            for (let i = 0; i < response.length; i++) {
                $('#medicinesbody').append("<tr><td>" + response[i]["id"] + "</td><td>" + response[i]["name"] + "</td><td>" + response[i]["usage"] + "</td><td>"
                    + response[i]["description"] + "</td><td>" + response[i]["exp_date"] + "</td></tr>");
            }
            $('.medicinemodal').modal('show');
            $('#modalAddMedicine').on("click", function () {
                modaladdMedicine(id);
            });
        }
    });
}
function getMedicinesEdit(id) {
    $.ajax({
        url: '/Patient/getMedicines?diagnoseid=' + id,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('#medicinesbody').empty();
            for (let i = 0; i < response.length; i++) {
                $('#medicinesbody').append("<tr><td>" + response[i]["id"] + "</td><td>" + response[i]["name"] + "</td><td>" + response[i]["usage"] + "</td><td>"
                    + response[i]["description"] + "</td><td>" + response[i]["exp_date"] + "</td><td>"+
                    "<button id='removeMedicine" + response[i]["id"]+"' class='btn btn-danger'>Remove</button></td ></tr>");
                $('#removeMedicine'+response[i]["id"]).on("click", function () {
                    removeMedicine(response[i]["id"])
                });
            }
            $('.medicinemodal').modal('show');
            $('#modalAddMedicine').on("click", function () {
                modaladdMedicine(id);
            });
        }
    });
}

function removeMedicine(id) {
    alertify.confirm("Are You Sure About Removing Medicine?",
        function () {
            alertify.success('Removed');
            $.ajax({
                url: '/Patient/removeMedicine?id=' + id,
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    $('.medicinemodal').modal('hide');
                }
            });
        },
        function () {
            alertify.error('Cancelled');
        }
    );
}

function modaladdMedicine(id) {
    $('.medicinemodal').modal('hide');
    $('.addmedicine').modal('show');
    $('#addMedicine').on("click", function () {
        addMedicine(id);
    });
}

function addMedicine(id) {
    var medname = $('#med_name').val();
    var medusage = $('#med_usage').val();
    var meddesc = $('#med_desc').val();
    var medexp = $('#med_exp_date').val();
    $('.addmedicine').modal('hide');
    $.ajax({
        url: '/Patient/addMedicine?id=' + id + '&medname=' + medname + '&usage=' + medusage + '&desc=' + meddesc + '&exp_date=' + medexp,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('#med_name').val("");
            $('#med_usage').val("");
            $('#med_desc').val("");
            $('#med_exp_date').val("");
            alertify.alert("Medicine Added");
        }
    });
}

function addDiagnoseModelOpen(id) {
    $('#addDiagnose').on("click", function () {
        addDiagnose(id)
    });
    $('.adddiagnose').modal('show');
}

function addVisitModalOpen(id) {
    $('#addVisit').on("click", function () {
        addVisit(id)
    });
    $('.addvisit').modal('show');
}


function addVisit(id) {
    var visitdesc = $('#visit_desc').val();
    var visitdate = $('#visit_date').val();
    $.ajax({
        url: '/Patient/addVisit?id=' + id + '&visit_desc=' + visitdesc + '&visit_date=' + visitdate,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('.addVisit').modal('hide');
            $('#visit_desc').val("");
            $('#visit_date').val("");
            location.reload(true);
        }
    });
}

function addDiagnose(id) {
    var diagname = $('#diagnose_name').val();
    var diagdesc = $('#diagnose_desc').val();
    var diagexp = $('#diagnose_exp_date').val();
    $.ajax({
        url: '/Patient/addDiagnose?id=' + id + '&diagnosename=' + diagname + '&desc=' + diagdesc + '&exp_date=' + diagexp,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            $('.adddiagnose').modal('hide');
            $('#diagnose_name').val("");
            $('#diagnose_desc').val("");
            $('#diagnose_exp_date').val("");
            location.reload(true);
        }
    });
}

function removePatient(id) {
    alertify.confirm("Are You Sure About Removing Patient?",
        function () {
            alertify.success('Removed');
            $.ajax({
                url: '/Patient/removePatient?id=' + id,
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    location.href = '/Patient/ListPatients';
                }
            });
        },
        function () {
            alertify.success('Cancel');
        }
    );
}

function removeDiagnose(id) {
    alertify.confirm("Are You Sure About Removing Diagnose?",
        function () {
            alertify.success('Ok');
            $.ajax({
                url: '/Patient/removeDiagnose?id=' + id,
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    location.reload(true);
                }
            });
        },
        function () {
            alertify.success('Cancel');
        }
    );
}

function removeVisit(id) {
    alertify.confirm("Are You Sure About Removing Visit?",
        function () {
            alertify.success('Ok');
            $.ajax({
                url: '/Patient/removeVisit?id=' + id,
                type: 'GET',
                dataType: 'json',
                success: function (response) {
                    location.reload(true);
                }
            });
        },
        function () {
            alertify.success('Cancel');
        }
    );
}

function editItem(item) {
    location.href = '/Patient/EditPatient?id=' + item;
}

function updatePatient(id) {
    var name = $('#name').val();
    var surname = $('#surname').val();
    var ssnum = $('#ssnumber').val()
    var phone = $('#phone').val();
    var address = $('#address').val();
    var birthdate = $('#bday').val();
    var age = $('#age').val();
    var email = $('#email').val();
    var gender = $('#gender').val();
    var height = $('#height').val();
    var weight = $('#weight').val();
    $.ajax({
        url: '/Patient/updatePatient?id=' + id + '&name=' + name + '&surname=' + surname + '&ssnum=' + ssnum + '&phone=' + phone + '&address=' + address + '&birthdate=' + birthdate
            + '&age=' + age + '&email=' + email + '&gender=' + gender + '&height=' + height + '&weight=' + weight,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            location.reload(true);
        }
    });
}