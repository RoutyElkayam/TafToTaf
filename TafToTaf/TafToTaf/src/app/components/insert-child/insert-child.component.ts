import { Component, OnInit ,Input} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';
import { Child } from 'src/app/shared/models/child';
import {ChildService} from 'src/app/shared/services/child.service';


@Component({
  selector: 'app-insert-child',
  templateUrl: './insert-child.component.html',
  styleUrls: ['./insert-child.component.scss']
})
export class InsertChildComponent implements OnInit {

  @Input() kinderGardens:KinderGarden[];
  

  
    firstName:string;
    tz:string;
    lastName:string;
    bornDate:Date;
    numHoursConfirm:number;
    parentID:number;
    kinderGardenName:string;


  constructor(public activeModal: NgbActiveModal , 
    public childService:ChildService) {}

  ngOnInit() {
  }

  sumbit(){

   let child = {
   'firstName':this.firstName,
   'lastName': this.lastName,
   'tz':this.tz,
   'bornDate':this.bornDate,
   'numHoursConfirm':this.numHoursConfirm,
   'parentID':this.parentID
   }
    return this.childService.postChild(child,this.kinderGardenName).subscribe(res=>{},err=>{console.log('error',err)});
  
  }

}
