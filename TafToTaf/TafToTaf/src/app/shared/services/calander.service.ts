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
  getKGardenCalender(kinderGardenId:number)
  {
    const url=`${this.url}/${"CalendarKinderGarden"}/${kinderGardenId}`;
    return this.http.get(this.url);
  }
}
