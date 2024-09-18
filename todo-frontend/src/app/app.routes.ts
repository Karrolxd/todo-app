import { Routes } from '@angular/router';
import { RegisterComponent } from './auth/register/register.component';

export const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: 'register' } // To sprawi, że domyślnie przekieruje na rejestrację, możesz zmienić
];
