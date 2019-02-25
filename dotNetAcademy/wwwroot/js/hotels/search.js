
$(function () {


    $('#checkin').datepicker({
        language: 'en',
        minDate: new Date() // Now can select only dates, which goes after today
    })


    $('#checkout').datepicker({
        language: 'en',
        minDate: new Date() // Now can select only dates, which goes after today
    })



});
