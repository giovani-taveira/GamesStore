import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Game } from '../_models/game.model';
import { CardGameDataService } from '../_services/cardGame.data-service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent implements OnInit {

  @Input() games: Game[] = [];
  userLogged: any;

  page: number = 0;
  size: number = 5;

  constructor(private cardGameDataService: CardGameDataService, private router: Router) { }

  ngOnInit(): void {
    this.getAll();
    this.getUserData();
  }

  getAll() {
    this.cardGameDataService.get(this.page, this.size).subscribe((data: any) => {
      this.games = data;
    }, error => {
      console.log(error);
    })
  }

  getFromCart() {
    this.cardGameDataService.getFromCart(this.userLogged.user.userId).subscribe((data: any) => {
      this.games = data.games;
    }, error => {
      console.log(error);
    })
  }

  description() {
    this.router.navigate(['login'])
  }

  getUserData() {
    this.userLogged = localStorage.getItem('user_logged');
    this.userLogged = JSON.parse(this.userLogged);
    console.log(this.userLogged);

    return this.userLogged
  }
}
