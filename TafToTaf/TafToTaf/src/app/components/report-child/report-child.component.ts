import { Component, OnInit } from '@angular/core';
import { Child } from 'src/app/shared/models/child';
import { AccountService } from 'src/app/shared/services/account.service';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
  pink: {
    primary: '#ea1ea4',
    secondary: '#e789c7',
  }
};

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
