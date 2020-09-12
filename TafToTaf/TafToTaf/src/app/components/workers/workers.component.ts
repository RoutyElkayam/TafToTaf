import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfessionalService } from 'src/app/shared/services/professional.service';
import { Professional } from 'src/app/shared/models/professional';
import { InsertWorkerComponent } from '../insert-worker/insert-worker.component';
import { EditWorkerComponent } from '../edit-worker/edit-worker.component';
import { DeleteWorkerComponent } from '../delete-worker/delete-worker.component';
import { ProfessionKind } from 'src/app/shared/models/professionKind';
const professions:ProfessionKind[]=
[
  {id:1,name:"קלינאית תקשורת"},
  {id:2,name:"מרפאה בעיסוק"},
  {id:3,name:"פיזיותרפיסטית"}
]
@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./workers.component.scss']
})

export class WorkersComponent implements OnInit {

  professionals:Professional[];

  constructor(
    private modalService: NgbModal,
    private WorkerService:ProfessionalService
  ) { }

  ngOnInit() {
    this.getWorkers();
  }
  getWorkers(){
    this.WorkerService.getProfessionals().subscribe(res=>this.professionals=res);
  }
  sendProfessional(){
    const modalRef = this.modalService.open(InsertWorkerComponent);
    modalRef.result.then((result) => { 
      this.getWorkers();
    }).catch((res) => {
      this.getWorkers();  
    });
  }
  edit(professional:Professional)
  {
    const modalRef = this.modalService.open(EditWorkerComponent);
    modalRef.componentInstance.professional = professional;
    modalRef.result.then((result) => {
     
      this.getWorkers();
    }).catch((res) => {
      this.getWorkers();
      
    });
  }
  delete(professional:Professional)
  {
    const modalRef = this.modalService.open(DeleteWorkerComponent);
    modalRef.componentInstance.proffessional = professional;
    modalRef.result.then((result) => {
     
      this.getWorkers();
    }).catch((res) => {
      this.getWorkers();
      
    });
  }
  isWorkToday(bitDayOfWork):string{
    if(bitDayOfWork==true)
     return "עובדת";
    return "לא עובדת ";
  }
  getProfessionName(id:number){
   return professions[id-1].name;
  }
}
