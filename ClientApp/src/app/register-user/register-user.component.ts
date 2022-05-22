import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginDataService } from '../_services/user-login';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  constructor(private userLoginDataService: UserLoginDataService, private router: Router ) { }

  userSingUp: any = {};

  ngOnInit(): void {
  }


  postUser() {
    this.userLoginDataService.AddNewUser(this.userSingUp).subscribe((data: any) => {
      console.log(data);
      this.router.navigate(['login'])

    }, error => {
      console.log(error);
      alert(error);
    })
  }
}
