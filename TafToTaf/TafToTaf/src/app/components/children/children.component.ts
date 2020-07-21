import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InsertChildComponent} from '../insert-child/insert-child.component';
@Component({
  selector: 'app-children',
  templateUrl: './children.component.html',
  styleUrls: ['./children.component.scss']
})
export class ChildrenComponent implements OnInit {

  constructor(private modalService: NgbModal) { 
    
  }
  ngOnInit() {
  }
    

  open() {
    const modalRef = this.modalService.open(InsertChildComponent);
    modalRef.componentInstance.name = 'World';
  }
}
