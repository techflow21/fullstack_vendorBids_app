import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../shared/services/auth.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent {
  vendorName: string | null = null;
  isCollapsed = true;

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.vendorName = this.getVendorName();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  toggleNavbar(): void {
    this.isCollapsed = !this.isCollapsed;
  }

  getVendorName(): string | null {
    const userData = this.authService.getVendorInfo();
    return userData ? userData.VendorName : null;
  }
}

