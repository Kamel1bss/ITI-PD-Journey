import { Component } from '@angular/core';
import { DUMMY_PRODUCTS } from '../../DUMMY-PRODUCTS';
import { DUMMY_CATEGORIES } from '../../DUMMY-CATEGORIES';
import { ProductFilter } from '../product-filter/product-filter';
import { IProduct } from '../../interfaces/IProduct';

@Component({
  selector: 'app-product-list',
  imports: [ProductFilter],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList {
  products = DUMMY_PRODUCTS;
  categories = DUMMY_CATEGORIES;

  currentTotalPrice: number = 0;
  OnBuy(product: IProduct) {
    this.currentTotalPrice += product.price;
    product.quantity--;

  }

  FilterProducts(categoryId: number) {
    console.log('Selected Category ID:', categoryId);
    if (categoryId === 0) {
      this.products = DUMMY_PRODUCTS;
    } else {
      this.products = DUMMY_PRODUCTS.filter(product => product.catId === categoryId);
    }
  }
}
