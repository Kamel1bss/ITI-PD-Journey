import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICategory } from '../../interfaces/ICategory';

@Component({
  selector: 'app-product-filter',
  imports: [],
  templateUrl: './product-filter.html',
  styleUrl: './product-filter.css',
})
export class ProductFilter {
  @Input({required: true}) categoryList!: ICategory[];
  @Input({required: true}) totalPrice!: number;
  @Output() categorySelected = new EventEmitter<number>();

  selectedCategoryId: number = 0;
  onCategoryChange(categoryId: number) {
    this.selectedCategoryId = categoryId;
    this.categorySelected.emit(categoryId);
  }
}
