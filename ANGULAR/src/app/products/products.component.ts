import { Component } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';
import { Product } from '../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { subscribe } from 'node:diagnostics_channel';
import { Category } from '../models/category';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ProductDetailsComponent],
  templateUrl: './products.component.html'
})
export class ProductsComponent {
  categoryList: Category[];
  productsList: Product[];
  age: number = 0;
  isSelected: boolean = false;
  currentProduct: Product;

  constructor(private shopService: ShopServiceService) {
    //כותבים כך אם לא מתחברים למסד
    // this.shop_service.get_products_list().then(data => this.products_list = data).catch(err => console.log(err));
   //שליפת רשימת המוצרים
    this.shopService.getProductsList().subscribe(
      {
        next: ((data: Product[]) => this.productsList = data),
        error: ((error: any) => console.log(error))
      }
    )
    //שליפת רשימת קטגוריות
    this.shopService.getCategoriesList().subscribe({
      next: ((category: Category[]) => this.categoryList = category),
      error: ((error: any) => console.log(error))
    }
    )
  }
  //פונקצית מיון מחיר מהנמוך לגבוה
  lowToHighSortList() {
    this.productsList = this.productsList.sort((a: Product, b: Product) => a.productPrice - b.productPrice)
  }
  //פונקציית מיון מחיר מהגבוה לנמוך
  highToLowSortList() {
    this.productsList = this.productsList.sort((a: Product, b: Product) => b.productPrice - a.productPrice)
  }
  //פונקצית סינון לפי גיל (באנגולר)
  ageFilter() {
    if (this.age != 0) {
      this.productsList = this.productsList.filter((a: Product) => a.productAge <= this.age)
    }
  }
  //בלחיצה על מוצר פתיחת הקומפוננטה של המוצר
  openProductDetail(selectedProduct: Product) {
    this.isSelected = true;
    this.currentProduct = selectedProduct;
  }
  //חזרה לדף מוצרים
  returnToList() {
    this.isSelected = false;
  }
//(C#פונקצית סינון לפי קטגוריה (ב
  onCategoryChange() {
    const ids = new Array<number>();
    this.categoryList.forEach(c => { if (c.isSelected) ids.push(c.categoryId) });
    this.shopService.getProguctsByCategoryFilter(ids).subscribe({
      next: ((data: Product[]) => this.productsList = data),
      error: ((error: any) => console.log(error))
    })
  }

}
