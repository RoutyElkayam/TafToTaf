import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-parent-main',
  templateUrl: './parent-main.component.html',
  styleUrls: ['./parent-main.component.scss']
})
export class ParentMainComponent implements OnInit {

  constructor(private account:AccountService) { }

  ngOnInit() {
    this.account.getChildOfUser().subscribe(
      res=>this.account.userChild=res);
  }

}
