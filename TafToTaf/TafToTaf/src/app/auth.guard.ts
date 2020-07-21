import { Injectable } from '@angular/core';
import { Router,CanActivate,ActivatedRouteSnapshot,RouterStateSnapshot} from '@angular/router';
import { AccountService } from './shared/services/account.service';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate{
    constructor(private router:Router,private account:AccountService){}
    canActivate( route:ActivatedRouteSnapshot, state:RouterStateSnapshot)
    {
      if(this.account.currentUser()){
          return true;
      }
      this.router.navigate([""]);
      return false;
    }
}
  