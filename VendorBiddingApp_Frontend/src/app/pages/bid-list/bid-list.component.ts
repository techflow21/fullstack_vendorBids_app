import { Component, OnInit } from '@angular/core';
import { Bid } from '../../shared/models/bid';
import { BidService } from '../../shared/services/bid.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-bid-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './bid-list.component.html',
  styleUrl: './bid-list.component.css'
})
export class BidListComponent implements OnInit {
  bids: Bid[] = [];  // Strongly typed array of Bid objects
  backendErrors: string[] = [];

  constructor(private bidService: BidService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    //const vendorId = this.route.snapshot.paramMap.get('vendorId');
    this.bidService.getBidsByVendor().subscribe({
      next: (data: Bid[]) => {
        this.bids = data;
      },
      error: (error) => {
        this.backendErrors = error.error.errors || [error.error.message];
      }
    });
  }
}