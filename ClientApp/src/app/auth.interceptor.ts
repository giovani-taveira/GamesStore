import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLoginComponent } from './user-login/user-login.component';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: UserLoginComponent) { }

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {

    var _user: any = JSON.parse(this.authService.getToken);
    request = request.clone({
      headers: request.headers.set('authorization', (_user && _user.token) ? 'Bearer ' + _user.token : ''),
    });
    return next.handle(request);
  }
}

export const AuthInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: AuthInterceptor,
  multi: true,
};
