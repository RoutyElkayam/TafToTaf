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
  user ;
  nowDate=new Date();
  constructor(public calendarService: CalanderService
    ,private accountService: AccountService) {  
    }

  ngOnInit() {
    this.user=this.accountService.currentUser;
    if(this.user.kindUser==2)
      this.getWorkerTeamMeeting();
    else this.getAdminTeamMeeting();
  }
  
  getWorkerTeamMeeting(){
    this.calendarService.getWorkerTeamMeeting(this.user.id).subscribe(res=>
      {this.teamMeetings=res,console.log(this.teamMeetings)});
  }

  getAdminTeamMeeting(){
    this.calendarService.getAdminTeamMeetings().subscribe(res=>
     {this.teamMeetings=res,console.log(this.teamMeetings)});  
  }
  
  getPlace(meeting:Calander):string{
    if(meeting.kinderGardenId==1)
      return "אולם קומה 4";
    else return "חדר ישיבות קומה 2";
  }
  getStatusClass(meet:Calander):string{
    if(meet.start >this.nowDate)
      return "finished";
    return "notYet";
  }

}
