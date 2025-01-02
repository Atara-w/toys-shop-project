import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ShopServiceService } from '../shop-service.service';
import { Customer } from '../models/customer';
import { CommonModule } from '@angular/common';
import {  Router } from '@angular/router';


@Component({
  selector: 'app-sign-up-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './sign-up-login.component.html'
})
export class SignUpLoginComponent {
  email: string;
  password: string;
  succeed = true;
  notFull = false;
  constructor(private shopService: ShopServiceService, private router: Router) {
  }
  signIn() {
    this.shopService.signIn(this.email, this.password).subscribe({
      next: ((data: Customer) => this.router.navigate(['/home-page'])),
      error: (error: any) => {
        if (error.status == 500) {
          this.notFull=false;
          this.succeed = false;
        }
        else if (error.status == 400) {
          this.notFull = true;
        }
        else {
          console.log(error);
        }
      }
    }
    )
  }
}