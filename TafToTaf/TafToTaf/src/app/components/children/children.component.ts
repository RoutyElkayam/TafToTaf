import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InsertChildComponent} from '../insert-child/insert-child.component';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import { KinderGarden } from '../../shared/models/kinderGarden';
import { ModalDeleteComponent } from '../modal-delete/modal-delete.component';

@Component({
  selector: 'app-children',
  templateUrl: './children.component.html',
  styleUrls: ['./children.component.scss']
})
export class ChildrenComponent implements OnInit {

  kinderGardens:KinderGarden[];
  constructor(private modalService: NgbModal, 
   public kinderGardenService: KindergardenService ) { 
    
  }
  ngOnInit() {
    this.getKinderGardens();
  }

  getKinderGardens(): void{
   this.kinderGardenService.getKinderGardens()
    .subscribe(kinderGardens => {this.kinderGardens=kinderGardens,console.log(this.kinderGardens)});
  }

  open() {
    const modalRef = this.modalService.open(InsertChildComponent);
    modalRef.componentInstance.kinderGardens = this.kinderGardens;
  }
  delete(){
    const modalRef = this.modalService.open(ModalDeleteComponent);
  }
}