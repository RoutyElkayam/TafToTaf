import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Calander } from '../models/calander';
import { CalendarEvent } from 'angular-calendar';

@Injectable({
  providedIn: 'root'
})
export class CalanderService {
  private url=environment.base_url+"Calender";
  constructor(private http:HttpClient) { }
  getAdminTeamMeetings() :Observable<Calander[]> 
  {
    const url=`${this.url}/${"AdminTeamMeetings"}`;
    return this.http.get<Calander[]>(url);
  }
  getAdminParentMeetings() :Observable<Calander[]> 
  {
    const url=`${this.url}/${"AdminParentMeetings"}`;
    return this.http.get<Calander[]>(url);
  }
  getKGardenCalender(kinderGardenId:number):Observable<CalendarEvent[]> 
  {
    const url=`${this.url}/${"CalendarKinderGarden"}/${kinderGardenId}`;
    return this.http.get<CalendarEvent[]>(url);
  }
  getChildCalender(childID:number):Observable<Calander[]> 
  {
    const url=`${this.url}/${"CalenderChild"}/${childID}`;
    return this.http.get<Calander[]>(url);
  }
  getWorkerCalender(workerID:number):Observable<Calander[]> 
  {
    const url=`${this.url}/${"CalenderWorker"}/${workerID}`;
    return this.http.get<Calander[]>(url);
  }
  getChildParentMeeting(childID:number):Observable<Calander[]> 
  {
    const url=`${this.url}/${"WorkerParentsMeeting"}/${childID}`;
    return this.http.get<Calander[]>(url);
  }
  
  getWorkerParentsMeeting(childID:number):Observable<Calander[]> 
  {
    const url=`${this.url}/${"WorkerParentsMeeting"}/${childID}`;
    return this.http.get<Calander[]>(url);
  }
  getWorkerTeamMeeting(workerID:number):Observable<Calander[]> 
  {
    const url=`${this.url}/${"WorkerParentsMeeting"}/${workerID}`;
    return this.http.get<Calander[]>(url);
  }
  
}
