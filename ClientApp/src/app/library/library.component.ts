import { Component, OnInit } from '@angular/core';
import { CartDataService } from '../_services/cart-data-service';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {

  games: any[] = [];

  constructor(private cartDataService: CartDataService) { }

  ngOnInit(): void {
    this.getFromCart();
    console.log('Entrei no Init')
  }

  getFromCart() {
    let userLogged: any = localStorage.getItem('user_logged');
    userLogged = JSON.parse(userLogged);
    this.cartDataService.getFromCart(userLogged.user.userId).subscribe((data: any) => {
      this.games = data.games;
    }, error => {
      console.log(error);
    })
  }


}
