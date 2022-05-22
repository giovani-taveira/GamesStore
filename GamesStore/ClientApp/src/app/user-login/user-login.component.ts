import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginDataService } from '../_services/user-login';

@Component({
  selector: 'app-user-login',
  template: `
    <app-nav-menu [data]={{variavel}}></app-nav-menu>
`,
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private userLoginDataService: UserLoginDataService, private router: Router ) { }

  variavel: string = "Hellio World!";
  users: any[] = [];
  userLogin: any = {};
  userLogged: any = {};
  IsAuthenticate: boolean = false;

  ngOnInit(): void {
  }

  get() {
    this.userLoginDataService.get().subscribe((data: any) => {
      this.users = data;

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  authenticate() {
    this.userLoginDataService.authenticate(this.userLogin).subscribe((data: any) => {
      console.log(data);
      if (data.user) {
        localStorage.setItem('user_logged', JSON.stringify(data));
        this.userLogin = data;
        this.IsAuthenticate = true;
        this.get();
        this.getUserData();

        console.log("ta aqui" + this.userLogin);
      } else {
        alert('User invalid.');
      }
    }, error => {
      console.log(error);
      alert('User invalid');
    })
  }

  getUserData() {
    this.userLogged = localStorage.getItem('user_logged');
    this.userLogged = JSON.parse(this.userLogged);
    this.IsAuthenticate = this.userLogged != null;
    console.log(this.userLogged);
  }
}
