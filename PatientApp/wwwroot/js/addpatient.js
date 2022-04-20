$(document).ready(function () {
    $('#name').keyup(function (e) {
        $('#cardname').text($('#name').val() + " " + $('#surname').val());
    });
    $('#surname').keyup(function (e) {
        $('#cardname').text($('#name').val() + " " + $('#surname').val());
    });
    $('#ssnumber').keyup(function (e) {
        $('#cardssnumber').text($('#ssnumber').val());
    });
    $('#address').keyup(function (e) {
        $('#cardaddress').text($('#address').val());
    });
    $('#gender').on('change', function () {
        if ($('#gender').val() == -1) {
            $('#image').attr('src', "/images/nomad.jpg");
        }
        else if ($('#gender').val() == 0) {
            $('#image').attr('src', "/images/man.png");
        }
        else if ($('#gender').val() == 1) {
            $('#image').attr('src', "/images/woman.png");
        }
    });
});

function cancelPatient() {
    location.href = '/Patient/ListPatients';
}

function openPatientPage(id) {
    location.href = '/Patient/EditPatient?id=' + id;
}

function addPatient() {
    var name = $('#name').val();
    var surname = $('#surname').val();
    var ssnum = $('#ssnumber').val()
    var phone = $('#phone').val();
    var address = $('#address').val();
    var birthdate = $('#bday').val();
    var age = $('#age').val();
    var height = $('#height').val();
    var weight = $('#weight').val();
    var email = $('#email').val();
    var gender = $('#gender').val();
    $.ajax({
        url: '/Patient/addPatientFunc?name=' + name + '&surname=' + surname + '&ssnum=' + ssnum + '&phone=' + phone + '&address=' + address + '&birthdate=' + birthdate
            + '&age=' + age + '&email=' + email + '&gender=' + gender + '&height=' + height + '&weight=' + weight,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            alertify.confirm("Patient Successfully Added",
                function () {
                    alertify.alert('Ok');
                    openPatientPage(response);
                });
        }
    });
}