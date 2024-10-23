import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { AuthResponse } from '../models/AuthResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = environment.apiUrl;
  private tokenKey = 'access_token';

  constructor(private http: HttpClient, private router: Router) { }

  login(loginDetails: { email: string, password: string }): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/auth/login`, loginDetails)
      .pipe(
        map(response => {
          if (response && response.token) {
            this.storeToken(response.token);
          }
          return response;
        })
      );
  }

  storeToken(token: string): void {
    sessionStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return sessionStorage.getItem(this.tokenKey);
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token && !this.isTokenExpired(token);
  }

  getVendorInfo(): any {
    const token = this.getToken();
    if (token) {
      return jwtDecode(token);
    }
    return null;
  } 

  logout(): void {
    sessionStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }

  private isTokenExpired(token: string): boolean {
    const decoded: any = jwtDecode(token);
    const expirationDate = decoded.exp * 1000;
    return Date.now() > expirationDate;
  }
}