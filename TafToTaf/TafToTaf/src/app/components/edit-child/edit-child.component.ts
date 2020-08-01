import { Component, OnInit,Input } from '@angular/core';
import { Child } from 'src/app/shared/models/child';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ChildService } from 'src/app/shared/services/child.service';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';

@Component({
  selector: 'app-edit-child',
  templateUrl: './edit-child.component.html',
  styleUrls: ['./edit-child.component.scss']
})
export class EditChildComponent implements OnInit {

  @Input() child:Child;
  @Input() kinderGardenOfChild:string;
  @Input() kinderGardens:KinderGarden[];

  firstName:string;
  tz:string;
  lastName:string;
  bornDate:Date;
  numHoursConfirm:number;
  parentID:number;
  kinderGardenName:string;

  constructor(public activeModal: NgbActiveModal , 
    public childService:ChildService) { }

  ngOnInit() {
  }
  Edit(){
    console.log('submit');
    this.child.firstName=this.firstName;
    this.child.lastName=this.lastName;
    this.child.tz=this.tz;
    this.child.bornDate=this.bornDate;
    this.child.numHoursConfirm=this.numHoursConfirm;
    this.child.parentID=this.parentID;
    return this.childService.editChild(this.child).subscribe(res=>{},err=>{console.log('error',err)});
    
   }
}
