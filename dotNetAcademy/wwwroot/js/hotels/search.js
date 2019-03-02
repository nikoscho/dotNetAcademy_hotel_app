
$(function () {

    var checkin = $('#checkin').datepicker({
        language: 'en',
        dateFormat: 'yyyy-mm-dd',
        minDate: new Date()
    }).data('datepicker');


    var checkout = $('#checkout').datepicker({
        language: 'en',
        dateFormat: 'yyyy-mm-dd',
        minDate: new Date()
    }).data('datepicker');

    if (query_checkin)
        checkin.selectDate(new Date(query_checkin));
    if (query_checkout)
        checkout.selectDate(new Date(query_checkout));

});


