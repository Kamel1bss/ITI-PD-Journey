const products = [
    { img: "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=200", name: "Product 1", stock: 25, price: 10000 },
    { img: "https://images.unsplash.com/photo-1593642632559-0c6d3fc62b89?w=200", name: "Product 2", stock: 40, price: 30000 },
    { img: "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=200", name: "Product 3", stock: 20, price: 20000 },
    { img: "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=200", name: "Product 4", stock: 25, price: 10000 },
    { img: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=200", name: "Product 5", stock: 40, price: 30000 },
    { img: "https://images.unsplash.com/photo-1485955900006-10f4d324d411?w=200", name: "Product 6", stock: 20, price: 20000 },
    { img: "https://images.unsplash.com/photo-1518455027359-f3f8164ba6bd?w=200", name: "Product 7", stock: 20, price: 20000 },
    { img: "https://images.unsplash.com/photo-1593642634315-48f5414c3ad9?w=200", name: "Product 8", stock: 20, price: 20000 },
];

const grid = document.getElementById('product-grid');

products.forEach(p => {
    const col = document.createElement('div');
    col.className = 'col-12 col-sm-6 col-md-3';
    col.innerHTML = `
    <div class="card product-card h-100">
        <div class="d-flex align-items-center p-2">
        <img src="${p.img}" alt="${p.name}">
        <div class="card-body">
            <div class="product-name">${p.name}</div>
            <div class="product-price">Price: <span>$${p.price.toLocaleString()}</span></div>
            <div class="product-stock">Stock: ${p.stock}</div>
        </div>
        </div>
    </div>
    `;
    grid.appendChild(col);
});