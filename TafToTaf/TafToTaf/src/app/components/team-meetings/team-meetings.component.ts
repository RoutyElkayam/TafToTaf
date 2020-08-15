import { Component, OnInit } from '@angular/core';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';
import { NgbModalRef, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';

@Component({
  selector: 'app-team-meetings',
  templateUrl: './team-meetings.component.html',
  styleUrls: ['./team-meetings.component.scss']
})
export class TeamMeetingsComponent implements OnInit {
  
  kinderGardens: KinderGarden[];
  selectkng: string = null;
  constructor(private ModalService:NgbModal,
    public kinderGardenService: KindergardenService,
    ) {
    
   }

  ngOnInit() {
    this.getKinderGardens();
  }
  open(){
    
  }
  getKinderGardens(): void {
    this.kinderGardenService.getKinderGardens()
      .subscribe(kinderGardens => { this.kinderGardens = kinderGardens, console.log(this.kinderGardens) });
  }
  
  OnchangeGan() {
    if (this.selectkng != null)
      this.getKinderGardens();

  }

}
