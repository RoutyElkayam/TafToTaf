import { Component, OnInit } from '@angular/core';
import { Calander } from 'src/app/shared/models/calander';
import { AccountService } from 'src/app/shared/services/account.service';
import { CalanderService } from 'src/app/shared/services/calander.service';

@Component({
  selector: 'app-team-meetings',
  templateUrl: './team-meetings.component.html',
  styleUrls: ['./team-meetings.component.scss']
})
export class TeamMeetingsComponent implements OnInit {
  
  teamMeetings:Calander[];
  user =this.accountService.currentUser;
  nowDate=new Date();
  constructor(public calendarService: CalanderService
    ,private accountService: AccountService) {  
    }

  ngOnInit() {
    if(this.user.kindUser==2)
      this.getWorkerTeamMeeting();
    else this.getAdminTeamMeeting
  }
  
  getWorkerTeamMeeting(){
    this.calendarService.getWorkerTeamMeeting(this.user.id).subscribe(res=>
      this.teamMeetings=res);
  }

  getAdminTeamMeeting(){
    this.calendarService.getAdminTeamMeetings().subscribe(res=>
      this.teamMeetings=res)
  }
  
  getPlace(date:Date):string{
    if(date.getDay()==0||date.getDay()==2||date.getDay()==4)
      return "אולם קומה 4";
    else return "חדר ישיבות קומה 2";
  }
  getStatus(meet:Calander):boolean{
    if(meet.dateStart>this.nowDate)
      return true;
    return false;
  }

}
