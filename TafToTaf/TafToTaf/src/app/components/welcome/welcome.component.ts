import { Component, OnInit,Input } from '@angular/core';
import { AccountService } from  '../../shared/services/account.service';
@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {

  constructor(public userService:AccountService) { }
  @Input() name;
  ngOnInit() {
  }

}
