import { Routes } from '@angular/router';
import { RegisterComponent } from './auth/register/register.component';
import {LoginComponent} from "./auth/login/login.component";
import { TaskListComponent } from "./tasks/task-list/task-list.component";
import { TaskFormComponent } from "./tasks/task-form/task-form.component";
import { authGuard } from "./services/auth.guard";

export const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent},
  { path: 'tasks', component: TaskListComponent, canActivate: [authGuard]},
  { path: 'tasks/form', component: TaskFormComponent, canActivate: [authGuard]},
  { path: '**', redirectTo: 'login' }
];
