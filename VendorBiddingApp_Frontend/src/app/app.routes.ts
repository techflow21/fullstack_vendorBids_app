import { Routes } from '@angular/router';
import { ProjectListComponent } from './pages/project-list/project-list.component';
import { ProjectDetailsComponent } from './pages/project-details/project-details.component';
import { BidListComponent } from './pages/bid-list/bid-list.component';
import { LoginComponent } from './pages/login/login.component';
import { AddVendorComponent } from './pages/add-vendor/add-vendor.component';
import { authGuard } from './shared/auth.guard';
import { NewProjectComponent } from './pages/new-project/new-project.component';

export const routes: Routes = [
    { path: '', component: ProjectListComponent },
  { path: 'projects', component: ProjectListComponent },
  { path: 'projects/:id', component: ProjectDetailsComponent },
  { path: 'bids', component: BidListComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'add-vendor', component: AddVendorComponent },
  { path: 'add-project', component: NewProjectComponent, canActivate: [authGuard] },
  { path: '**', redirectTo: '' }
];
