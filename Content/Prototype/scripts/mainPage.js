function ani() {
    var fish = document.querySelector('.fish-inner');
    fish.classList.toggle('transform-active');

    var button = document.querySelector('.guess button');
    var nextBtn = document.querySelector('.guess a');

    button.style.display = 'none';
    nextBtn.style.display = 'block';
}

function thumbAni() {
    var thumbs = document.querySelectorAll('.thumb');

    for (var i = 0; i < thumbs.length; i++) {
        thumbs[i].classList.toggle('thumb-transform');
    }
}

function check() {
    var guess = document.querySelector('.guess textarea');
    var fishBack = document.querySelector('.fish-back');
    var fish = document.querySelector('.fish-inner');

    if (guess.value.toLowerCase() == fishBack.textContent.toLowerCase()) {
        thumbAni();
        ani();
        points++;
    }
    else {
        var wrongAni = [
            { transform: 'rotate(5deg)', offset: 0.25 },
            { transform: 'rotate(-5deg)', offset: 0.50 },
            { transform: 'rotate(5deg)', offset: 0.75 }];

        fish.animate(wrongAni, { duration: 300 });
    }
}

var points = 0;
var length;
function ProcessAndUpdate(result) {
    var guess = document.querySelector('.guess textarea');
    var button = document.querySelector('.guess button');
    var nextBtn = document.querySelector('.guess a');

    if (result == "thatsIt") {
        nextBtn.style.display = 'none';
        guess.style.display = 'none';

        var template = $('#resultTmpl').html();
        var html = Mustache.render(template, { correct: points, wrong: length - points });
        $('#update').html(html);
        points = 0;
    }
    else {
        length = result.SetLength;
        guess.style.display = 'block';
        button.style.display = 'block';
        nextBtn.style.display = 'none';

        nextBtn.innerHTML = 'Dalej';
        nextBtn.style.background = 'var(--yellow)';
        nextBtn.style.color = 'var(--red)';

        var template = $('#fishTmpl').html();
        var html = Mustache.to_html(template, result);
        $('#update').html(html);
    }
}

var file = document.getElementById('file');

file.addEventListener('change', function () {
    var fileSize = this.files[0].size / 1024 / 1024;
    var fileName = this.files[0].name;
    var choose = document.querySelector("#choose");
    var btnSubmit = document.querySelector('input[type="submit"]');

    if (fileSize > 4) {
        choose.style.color = 'var(--red)';
        choose.textContent = "Plik przekracza dozwolony rozmiar";
        file.value = '';
    }
    else {
        choose.style.color = 'black';
        choose.textContent = fileName;
    }
});