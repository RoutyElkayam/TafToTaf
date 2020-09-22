import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { ProfessionalService } from 'src/app/shared/services/professional.service';

@Component({
  selector: 'worker-main',
  templateUrl: './worker-main.component.html',
  styleUrls: ['./worker-main.component.scss']
})
export class WorkerMainComponent implements OnInit {

  constructor(private accontService:AccountService,
   private workerService:ProfessionalService) { }

  ngOnInit() {
    this.getWorkerUserId();
  }
  getWorkerUserId(): void{
    this.workerService.getWorkerOfUser().subscribe(
      w=>{this.accontService.userProffesional=w});
  }
}
