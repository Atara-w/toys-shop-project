import { Component } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';
import { Product } from '../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { subscribe } from 'node:diagnostics_channel';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ProductDetailsComponent],
  templateUrl: './products.component.html'
})
export class ProductsComponent {
  productsList: Product[];
  age: number = 0;
  isSelected: boolean = false;
  currentProduct: Product;
  constructor(private shopService: ShopServiceService) {
    //כותבים כך אם לא מתחברים למסד
    // this.shop_service.get_products_list().then(data => this.products_list = data).catch(err => console.log(err));
    this.shopService.getProductsList().subscribe(
      data => { this.productsList = data; },
      // לא תואמים אז כותבים ככהANGULAR ו C# אם השמות של
      // this.products_list = new Array<Product>();
      // data.forEach(p => { this.products_list.push(new Product(p)) })
      err => { console.log(err); }
    )
  }
  lowToHighSortList() {
    this.productsList = this.productsList.sort((a: Product, b: Product) => a.productPrice - b.productPrice)
  }
  highToLowSortList() {
    this.productsList = this.productsList.sort((a: Product, b: Product) => b.productPrice - a.productPrice)
  }
  ageFilter() {
    if (this.age != 0) {
      this.productsList = this.productsList.filter((a: Product) => a.productAge <= this.age)
    }
  }
  openProductDetail(selectedProduct: Product) {
    this.isSelected = true;
    this.currentProduct = selectedProduct;
  }
  returnToList() {
    this.isSelected = false;
  }
  selectedOption:string;
  onSelectionChange(categoryName:string){
    this.shopService.getProguctsByCategoryFilter(categoryName).subscribe(
      data => { this.productsList = data; },
      err => { console.log(err); }
    )
  }
}
