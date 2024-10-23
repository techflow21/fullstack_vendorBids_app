import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ProjectService } from '../../shared/services/project.service';
import { BidService } from '../../shared/services/bid.service';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../shared/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-project-details',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './project-details.component.html',
  styleUrl: './project-details.component.css'
})

export class ProjectDetailsComponent implements OnInit {
  projectId?: string;
  project: any;
  bidForm!: FormGroup;
  backendErrors: string[] = [];
  modalRef: NgbModalRef | null = null; 

  constructor(
        private route: ActivatedRoute,
        private projectService: ProjectService,
        public authService: AuthService,
        private bidService: BidService,
        private fb: FormBuilder,
        private toastr: ToastrService,
        private modalService: NgbModal
      ) {  }

    ngOnInit(): void {
    this.bidForm = this.fb.group({
      amount: ['', Validators.required]
    });
    this.projectId = this.route.snapshot.paramMap.get('id')!;
    this.projectService.getProjectDetails(this.projectId).subscribe({
      next: (data) => {
        this.project = data;
      },
      error: (error) => {
        this.backendErrors = error.error.errors || [error.error.message];
      }
    });
  }

  openBidModal(content: any) {
    this.modalRef = this.modalService.open(content);
  }

  submitBid() {
    if (this.bidForm.valid) {
      this.bidService.submitBid(this.bidForm.value, this.projectId!).subscribe({
        next: () => {
          this.toastr.success('Bid submitted successfully!');
          if (this.modalRef) {
            this.modalRef.close();
          }
          window.location.reload();
        },
        error: (error) => {
          this.backendErrors = error.error.errors || [error.error.message];
        }
      });
    }
  }
}
