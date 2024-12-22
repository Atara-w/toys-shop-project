import { Component, Input, Output, output } from '@angular/core';
import { Product } from '../models/product';
import { EventEmitter } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';
@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [],
  templateUrl: './product-details.component.html'
})
export class ProductDetailsComponent {
  @Input() product: Product;
  @Output() returnToList = new EventEmitter<void>();
  goBack() {
    this.returnToList.emit();
  }

  constructor(private shopService:ShopServiceService ) {
  }

  addToCart() {
    this.shopService.cartProductsList.push(this.product);
    this.shopService.sum=this.shopService.sum+ this.product.productPrice;
    console.log(this.shopService.cartProductsList);
    console.log(this.shopService.sum);
  }
}
