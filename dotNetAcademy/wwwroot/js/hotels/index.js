$(function () {


    // $('input[name="daterange"]').daterangepicker({
    //     "linkedCalendars": false,
    //     // "startDate": "02/14/2019",
    //     // "endDate": "02/20/2019",
    //     "startDate": "03/01/2019",
    //     "endDate": "03/05/2019",      
    //     "opens": "center",
    //     "buttonClasses": "btn btn-primary",
    //     "cancelClass": "btn btn-secondary"
    // }, function(start, end, label) {
    //     console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    //     // $('input[name="checkin"]').value =start.format('YYYY-MM-DD');
    //     // $('input[name="checkout"]').value = end.format('YYYY-MM-DD');
    //     $('input[name="checkin"]').val(start.format('YYYY-MM-DD'));
    //     $('input[name="checkout"]').val(end.format('YYYY-MM-DD'));
    // });

    $('#checkin').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date()
    })


    $('#checkout').datepicker({
        language: 'en',
        dateFormat: 'dd/mm/yyyy',
        minDate: new Date()
    })



    // $( '#city' ).change( function() {
    //     console.log( 'geia' );
    // });

    // $( '#city' ).keyup( function() {
    //     if ( formIsValid(false) )
    //         alert("all ok");
    // });
    // $( '#persons' ).keyup( function() {
    //     if ( formIsValid(false) )
    //         alert("all ok");
    // });
    // $( '#checkin' ).change( function() {
    //     if ( formIsValid(false) )
    //         alert("all ok");
    // });
    // $( '#checkout' ).change( function() {
    //     if ( formIsValid(false) )
    //         alert("all ok");
    // });


});


$(document).ready(function () {
    console.log("document loaded");
});

$(window).on("load", function () {
    console.log("window loaded");




});


function formIsValid(change_element_class = true) {

    var valid_form = true;

    //if (!checkField('city', change_element_class, 'search-errors', 'Πολη ρε'))
    //    valid_form = false;
    //if (!checkField('persons', change_element_class, 'search-errors', 'Ημερομηνια ατομα ρε'))
    //    valid_form = false;
    //if (!checkField('checkin', change_element_class, 'search-errors', 'Ημερομηνια in ρε'))
    //    valid_form = false;
    //if (!checkField('checkout', change_element_class, 'search-errors', 'Ημερομηνια out ρε'))
    //    valid_form = false;

    return valid_form;
}

function checkField(field_id, update_ui, errordiv_id, errormessage) {
    if (!$('#' + field_id).val()) {
        if (update_ui) {
            $('#' + field_id).addClass('invalid-input');
            $('#' + errordiv_id).addClass('show');
            $('#' + errordiv_id).append(errormessage);
        }
        return false;
    } else {
        if (update_ui)
            $('#' + field_id).removeClass('invalid-input');
        return true;
    }
}



