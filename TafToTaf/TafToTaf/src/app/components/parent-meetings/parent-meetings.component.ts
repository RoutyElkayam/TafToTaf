import { Component, OnInit } from '@angular/core';
import { Calander } from 'src/app/shared/models/calander';
import { User } from 'src/app/shared/models/user';
import { AccountService } from 'src/app/shared/services/account.service';
import { CalanderService } from 'src/app/shared/services/calander.service';


@Component({
  selector: 'app-parent-meetings',
  templateUrl: './parent-meetings.component.html',
  styleUrls: ['./parent-meetings.component.scss']
})
export class ParentMeetingsComponent implements OnInit {

  parentMeeting:Calander[];
  user:User;

  nowDate=new Date();
  constructor(private calendarService:CalanderService
              ,private account:AccountService) { }

  ngOnInit() {
    this.user=this.account.currentUser;
    console.log(this.user);
    if(this.user.kindUser==3)
      this.getPMeetingsOfChild();
    else if(this.user.kindUser==2)
      this.getPMeetingsOfWorker();
    else 
      this.getPMeetingsOfAdmin();
  }

  getPMeetingsOfChild(){
    this.calendarService.getChildParentMeeting(this.account.userChild.id).subscribe(res=>
      {this.parentMeeting=res,console.log(this.parentMeeting)});
  }
  getPMeetingsOfWorker(){
    this.calendarService.getWorkerParentsMeeting(this.account.userProffesional.id).subscribe(res=>
      {this.parentMeeting=res,console.log(this.parentMeeting)});
  }
  getPMeetingsOfAdmin(){
    this.calendarService.getAdminParentMeetings().subscribe(res=>
      {this.parentMeeting=res,console.log(this.parentMeeting)});
  }
  getStatusClass(meet:Calander):string{
    if(new Date(meet.start) > new Date(this.nowDate))
      return "finished";
    return "notYet";
  }

  getPlace(meeting:Calander):string{
      
    return "אולם קומה 4";
}
}
