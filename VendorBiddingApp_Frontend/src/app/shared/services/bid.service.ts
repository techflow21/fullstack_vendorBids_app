import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bid } from '../models/bid';


@Injectable({
  providedIn: 'root'
})
export class BidService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  submitBid(bidData: { amount: number }, projectId: string): Observable<Bid> {
    return this.http.post<Bid>(`${this.apiUrl}/bids/?projectId=${projectId}`, bidData);
  }

  getBidsByVendor(): Observable<Bid[]> {
    return this.http.get<Bid[]>(`${this.apiUrl}/bids`);
  }
}
