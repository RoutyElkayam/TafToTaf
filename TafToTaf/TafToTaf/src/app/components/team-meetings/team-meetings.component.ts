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
  user;
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
    this.calendarService.getWorkerTeamMeeting(this.accountService.userProffesional.id).subscribe(res=>
      {this.teamMeetings=res,console.log(this.teamMeetings)});
  }

  getAdminTeamMeeting(){
    this.calendarService.getAdminTeamMeetings().subscribe(res=>
     {this.teamMeetings=res,console.log(this.teamMeetings)});  
  }
  
  getPlace(meeting:Calander):string{
      
      return "אולם קומה 4";
  }
  getStatusClass(meet:Calander):string{
    if(new Date(meet.start) > new Date(this.nowDate))
      return "finished";
    return "notYet";
  }

}
