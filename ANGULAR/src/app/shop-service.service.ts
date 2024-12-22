import { Injectable } from '@angular/core';
import { Product } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ShopServiceService {
  //כותבים כך אם לא מתחברים למסד
  // products_list: Product[] = [
  //   new Product(1, 'monopoly', 1, 5, 'A strategic thinking game for the whole family', 150, '', new Date(2020, 4, 13), 10),
  //   new Product(2, 'laughing doll', 2, 2, 'A sweet laughing and singing doll', 85, '', new Date(2009, 5, 9), 1),
  //   new Product(3, 'football', 3, 6, 'Medium size', 45, '', new Date(2022, 7, 21), 9),
  //   new Product(4, 'puzzle', 1, 3, '120 pices', 100, '', new Date(2023, 4, 30), 4)
  // ]
  // constructor() {    
  // }
  // get_products_list(): Promise<Product[]> {
  //   return Promise.resolve(this.products_list);
  // }

  constructor(private http: HttpClient) {
  }

  getProductsList(): Observable<Product[]> {
    return this.http.get<Product[]>("http://localhost:5093/api/Products");
  }
  getProguctsByCategoryFilter(categoryName: string): Observable<Product[]> {
    return this.http.get<Product[]>("http://localhost:5093/api/Products/category filter")
  }

  cartProductsList: Product[] = [];
  getCartProductsList(): Promise<Product[]> {
    return Promise.resolve(this.cartProductsList);
  }


  login(email: string, password: string): Observable<any> {
    const loginData = { email, password };  // נתונים שנשלחים ל-API
    return this.http.post<any>('', loginData); // קריאת POST ל-API
  }

  sum: number = 0;
}
