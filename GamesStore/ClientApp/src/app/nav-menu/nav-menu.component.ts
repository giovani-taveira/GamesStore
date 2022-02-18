import { Component, Input, OnInit } from '@angular/core';
import { UserLoginComponent } from '../user-login/user-login.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  //template: '<app-user-login [userLogin]="data"></app-user-login>',
})
export class NavMenuComponent implements OnInit {
  isExpanded = true;
  data: any = {}

  constructor(private userLoginComponent: UserLoginComponent) {
    console.log("Ta na mão " + this.data);
  }

  ngOnInit() {
    //this.data = localStorage.setItem('user_logged').J;
    //this.data = JSON.parse(localStorage.getItem('user_logged'));
    this.data = this.userLoginComponent.authenticate;
    console.log(this.data.arguments);
  }

  collapse() {
    this.isExpanded = true;

  }

  toggle() {
    this.isExpanded = !this.isExpanded;

  }
}
