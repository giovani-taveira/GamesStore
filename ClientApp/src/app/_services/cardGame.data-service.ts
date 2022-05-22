import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Game } from "../_models/game.model";

@Injectable()
export class CardGameDataService {

  gameModule: string = 'https://localhost:44318/api/game';
  cartModeule: string = 'https://localhost:44318/api/cart';

  constructor(private http: HttpClient) { }

  get(page: number, size: number) {
    return this.http.get(this.gameModule+`?page=${page}$size=${size}`);
  }
  getFromCart(userId: any) {
    return this.http.get(this.cartModeule + '?userId=' + userId);
  }

  post(data: any) {
    return this.http.post(this.gameModule, data);
  }

  put(data: any) {
    return this.http.put(this.gameModule, data);
  }

  delete() {
    return this.http.delete(this.gameModule);
  }

  authenticate(data: any) {
    return this.http.post(this.gameModule + '/authenticate', data);
  }

}

