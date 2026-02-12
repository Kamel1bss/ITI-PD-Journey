let openBtn = document.querySelector('.openBtn');
let stopBtn = document.querySelector('.stopBtn');

let child;
let intervalId;
let i = 0;

openBtn.addEventListener('click', () => {

    child = window.open('popup.html', 'popup', 'width=400,height=400');

    setTimeout(() => {
        intervalId = setInterval(() => {
            i += 10;
            child.moveBy(i, i);
        }, 1000);
    }, 500);
});

stopBtn.addEventListener('click', () => {
    clearInterval(intervalId);
    child.focus();
});
