import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../shared/services/account.service';
import { Router } from '@angular/router';
import { User } from '../../shared/models/user';
import { IfStmt } from '@angular/compiler';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  username: string=null;
  password: string=null;
  user: User;
  message = {error: ''};
  isLoading:boolean=false;
  isNullValues=false;
  
  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit() {
    if(this.accountService.token())
    {
      this.navigationByKindUser();
    }
  }

  login() {
    if(this.username==null||this.password==null)
      this.isNullValues=true;
    else  
      {
        this.isNullValues=false;
       this.accountService.login(this.username, this.password).subscribe((res:string )=> {
       localStorage.setItem('token',res)
       this.navigationByKindUser()}
       ,(err:HttpErrorResponse)=>{if(err.message)this.isNullValues=true;}); 
      }
  }
  navigationByKindUser()
  {
      this.isLoading=true;
      this.accountService.getUser().subscribe((res)=>
      {
      this.accountService.currentUser=res;
      if(this.accountService.currentUser)
        {
          if (this.accountService.currentUser.kindUser == 1) {
          this.router.navigate(["admin-main"])
          }
          if (this.accountService.currentUser.kindUser == 2) {
            this.router.navigate(["worker-main"])
          }
          if (this.accountService.currentUser.kindUser == 3) {
            this.router.navigate(["parent-main"])
          }

        }
      else this.isNullValues=true;
      this.isLoading=false;
    });
  }
}
    

