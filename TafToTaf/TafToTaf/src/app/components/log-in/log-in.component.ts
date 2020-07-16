import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../shared/services/account.service';
import { Router } from '@angular/router';
import { User } from '../../shared/models/user';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  username: string;
  password: string;
  user: User;
  constructor(public accountService: AccountService,
    public router: Router) { }

  ngOnInit() {
  }

  login() {
    this.accountService.login(this.username, this.password).subscribe(res => {
      this.user = res;
      if (this.user) {
        if (this.user.KindUser == 1) {
          this.router.navigate(["admin-main"])
        }
        if (this.user.KindUser == 2) {
          this.router.navigate(["worker-main"])
        }
        if (this.user.KindUser == 3) {
          this.router.navigate(["parent-main"])
        }
      }
      else alert("UserName or Password are not valid!")
    },err=>{
      alert("UserName or Password are not valid!");
    });

  }

}
