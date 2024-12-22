import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { ProductsComponent } from './products/products.component';
import { CartComponent } from './cart/cart.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { PaymentComponent } from './payment/payment.component';
import { SignUpLoginComponent } from './sign-up-login/sign-up-login.component';


export const routes: Routes = [
        { path: 'home-page', component: HomePageComponent },
        { path: 'products', component: ProductsComponent },
        { path: 'cart', component: CartComponent },
        { path: 'payment', component: PaymentComponent },
        { path: 'sign-up-login', component: SignUpLoginComponent },
        { path: '', component: HomePageComponent },
        { path: '**', component: NotFoundComponent },
];
