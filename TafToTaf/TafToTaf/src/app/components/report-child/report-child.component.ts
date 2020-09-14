import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-report-child',
  templateUrl: './report-child.component.html',
  styleUrls: ['./report-child.component.scss']
})
export class ReportChildComponent implements OnInit {

  constructor(public accountService: AccountService) {

   }

  ngOnInit() {
  }

}
