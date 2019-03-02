function initMap() {
    var room_location = { lat: room_lat, lng: room_lng };
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 16, center: room_location });
    var marker = new google.maps.Marker({ position: room_location, map: map });
}

$(function () {


    $('i.rating-star').on('click', function () {
        var count = $(this).attr('name');
        for (var i = 0; i <= 5; i++) {
            if ( i < count )
                $('i.rating-star').eq(i).addClass('selected');
            else 
                $('i.rating-star').eq(i).removeClass('selected');
        }

        $('#rate').val(count);
    });

});
