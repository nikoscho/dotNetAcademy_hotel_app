
$(function () {

    $('#checkin').datepicker();
    $('#checkout').datepicker();

    $('#checkin').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date(),
        Date: query_checkin
    })


    $('#checkout').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date(),
        date: query_checkout
    })


});


