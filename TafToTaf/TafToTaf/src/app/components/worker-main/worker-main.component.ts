import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'worker-main',
  templateUrl: './worker-main.component.html',
  styleUrls: ['./worker-main.component.scss']
})
export class WorkerMainComponent implements OnInit {

  constructor(private accontService:AccountService) { }

  ngOnInit() {
    this.getWorkerUserId();
  }
  getWorkerUserId(): void{
    this.accontService.getWorkerOfUser().subscribe(
      w=>{this.accontService.userWorker=w});
  }
}
