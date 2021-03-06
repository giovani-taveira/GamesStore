import { Component, OnInit } from '@angular/core';
import { UserLoginDataService } from '../_services/user-login';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  constructor(private userLoginDataService: UserLoginDataService) { }

  userSingUp: any = {};

  ngOnInit(): void {
  }


  postUser() {
    this.userLoginDataService.AddNewUser(this.userSingUp).subscribe((data: any) => {
      console.log(data);

      if (data) {
        alert('Cadastro realizado com sucesso!');
      }
      else {
        alert('Ocorreu um erro ao realizar o cadastro');
      }

    }, error => {
      console.log(error);
      alert(error);
    })
  }
}
