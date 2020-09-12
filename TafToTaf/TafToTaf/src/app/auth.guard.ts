import { Injectable } from '@angular/core';
import { Router,CanActivate,ActivatedRouteSnapshot,RouterStateSnapshot} from '@angular/router';
import { AccountService } from './shared/services/account.service';

@Injectable({providedIn: 'root'})

export class AuthGuardAdmin implements CanActivate{
    private kindUser:number;

    constructor(private router:Router,private account:AccountService){}

    canActivate( route:ActivatedRouteSnapshot, state:RouterStateSnapshot)
    {
      if(this.account.currentUser)
       {
        if(this.account.currentUser.kindUser==1)
          return true;
       }
      this.router.navigate(["login"]);
      return false;
    }
}
@Injectable({providedIn: 'root'})
export class AuthGuardWorker implements CanActivate{
  private kindUser:number;

  constructor(private router:Router,private account:AccountService){}

  canActivate( route:ActivatedRouteSnapshot, state:RouterStateSnapshot)//מאפשרת לפי תנאי להתמתב לדפים
  {
    if(this.account.currentUser)
     {
      if(this.account.currentUser.kindUser==2)
        return true;
     }
    this.router.navigate(["login"]);
    return false;
  }
}
@Injectable({providedIn: 'root'})
export class AuthGuardParent implements CanActivate{
  private kindUser:number;

  constructor(private router:Router,private account:AccountService){}

  canActivate( route:ActivatedRouteSnapshot, state:RouterStateSnapshot)
  {
    if(this.account.currentUser)
     {
       if(this.account.currentUser.kindUser==3)
        return true;
     }
    this.router.navigate(["login"]);
    return false;
  }
}
  