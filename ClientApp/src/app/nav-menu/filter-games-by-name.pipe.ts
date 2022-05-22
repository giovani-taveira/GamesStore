import { OnInit, Pipe, PipeTransform } from "@angular/core";
import { Game } from "../_models/game.model";
import { CardGameDataService } from "../_services/cardGame.data-service";


@Pipe({ name: 'filterGamesByName' })
export class FilterGamesByName implements PipeTransform, OnInit {

  constructor() { }

  ngOnInit(): void {

  }

  transform(games: Game[], nameQuery: string) {
    nameQuery = nameQuery
      .trim()
      .toLowerCase();

    if (nameQuery) {
      console.log(" EIUHC " + games.filter(game =>
        game.name.toLowerCase().includes(nameQuery)))

      return games.filter(game =>
        game.name.toLowerCase().includes(nameQuery)
      );
    } else {
      return games;
    }
  }
}
