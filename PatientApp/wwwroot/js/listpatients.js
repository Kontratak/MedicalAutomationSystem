$('#searchcancel').on("click", function () {
    location.href = '/Patient/ListPatients';
});
$('#addpatient').on("click", function () {
    location.href = '/Patient/AddPatient';
});
function removeItem(id) {
    alertify.confirm("Are You Sure About Removing Patient?",
        function () {
            alertify.success('Removed');
            $.ajax({
                url: '/Patient/removePatient?id=' + id,
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
function viewItem(item) {
    location.href = '/Patient/ViewPatient?id=' + item;
}
function addPatient() {
    location.href = '/Patient/AddPatient';
}