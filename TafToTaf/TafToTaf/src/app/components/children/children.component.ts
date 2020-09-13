import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InsertChildComponent } from '../insert-child/insert-child.component';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import { KinderGarden } from '../../shared/models/kinderGarden';
import { ModalDeleteComponent } from '../modal-delete/modal-delete.component';
import { Child } from 'src/app/shared/models/child';
import { ChildService } from 'src/app/shared/services/child.service';
import { ChildKinderGardenService } from 'src/app/shared/services/child-kinder-garden.service';
import { EditChildComponent } from '../edit-child/edit-child.component';

@Component({
  selector: 'children',
  templateUrl: './children.component.html',
  styleUrls: ['./children.component.scss']
})
export class ChildrenComponent implements OnInit {

  kinderGardens: KinderGarden[];
  children: Child[];
  selectkng: string = null;

  constructor(private modalService: NgbModal,
    public kinderGardenService: KindergardenService,
    public childService: ChildService,
    public childKinderGardenService: ChildKinderGardenService
  ) {

  }
  ngOnInit() {
    this.getKinderGardens();
    this.getChildren();
  }

  getKinderGardens(): void {
    this.kinderGardenService.getKinderGardens()
      .subscribe(kinderGardens => { this.kinderGardens = kinderGardens, console.log(this.kinderGardens) });
  }

  getChildren(): void {
    this.childService.getChildren()
      .subscribe(children => { this.children = children });
  }

  getChildInKinderGarden(): void {
    console.log(this.selectkng);
    this.childKinderGardenService.getChildren(this.selectkng)
      .subscribe(res => this.children = res);
  }

  sendChild() {
    const modalRef = this.modalService.open(InsertChildComponent);
    modalRef.componentInstance.kinderGardens = this.kinderGardens;
    modalRef.result.then((result) => {
     
      this.getChildren();
      this.selectkng='';
    }).catch((res) => {
      this.getChildren();
      
    });
  }
  delete(child: Child): void {
    const modalRef = this.modalService.open(ModalDeleteComponent);
    modalRef.componentInstance.child = child;
    modalRef.result.then((result) => {
     
      this.getChildren();
      this.selectkng='';
    }).catch((res) => {
      this.getChildren();
      
    });
  }
  edit(child:Child){
    const modalRef = this.modalService.open(EditChildComponent);
    modalRef.componentInstance.child = child;
    if(this.selectkng!=null)
      modalRef.componentInstance.kinderGardenOfChild=this.selectkng;
    else 
       this.childKinderGardenService
      .getKinderGNameOfChild(child.id.toString()).subscribe(res=>{
        modalRef.componentInstance.kinderGardenOfChild=res,console.log('res',res)}
        );
    modalRef.componentInstance.kinderGardens = this.kinderGardens;
    modalRef.result.then((result) => {
     
      this.getChildren();
      this.selectkng='';
    }).catch((res) => {
      this.getChildren();
      
    });
  }
 
  OnchangeGan() {
    if (this.selectkng != null)
      this.getChildInKinderGarden();

  }
}