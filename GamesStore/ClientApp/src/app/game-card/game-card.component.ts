import { Component, OnInit } from '@angular/core';
import { CardGameDataService } from '../_services/cardGame.data-service';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent implements OnInit {

  games: any[] = [];

  constructor(private cardGameDataService: CardGameDataService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.cardGameDataService.get().subscribe((data: any) => {
      this.games = data;
    }, error => {
      console.log(error);
    })
  }
}
