$(function () {

    $('#checkin').datepicker({
        language: 'en',
        dateFormat: 'yyyy-mm-dd',
        minDate: new Date(),
        autoClose: true
    })


    $('#checkout').datepicker({
        language: 'en',
        dateFormat: 'yyyy-mm-dd',
        minDate: new Date(),
        autoClose: true
    })

});

function formValidation(change_element_class = true) {

    var valid_form = true;

    //if (!checkField('city', change_element_class, 'search-errors', 'Πολη ρε'))
    //    valid_form = false;
    //if (!checkField('persons', change_element_class, 'search-errors', 'Ημερομηνια ατομα ρε'))
    //    valid_form = false;
    if (!checkField('checkin', change_element_class, 'checkin-error', 'Required'))
         valid_form = false;
    if (!checkField('checkout', change_element_class, 'checkout-error', 'Required'))
        valid_form = false;

    if (valid_form && !checkDatesRange('checkin','checkout', change_element_class, 'checkout-error', 'Check out must be later than Check In'))
        valid_form = false;

    return valid_form;
}



