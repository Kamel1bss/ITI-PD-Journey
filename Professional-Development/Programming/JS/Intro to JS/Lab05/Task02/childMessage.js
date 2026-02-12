let openBtn = document.querySelector('.openBtn');

let child;
let intervalId;
let i = 0;

openBtn.addEventListener('click', () => {

    child = window.open('popup.html', 'popup', 'width=400,height=400');
    child.document.write('<p>Message from parent</p>');
    setTimeout(() => {
        child.close();
    }, 1000);
});

