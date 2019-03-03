
function toggleFavoriteRequest(url, userid, element_to_change) {
    $.ajax({
        type: "POST",
        url: url,
        data: { 'UserId': userid },
        success: function (response) {
            console.log("success");
            console.log(response);

            if (response) 
                element_to_change.addClass("checked");
            else 
                element_to_change.removeClass("checked");

        },
        error: function (response) {
            console.log("error");
            console.log(response);
            element_to_change.removeClass("checked");
        }
    });
}