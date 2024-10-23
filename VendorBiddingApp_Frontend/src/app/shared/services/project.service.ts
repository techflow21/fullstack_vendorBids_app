import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../models/Project';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addProject(projectData: Project): Observable<Project> {
    return this.http.post<Project>(`${this.apiUrl}/projects`, projectData);
  }

  getProjects(): Observable<any> {
    return this.http.get(`${this.apiUrl}/projects`);
  }

  getProjectDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/projects/${id}`);
  }
}
