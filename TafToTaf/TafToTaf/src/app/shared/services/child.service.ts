import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Child } from '../models/child';
@Injectable({
  providedIn: 'root'
})
export class ChildService {
  url=environment.base_url+"Child";
  constructor(private http:HttpClient) { }
  //Get Single Child
  getChild(id: number): Observable<Child> {
    const url = `${this.url}/${id}`;
    return this.http.get<Child>(url);
  }
  
}
