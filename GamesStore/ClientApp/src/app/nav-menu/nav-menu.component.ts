import { Component, Input, OnInit } from '@angular/core';
import { empty } from 'rxjs';
import { UserLoginComponent } from '../user-login/user-login.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],

})
export class NavMenuComponent implements OnInit {
  isExpanded = true;
  @Input() data: any = {};

  constructor() { }

  ngOnInit() {
    this.data = localStorage.getItem('user_logged')
    this.data = JSON.parse(this.data);
    console.log(this.data);
  }

  collapse() {
    this.isExpanded = true;

  }

  toggle() {
    this.isExpanded = !this.isExpanded;

  }
}
