import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('authToken');  // Pobierz token z localStorage

  if (token) {
    const clonedRequest = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    console.log('Token found and added to headers:', token);
    return next(clonedRequest);  // Kontynuuj przetwarzanie żądania z tokenem
  } else {
    console.log('No token found, proceeding without Authorization header.');
    return next(req);  // Kontynuuj przetwarzanie żądania bez tokena
  }
};
