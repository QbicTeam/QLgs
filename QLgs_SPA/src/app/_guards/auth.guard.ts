import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../securitas/_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private _authService: AuthService, private router: Router, private _alertify: AlertifyService) {}

  canActivate(): boolean {

    if( this._authService.loggedIn()) {
      return true;
    }

    this._alertify.error("El token no es valido, Ingrese sus credenciales");
    this.router.navigate(['/home']);
    return false;
    
  }
  
}
