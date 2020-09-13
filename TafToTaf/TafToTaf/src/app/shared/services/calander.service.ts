import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CalanderService {
  private url=environment.base_url+"Calender";
  constructor(private http:HttpClient) { }
  getAdminTeamMeetings()
  {
    const url=`${this.url}/${"AdminTeamMeetings"}`;
    return this.http.get(url);
  }
  getAdminParentMeetings()
  {
    const url=`${this.url}/${"AdminParentMeetings"}`;
    return this.http.get(url);
  }
  getKGardenCalender(kinderGardenId:number)
  {
    const url=`${this.url}/${"CalendarKinderGarden"}/${kinderGardenId}`;
    return this.http.get(url);
  }
  getChildCalender(childID:number)
  {
    const url=`${this.url}/${"CalenderChild"}/${childID}`;
    return this.http.get(url);
  }
  getWorkerCalender(workerID:number)
  {
    const url=`${this.url}/${"CalenderWorker"}/${workerID}`;
    return this.http.get(url);
  }
  
}
