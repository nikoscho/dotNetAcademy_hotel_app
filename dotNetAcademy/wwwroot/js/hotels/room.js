function initMap() {
    var hotel_location = { lat: lat, lng: lng };
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 16, center: hotel_location });
    var marker = new google.maps.Marker({ position: hotel_location, map: map });
}
