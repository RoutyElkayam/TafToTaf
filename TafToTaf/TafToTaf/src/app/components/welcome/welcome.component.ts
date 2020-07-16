import { Component, OnInit } from '@angular/core';
import { AccountService } from  '../../shared/services/account.service';
@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {

  constructor(private userService:AccountService) { }
  
  ngOnInit() {
  }

}
