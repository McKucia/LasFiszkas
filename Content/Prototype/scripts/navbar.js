function openNav() {
    var screenWidth = window.innerWidth;
    if (screenWidth < 500) {
        document.getElementById("mySidenav").style.width = "200px";
    }
    else {
        document.getElementById("mySidenav").style.width = "250px";
    }
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}