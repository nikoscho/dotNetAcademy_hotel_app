///////////////////////////////////////////////////////////////
// Check Fields/Dates
///////////////////////////////////////////////////////////////
function checkField(field_id, update_ui, errordiv_id, errormessage) {
    if (!$('#' + field_id).val() || $('#' + field_id).val() == 0) {
        if (update_ui) {
            $('#' + field_id).addClass('invalid-input');
            $('#' + errordiv_id).addClass('show');
            $('#' + errordiv_id).html(errormessage);
        }
        return false;
    } else {
        if (update_ui) {
            $('#' + field_id).removeClass('invalid-input');
            $('#' + errordiv_id).html("");
        }
        return true;
    }
}

function checkDatesRange(start_date_field_id, end_date_field_id, update_ui, errordiv_id, errormessage) {
    if ($('#' + start_date_field_id).val() > $('#' + end_date_field_id).val()) {
        if (update_ui) {
            $('#' + end_date_field_id).addClass('invalid-input');
            $('#' + errordiv_id).addClass('show');
            $('#' + errordiv_id).html(errormessage);
        }
        return false;
    } else {
        if (update_ui) {
            $('#' + end_date_field_id).removeClass('invalid-input');
            $('#' + errordiv_id).html("");
        }
        return true;
    }
}

///////////////////////////////////////////////////////////////
// Ajax - toggle favorite
///////////////////////////////////////////////////////////////
function toggleFavoriteRequest(url, element_to_change) {
    $.ajax({
        type: "POST",
        url: url,
        headers: { "X-AFT": $('input[name="__RequestVerificationToken]"').val() },
        success: function (response) {
            if (response)
                element_to_change.addClass("checked");
            else
                element_to_change.removeClass("checked");
        },
        error: function (response) {
            element_to_change.removeClass("checked");
        }
    });
}