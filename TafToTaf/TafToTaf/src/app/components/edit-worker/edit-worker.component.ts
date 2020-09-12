import { Component, OnInit, Input } from '@angular/core';
import { Professional } from 'src/app/shared/models/professional';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfessionalService } from 'src/app/shared/services/professional.service';

@Component({
  selector: 'app-edit-worker',
  templateUrl: './edit-worker.component.html',
  styleUrls: ['./edit-worker.component.scss']
})
export class EditWorkerComponent implements OnInit {

  @Input() professional:Professional;


  constructor(public activeModal: NgbActiveModal , 
    public workerService:ProfessionalService) { }

  ngOnInit() {

  }
  Edit(){
    console.log('edit proffessional',this.professional);
    return this.workerService.editProfessional(this.professional).
    subscribe(res=>
      {
        this.activeModal.close();
      },err=>{console.log('error',err)});
    
   }
}
