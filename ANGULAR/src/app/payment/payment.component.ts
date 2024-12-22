import { Component } from '@angular/core';
import { ShopServiceService } from '../shop-service.service';


@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [],
  templateUrl: './payment.component.html'
})
export class PaymentComponent {
  sumAll:number;
  birthday:Date;
  // const today= new Date();
  
  constructor(private shopService:ShopServiceService) {
    this.sumAll=this.shopService.sum
  }

}
