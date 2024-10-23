import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../shared/services/auth.service';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { VendorService } from '../../shared/services/vendor.service';

@Component({
  selector: 'app-add-vendor',
  standalone: true,
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
  templateUrl: './add-vendor.component.html',
  styleUrl: './add-vendor.component.css'
})

export class AddVendorComponent {
  registerForm: FormGroup;
  backendErrors: string[] = [];

  constructor(private fb: FormBuilder, private authService: AuthService, private vendorService: VendorService, private router: Router) {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  ngOnInit(): void {
    if (this.authService.isAuthenticated())
      this.router.navigateByUrl('/projects')
  }

  addNewVendor() {
    if (this.registerForm.valid) {
      this.vendorService.addVendor(this.registerForm.value).subscribe({
        next: () => this.router.navigate(['/login']),
        error: (error) => {
          this.backendErrors = error.error.errors || [error.error.message];
        }
      });
    }
  }
}