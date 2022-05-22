import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

import { UserLoginComponent } from '../user-login/user-login.component';
import { Game } from '../_models/game.model';
import { CardGameDataService } from '../_services/cardGame.data-service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  //template: '<app-user-login [userLogin]="data"></app-user-login>',
})
export class NavMenuComponent implements OnInit, OnDestroy {
  isExpanded = true;
  data: any = {}
  @Input() games: Game[] = [];

  filter: string = '';
  debounce: Subject<string> = new Subject<string>()

  page: number = 0;
  size: number = 5;

  activateStore: boolean = false;
  activateLibrary: boolean = false;
  activateWishList: boolean = false;
  activateCart: boolean = true;

  constructor(private userLoginComponent: UserLoginComponent, private activatedRoute: ActivatedRoute, private cardGameDataService: CardGameDataService) {

  }

  ngOnInit() {
    //this.data = localStorage.setItem('user_logged').J;
    this.data = localStorage.getItem('user_logged');
    this.data = JSON.parse(this.data);
    //this.getAll()

    this.debounce.pipe(debounceTime(300)).subscribe(filter => this.filter = filter);
    //this.data = this.userLoginComponent.authenticate;
    //console.log(this.data);
  }

  onKeyUp(target: any) {
    if (target instanceof EventTarget) {
      var elemento = target as HTMLInputElement;
      //this.filter = elemento.value;
      console.log("testeufwedjopci uasdyfchjdas " + elemento.value)
      this.debounce.next(elemento.value);
      console.log("filter: " + this.filter)
    }
  }

  ngOnDestroy(): void {
    this.debounce.unsubscribe();
  }

  showStore() {
    this.activateStore = true;
    this.activateLibrary = false;
    this.activateWishList = false;
    this.activateCart = false;
  }

  showLibrary() {
    this.activateStore = false;
    this.activateLibrary = true;
    this.activateWishList = false;
    this.activateCart = false;
  }

  showWishList() {
    this.activateStore = false;
    this.activateLibrary = false;
    this.activateWishList = true;
    this.activateCart = false;
  }

  showCart() {
    this.activateStore = false;
    this.activateLibrary = false;
    this.activateWishList = false;
    this.activateCart = true;
  }

  collapse() {
    this.isExpanded = true;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getAll() {
    this.cardGameDataService.get(this.page, this.size).subscribe((data: any) => {
      this.games = data;
    }, error => {
      console.log(error);
    })
  }
}
