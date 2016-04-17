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
})();