import { Component, OnInit ,Input} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';
import { Child } from 'src/app/shared/models/child';
import {ChildService} from 'src/app/shared/services/child.service';
import { ChildPost } from 'src/app/shared/models/childPost';
import { HttpErrorResponse } from '@angular/common/http';


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
    parentName:string;
    parentEmail:string;
    kinderGardenName:string;
    errorMessage:string=null;
    isLoading:boolean=false;

  constructor(public activeModal: NgbActiveModal , 
    public childService:ChildService) {}

  ngOnInit() {
  }

  sumbit(){
   this.isLoading=true;
   let child:ChildPost = {
   'firstName':this.firstName,
   'lastName': this.lastName,
   'tz':this.tz,
   'bornDate':this.bornDate,
   'numHoursConfirm':this.numHoursConfirm,
   'parentName':this.parentName,
   'parentEmail':this.parentEmail
   }
    return this.childService.postChild(child,this.kinderGardenName).
    subscribe(res=>
      {
        this.isLoading=false;
        this.activeModal.close();
      },(err:HttpErrorResponse)=>{this.errorMessage=err.message, this.activeModal.close();});
    
  }

}
