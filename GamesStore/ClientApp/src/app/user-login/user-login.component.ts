import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { UserLoginDataService } from '../_services/user-login';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private userLoginDataService: UserLoginDataService, private router: Router ) { }

  userLogin: any = {};
  IsAuthenticate: boolean = false;

  ngOnInit(): void {
  }


  authenticate() {
    this.userLoginDataService.authenticate(this.userLogin).subscribe((data: any) => {
      console.log(data);
      if (data.user) {
        localStorage.setItem('user_logged', JSON.stringify(data));
        this.IsAuthenticate = true;

        this.router.navigateByUrl('./nav-menu.component.html');
        //this.get();
        //this.getUserData();
      } else {
        alert('User invalid.');
      }
    }, error => {
      console.log(error);
      alert('User invalid');
    })
  }
}
