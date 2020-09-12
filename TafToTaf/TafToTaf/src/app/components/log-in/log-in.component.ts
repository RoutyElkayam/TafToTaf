import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../shared/services/account.service';
import { Router } from '@angular/router';
import { User } from '../../shared/models/user';
import { IfStmt } from '@angular/compiler';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  username: string;
  password: string;
  user: User;
  message = {error: ''};
  
  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit() {
    if(this.accountService.token())
    {
      this.navigationByKindUser();
    }
  }

  login() {
    this.accountService.login(this.username, this.password).subscribe((res:string )=> {
      localStorage.setItem('token',res)
      this.navigationByKindUser();}); 
  }
  navigationByKindUser()
  {
      this.accountService.getUser().subscribe(user=>
        {
          this.user=user; console.log(this.user);
           if(this.user)
          {
            if (this.user.kindUser == 1) {
            this.router.navigate(["admin-main"])
          }
          if (this.user.kindUser == 2) {
            this.router.navigate(["worker-main"])
          }
          if (this.user.kindUser == 3) {
            this.router.navigate(["parent-main"])
          }
        }
        else alert("UserName or Password are not valid!");
      },err=>{
        alert("UserName or Password are not valid!");
        this.message.error = err.error.message;
      });
    }
  }
    

