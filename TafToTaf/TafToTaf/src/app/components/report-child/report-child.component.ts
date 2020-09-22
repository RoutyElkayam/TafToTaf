import { Component, OnInit } from '@angular/core';
import { Child } from 'src/app/shared/models/child';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-report-child',
  templateUrl: './report-child.component.html',
  styleUrls: ['./report-child.component.scss']
})
export class ReportChildComponent implements OnInit {
  public date:string=new Date(2020+"/"+9+"/"+1).toDateString();
  constructor(public accountService: AccountService) {

   }

  ngOnInit() {
  }

}
