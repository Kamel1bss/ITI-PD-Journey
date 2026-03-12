  // Sync custom dots with carousel
  const carousel = document.getElementById('testiCarousel');
  const dots = document.querySelectorAll('.testi-dot');

  carousel.addEventListener('slid.bs.carousel', (e) => {
    dots.forEach(d => d.classList.remove('active'));
    dots[e.to].classList.add('active');
  });

  dots.forEach(dot => {
    dot.addEventListener('click', () => {
      const index = parseInt(dot.dataset.index);
      bootstrap.Carousel.getInstance(carousel).to(index);
    });
  });