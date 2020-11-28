import { Component, OnInit, Input } from '@angular/core';
import { Professional } from 'src/app/shared/models/professional';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfessionalService } from 'src/app/shared/services/professional.service';

@Component({
  selector: 'app-delete-worker',
  templateUrl: './delete-worker.component.html',
  styleUrls: ['./delete-worker.component.scss']
})
export class DeleteWorkerComponent implements OnInit {

  @Input() proffessional:Professional;
 
  constructor(private activeModal:NgbActiveModal,
    public workerService: ProfessionalService) { }

  ngOnInit() {
  }

  delete(): void{
   
    this.workerService.deleteProfessional(this.proffessional.id).subscribe(res=>{
      this.activeModal.close();
    });
    


  }

}
