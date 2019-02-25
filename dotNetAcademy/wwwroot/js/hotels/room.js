function initMap() {
    // The location of Uluru
    var uluru = { lat: 37.9610028, lng: 23.7002453 };
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 14, center: uluru });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({ position: uluru, map: map });
}
