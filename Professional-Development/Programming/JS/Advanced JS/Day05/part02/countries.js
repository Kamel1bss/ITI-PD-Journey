// ===== DOM =====
const searchInput = document.getElementById("search");
const searchBtn = document.getElementById("btn");
const cards = document.getElementById("cards");

const countryUI = (index = 1) => ({
  flag: document.getElementById(index === 1 ? "countryImg" : "countryImg2"),
  name: document.getElementById(index === 1 ? "country-name" : "country-name2"),
  region: document.getElementById(index === 1 ? "region" : "region2"),
  population: document.getElementById(index === 1 ? "population" : "population2"),
  language: document.getElementById(index === 1 ? "language" : "language2"),
  currency: document.getElementById(index === 1 ? "currency" : "currency2"),
});

// ===== HELPERS =====
const renderCountry = (data, ui) => {
  ui.flag.src = data.flag;
  ui.name.textContent = data.name;
  ui.region.textContent = data.region;
  ui.population.textContent = `${(data.population / 1e6).toFixed(1)} M People`;
  ui.language.textContent = data.languages?.[0]?.name || "N/A";
  ui.currency.textContent = data.currencies?.[0]?.name || "N/A";
};

// ===== LOGIC =====
searchBtn.addEventListener("click", async () => {
  try {
    const countryName = searchInput.value.trim();
    if (!countryName) return;

    const res = await fetch(`https://restcountries.com/v2/name/${countryName}`);
    const [country] = await res.json();

    renderCountry(country, countryUI(1));

    const neighbourCode = country.borders?.[1];
    if (neighbourCode) {
      const nRes = await fetch(
        `https://restcountries.com/v2/alpha?codes=${neighbourCode}`
      );
      const [neighbour] = await nRes.json();
      renderCountry(neighbour, countryUI(2));
    }

    cards.style.display = "flex";
  } catch (err) {
    alert("Enter a valid country!");
  }
});
