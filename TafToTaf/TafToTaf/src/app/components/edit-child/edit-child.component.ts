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

  constructor(public activeModal: NgbActiveModal , 
    public childService:ChildService) { }

  ngOnInit() {
     console.log(this.child);
  }
  Edit(){
    console.log(this.child);
    return this.childService.editChild(this.child).
    subscribe(res=>
      {
        this.activeModal.close();
      },err=>{console.log('error',err)});
    
   }
}
