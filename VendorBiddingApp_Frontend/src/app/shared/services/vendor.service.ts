import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vendor } from '../models/Vendor';

@Injectable({
  providedIn: 'root'
})
export class VendorService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addVendor(vendor: Vendor): Observable<Vendor> {
    return this.http.post<Vendor>(`${this.apiUrl}/vendors`, vendor);
  }

  getVendorById(vendorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/vendors/${vendorId}`);
  }
}

