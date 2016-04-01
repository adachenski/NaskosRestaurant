$(document).ready(function () { // will trigger when the document is ready
	var now = new Date($.now());
	$("#datepicker").datepick({
		minDate: now,
		maxDate: now + 7,
		dateFormat: 'yyyy-mm-dd',
		altField: '#isoDate', altFormat: 'yyyy-mm-dd'
	});

	$('#timepicker').timepicki({
		increase_direction: 'up',
		overflow_minutes: true,
		step_size_minutes: 15,
		min_hour_value: 6,
		max_hour_value: 10,
		start_time: ["06", "00", "PM"],
	});
}());


function getTimepick() {

    var datePick = $('#datepicker').datepick().val();
    var arrDate = datePick.split(/[ -]+/);
	var timePick = $('#timepicker').timepicki().val();
	var arr = timePick.split(/[ :]+/);

	if (arr[2] == 'PM') {
		var temp = parseInt(arr[0]);
		temp += 12;
		arr[0] = temp.toString();
		timePick = arr[0] + ':' + arr[1];
	}
	else {
		timePick = arr[0] + ':' + arr[1];
	}
	var arrHouers = arr[0];
	if (arrHouers < 6 || arrHouers > 11 && arrHouers < 18 || arrHouers > 22) {
		timePick = ":undefined";
	}
	if (datePick === "") {
		$('.reserved').text("Please enter a valid Day").css("color", "red");
	}
	else {
	    var year = arrDate[0];
	    var month =parseInt(arrDate[1]);
	    var day = arrDate[2];
	    var monthArr = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
	    var stringDate = monthArr[month] + ' - ' +day+' - '+ year;
		$('.reserved').text(stringDate).css("color", "green");
	}

	if (timePick === ":undefined") {
		$('.reservedTime').text("Please enter a valid Time").css("color", "red");
	}
	else {
	    var dinnerChoise = arr[2];
	    if (dinnerChoise=='AM') {
	        $('.brekfastOrLunch').text('Breakfast').css("color", "green");
	    }
	    else {
	        $('.brekfastOrLunch').text('Dinner').css("color", "green");
	    }
		$('.reservedTime').text(timePick).css("color", "green");
	}
	var regex = new RegExp(/^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$/);
	var testDate = regex.test(datePick)
	if (!testDate) {
		$('.reserved').text("Please enter a valid Date").css("color", "red");
	}

	$('.reserved').val(datePick + 'T' + timePick);
}

