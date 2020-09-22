import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { ChildService } from 'src/app/shared/services/child.service';

@Component({
  selector: 'app-parent-main',
  templateUrl: './parent-main.component.html',
  styleUrls: ['./parent-main.component.scss']
})
export class ParentMainComponent implements OnInit {

  constructor(private childService:ChildService,
    private account:AccountService) { }

  ngOnInit() {
    this.childService.getChildOfUser().subscribe(
      res=>{this.account.userChild=res,console.log(this.account.userChild)});
  }

}
