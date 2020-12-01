import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { ProfessionalService } from 'src/app/shared/services/professional.service';

@Component({
  selector: 'worker-main',
  templateUrl: './worker-main.component.html',
  styleUrls: ['./worker-main.component.scss']
})
export class WorkerMainComponent implements OnInit {

  constructor(private accountService:AccountService,
   private workerService:ProfessionalService) { }

  ngOnInit() {
    this.getWorkerByUserId();
  }
  getWorkerByUserId(): void {
    console.log(this.accountService.currentUser);
    this.workerService.getWorkerOfUser(this.accountService.currentUser.id).subscribe(
      w=>{this.accountService.userProffesional=w});
  }
}
