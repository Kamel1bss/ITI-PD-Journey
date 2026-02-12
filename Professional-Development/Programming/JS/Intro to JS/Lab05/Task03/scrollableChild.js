let openBtn = document.querySelector('.openBtn');

let child;
let intervalId;
let i = 0;

openBtn.addEventListener('click', () => {
    child = window.open('popup.html', 'popup', 'width=400,height=400');
    child.onload = () => {
        let scrollable = child.document.documentElement;
        console.log(scrollable);
        intervalId = setInterval(() => {
            i += 50;
            scrollable.scrollTo({
            top: i,
            behavior: 'smooth' 
            });

            if (i >= scrollable.scrollHeight - scrollable.clientHeight)
                child.close();
        }, 600);
    }
});

