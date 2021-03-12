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

function ani() {
    var fish = document.querySelector('.fish-inner');
    fish.classList.toggle('transform-active');

    var buttons = document.querySelectorAll('.guess button')

    buttons[0].style.display = 'none';
    buttons[1].style.display = 'block';
}

function thumbAni() {
    var thumbs = document.querySelectorAll('.thumb');

    for (var i = 0; i < thumbs.length; i++) {
        thumbs[i].classList.toggle('thumb-transform');
    }
}

function check() {
    var guess = document.querySelector('.guess textarea');
    var buttons = document.querySelectorAll('.guess button')
    var fishBack = document.querySelector('.fish-back');
    var fish = document.querySelector('.fish-inner');

    if (guess.value.toLowerCase() == fishBack.textContent.toLowerCase()) {
        thumbAni();
        ani();
        buttons[0].style.display = 'none';
        buttons[1].style.display = 'block';
    }
    else {
        var wrongAni = [
            { transform: 'rotate(5deg)', offset: 0.25 },
            { transform: 'rotate(-5deg)', offset: 0.50 },
            { transform: 'rotate(5deg)', offset: 0.75 }];

        fish.animate(wrongAni, { duration: 300 });
    }
}

function next() {
    var buttons = document.querySelectorAll('.guess button');
    var guess = document.querySelector('.guess textarea');

    buttons[0].style.display = 'block';
    buttons[1].style.display = 'none';
    guess.value = "";

    var newFish = document.createElement("div");
    newFish.innerHTML =
        "<div class='fish' onclick='ani()'>" +
        "<div class='fish-inner'>" +
        "<div class='fish-front' maxlength='34'>Una cerveza</div>" +
        "<div class='fish-back' maxlength='34'>Piwerko</div>" +
        "</div>" +
        "</div>"
        ;

    var article = document.querySelector('main article');
    var fish = document.querySelector('.fish');
    article.replaceChild(newFish, fish);
}