
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


    var min_value = query_minamount ? query_minamount : 0;
    var max_value = query_minamount ? query_maxamount : 1000;

    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 1000,
        values: [min_value, max_value],
        slide: function (event, ui) {
            $("#minamountdisplay").html(ui.values[0]);
            $("#maxamountdisplay").html(ui.values[1]);
            $("#amountmin").val(ui.values[0]);
            $("#amountmax").val(ui.values[1]);
        }
    });
    $("#minamountdisplay").html(min_value);
    $("#maxamountdisplay").html(max_value);


    $('.card-favorite').on('click', function (event) {
        console.log("clicked_favorite");

        toggleFavoriteRequest($(this).data("href"), 1, $(this));
        event.stopImmediatePropagation();
        event.preventDefault();
    });


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

    if (valid_form && !checkDatesRange('checkin', 'checkout', change_element_class, 'checkout-error', 'Check out must be later than Check In'))
        valid_form = false;

    return valid_form;
}
