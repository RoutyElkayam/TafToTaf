import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InsertChildComponent } from '../insert-child/insert-child.component';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import { KinderGarden } from '../../shared/models/kinderGarden';
import { ModalDeleteComponent } from '../modal-delete/modal-delete.component';
import { Child } from 'src/app/shared/models/child';
import { ChildService } from 'src/app/shared/services/child.service';
import { ChildKinderGardenService } from 'src/app/shared/services/child-kinder-garden.service';

@Component({
  selector: 'app-children',
  templateUrl: './children.component.html',
  styleUrls: ['./children.component.scss']
})
export class ChildrenComponent implements OnInit {

  kinderGardens: KinderGarden[];
  children: Child[];
  selectkng: string = null;
  selectchld: Child;

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

  open() {
    const modalRef = this.modalService.open(InsertChildComponent);
    modalRef.componentInstance.kinderGardens = this.kinderGardens;
  }
  delete(child: Child): void {
    console.log(child.id);

    const modalRef = this.modalService.open(ModalDeleteComponent);
    modalRef.componentInstance.child = child;
    modalRef.result.then((result) => {
     
      this.getChildren();
    }).catch((res) => {
      this.getChildren();
    });


  }
  changeGan() {
    if (this.selectkng != null)
      this.getChildInKinderGarden();

  }
}