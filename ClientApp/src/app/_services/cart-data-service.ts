import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class CartDataService
{
    module: string = 'https://localhost:44318/api/cart';

    constructor(private http: HttpClient) { }

    getFromCart(userId: string) {
      return this.http.get(this.module + '?userId=' + userId);
    }
 }

