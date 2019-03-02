
$(function () {

    var checkin = $('#checkin').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date()
    }).data('datepicker');


    var checkout = $('#checkout').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date()
    }).data('datepicker');

    //checkin.selectDate(new Date(query_checkin));
    //checkout.selectDate(new Date(query_checkout));
    //checkin.selectDate(Date.parse(query_checkin));
    //checkout.selectDate(Date.parse(query_checkout));
});


