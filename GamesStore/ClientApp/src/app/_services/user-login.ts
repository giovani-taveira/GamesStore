import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable()
export class UserLoginDataService {

  module: string = 'https://localhost:7057/api/user/authenticate';

  constructor(private http: HttpClient) { }

  authenticate(data: string) {
    return this.http.post(this.module, data);
  }

}
