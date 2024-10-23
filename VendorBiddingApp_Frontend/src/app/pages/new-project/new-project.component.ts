import { Component } from '@angular/core';
import { ProjectService } from '../../shared/services/project.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-project',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './new-project.component.html',
  styleUrl: './new-project.component.css'
})
export class NewProjectComponent {
  projectForm: FormGroup;
  backendErrors: string[] = [];

  constructor(private fb: FormBuilder, private projectService: ProjectService, private router: Router, private toastr: ToastrService) {
    this.projectForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(5)]],
      description: ['', [Validators.required, Validators.minLength(5)]],
    });
  }

  addProject() {
    if (this.projectForm.valid) {
      this.projectService.addProject(this.projectForm.value).subscribe({
        next: () => {
          this.router.navigate(['/projects']);
          this.toastr.success("New project successfully added!")
        },
        error: (error) => {
          this.backendErrors = error.error.errors || [error.error.message];
        }
      });
    }
  }
}
