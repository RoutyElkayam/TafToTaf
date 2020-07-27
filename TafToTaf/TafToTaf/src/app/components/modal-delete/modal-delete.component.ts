import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ChildKinderGardenService } from 'src/app/shared/services/child-kinder-garden.service';
import { Child } from 'src/app/shared/models/child';
import { ChildService } from 'src/app/shared/services/child.service';

@Component({
  selector: 'app-modal-delete',
  templateUrl: './modal-delete.component.html',
  styleUrls: ['./modal-delete.component.scss']
})
export class ModalDeleteComponent implements OnInit {


  @Input() child:Child;
 
  constructor(private activeModal:NgbActiveModal) { }
  public childService: ChildService
  

  ngOnInit() {
  }

  delete(): void{
   
    this.childService.deleteChild(this.child.Id);
    console.log("delete!!!!!!!!!!!");

  }
}