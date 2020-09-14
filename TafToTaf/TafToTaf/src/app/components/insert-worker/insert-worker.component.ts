import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfessionalService } from 'src/app/shared/services/professional.service';
import { Professional } from 'src/app/shared/models/professional';
import { ProfessionalPost } from 'src/app/shared/models/professionalPost';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-insert-worker',
  templateUrl: './insert-worker.component.html',
  styleUrls: ['./insert-worker.component.scss']
})
export class InsertWorkerComponent implements OnInit {

   private worker:ProfessionalPost;
   name:string;
   proffesionalEmail:string;
   professionKind:number;
   numHourWork:number;
   numDaysWork: number;
   sunday: boolean;
   monday: boolean;
   thuesday: boolean;
   wednesday: boolean;
   tursday: boolean;
   errorMessage:string=null;
   isLoading:boolean=false;
constructor(public activeModal: NgbActiveModal , 
  public professionalService:ProfessionalService) {}

  ngOnInit() {
  }

  sumbit()
  {
    this.isLoading=true;
    console.log(this.name);
    this.worker=
    {
        "name":this.name,
        "numDaysWork":this.numDaysWork,
        "numHourWork":this.numHourWork,
        "professionKind":this.professionKind,
        "proffesionalEmail":this.proffesionalEmail,
        "sunday":this.sunday,
        "monday":this.monday,
        "thuesday":this.thuesday,
        "wednesday":this.wednesday,
        "tursday":this.tursday
    };
    console.log(this.worker);
    return this.professionalService.postProfessional(this.worker).
    subscribe(res=>
      {
        this.isLoading=false;
        this.activeModal.close();
      },(err:HttpErrorResponse)=>{this.errorMessage=err.message});
    
  }
}
