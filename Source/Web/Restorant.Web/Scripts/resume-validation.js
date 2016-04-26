(function () {
    var now = new Date($.now());

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
        maxDate: now,
        dateFormat: 'yyyy-mm-dd',
        altField: '#isoDate',
        altFormat: 'yyyy-mm-dd',
    });

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
})();