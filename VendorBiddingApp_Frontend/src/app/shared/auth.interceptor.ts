import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './services/auth.service';
import { catchError, Observable} from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService, private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getToken();

    // Clone the request to add the new headers.
    let authReq = req;
    if (token) {
      authReq = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    // Pass on the cloned request instead of the original request.
    return next.handle(authReq).pipe(
      catchError(err => {
        if (err.status === 401) {
          this.authService.logout();
          this.router.navigate(['/login']);
        }
        throw err;
      })
    );
  }
}

