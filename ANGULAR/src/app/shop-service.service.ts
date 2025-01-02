import { Injectable } from '@angular/core';
import { Product } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from './models/category';
import { Customer } from './models/customer';


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
  // //C#ל idsושליחת מערך ה postל C#שינוי הפונקציה ב
  // getProguctsByCategoryFilter(categoriesIds: Array<number>): Observable<Product[]> {
  //   console.log(categoriesIds);
  //   return this.http.post<Product[]>("http://localhost:5093/api/Products/categoryFilter", categoriesIds);
  // }
  // getProguctsByPriceFilter(price: number): Observable<Product[]> {
  //   console.log(price);
  //   return this.http.post<Product[]>(`http://localhost:5093/api/Products/priceFilter?price=${price}`, null)
  // }
  filters(categoriesIds: Array<number>, price: number) {
    if (price >= 0)
      return this.http.post<Product[]>(`http://localhost:5093/api/Products/filters?price=${price}`, categoriesIds)
    else
      return this.http.post<Product[]>("http://localhost:5093/api/Products/filters", categoriesIds)

  }
  getCategoriesList(): Observable<Category[]> {
    return this.http.get<Category[]>("http://localhost:5093/api/Categories/getCategories")
  }
  cartProductsList: Product[] = [];
  getCartProductsList(): Promise<Product[]> {
    return Promise.resolve(this.cartProductsList);
  }


  signIn(email: string, password: string): Observable<Customer> {
    const loginData = { email, password };
    return this.http.post<Customer>("http://localhost:5093/api/Customers", loginData);
  }

  sum: number = 0;
  FilteredProductList: Product[];
}
