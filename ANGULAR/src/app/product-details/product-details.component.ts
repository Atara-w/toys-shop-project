import { Component, Input, Output, output } from '@angular/core';
import { Product } from '../models/product';
import { EventEmitter } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-details.component.html'
})
export class ProductDetailsComponent {
  showMessage=false;
  @Input() product: Product;
  @Output() returnToList = new EventEmitter<void>();
  goBack() {
    this.returnToList.emit();
  }

  constructor(private shopService: ShopServiceService) {
  }

  addToCart() {
    this.shopService.cartProductsList.push(this.product);
    this.shopService.sum = this.shopService.sum + this.product.productPrice;
    this.showMessage=true;
    setTimeout(() => {
      this.showMessage = false;  // מסתיר את ההודעה אחרי 2 שניות
    }, 1000);
  }

}
