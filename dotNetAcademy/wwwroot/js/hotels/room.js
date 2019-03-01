function initMap() {
    var room_location = { lat: room_lat, lng: room_lng };
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 16, center: room_location });
    var marker = new google.maps.Marker({ position: room_location, map: map });
}
