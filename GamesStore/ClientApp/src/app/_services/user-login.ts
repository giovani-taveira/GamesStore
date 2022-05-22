import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable()
export class UserLoginDataService {

  module: string = 'https://localhost:7057/api/user';

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.module);
  }

  AddNewUser(data: any) {
    return this.http.post(this.module, data);
  }

  authenticate(data: string) {
    return this.http.post(this.module + '/authenticate', data);
  }

}
