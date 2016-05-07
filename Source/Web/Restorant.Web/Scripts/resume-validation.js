
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
    && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

(function () {
    var now = new Date($.now());
    var ageToWork = now.getDate()-(16*365);
    document.addEventListener("click", function () {
        var isChecked = $('#second-address').is(":checked")
        if (isChecked) {
            $("#second-address-form").show();

        }
        else {
            $("#second-address-form").hide();
        }
    })

    $('#popupDatepicker').datepick({
        maxDate: ageToWork,
        dateFormat: 'yyyy-mm-dd',
        altField: '#isoDate',
        altFormat: 'yyyy-mm-dd',
    });
})();

$(document).ready(function () {
    $('#perRate').change(function () {
        var desiredSalery = $("#fake-input").val();
        var rate = $("#perRate").val();
        console.log(desiredSalery.indexOf("^"))
        if (desiredSalery.indexOf("^") > -1) {
            var result = desiredSalery;
            var charAt = result.indexOf("^");
            var firstHalf = result.substr(0, charAt);
            desiredSalery = firstHalf;
        }

        console.log(desiredSalery);
        console.log(desiredSalery + "^" + rate)

        $("#DesiredSalary").val(desiredSalery + "^" + rate);
        $("#DesiredSalary").html(desiredSalery);
    });
});

$(document).ready(function () {
    $("#SSN").on("keypress", function () {
        if ($(this).val) {
            var ssnlength = $(this).val().length
            var ssnVal = $(this).val();
            switch (ssnlength) {
                case 3:
                    var ssnNewVal = ssnVal + '-';
                    $(this).val(ssnNewVal);
                    break;
                case 6:
                    var ssnNewVal = ssnVal + '-';
                    $(this).val(ssnNewVal);
                    break;
                default:
                    break;
            }
        }
    });
    $("#PhoneNumber").on("keypress", function () {
        if ($(this).val) {
            var phonelength = $(this).val().length
            var phoneVal = $(this).val();
            switch (phonelength) {
                case 3:
                    var phoneNewVal = "(" + phoneVal + ")" + '-';
                    $(this).val(phoneNewVal);
                    break;
                case 9:
                    var phoneNewVal = phoneVal + '-';
                    $(this).val(phoneNewVal);
                    break;
                default:
                    break;
            }
        }
    });
})