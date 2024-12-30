import { Component, Input, Output } from '@angular/core';
import { Product } from '../models/product';
// import { EventEmitter } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterOutlet, RouterLink } from '@angular/router';
import { error } from 'console';



@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, RouterOutlet],
  templateUrl: './cart.component.html'
})
export class CartComponent {
  // @Input() product:Product;
  // @Output() return_to_list = new EventEmitter<void>();
  // go_back(){
  //   this.return_to_list.emit();
  // }
  // sum:number;
  above5000 = false;
  cartProductsList: Product[];
  sumAll: number;
  constructor(private shopService: ShopServiceService, private router: Router) {
    this.shopService.getCartProductsList().then(data => this.cartProductsList = data).catch(err => console.log(err));
    this.sumAll = this.shopService.sum
  }
  removeProduct(product: Product) {
    this.cartProductsList = this.cartProductsList.filter(m => m != product);
    this.shopService.cartProductsList = this.cartProductsList;
    this.sumAll -= product.productPrice
    this.shopService.sum=this.sumAll;
    if (+this.sumAll <= 200) {
      this.above5000 = false;
    }
    // console.log(this.shopService.sum);
  }
  isAbove5000() {
    if (+this.sumAll > 200) {
      this.above5000 = true;
    }
    else {
      //DB להעביר את הקניה ל
      this.router.navigate(['/payment']);
    }

  }

}
