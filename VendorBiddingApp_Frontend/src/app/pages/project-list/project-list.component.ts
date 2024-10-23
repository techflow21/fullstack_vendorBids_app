import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../shared/services/project.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.css'
})
export class ProjectListComponent implements OnInit {
  projects: any[] = [];
  backendErrors: string[] = [];

  constructor(private projectService: ProjectService, authService: AuthService) { }

  ngOnInit(): void {
    this.projectService.getProjects().subscribe({
      next: (data) => {
        this.projects = data;
      },
      error: (error) => {
        this.backendErrors = error.error.errors || [error.error.message];
      }
    });
  }
}