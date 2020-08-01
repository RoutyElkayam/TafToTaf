import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Child } from '../models/child';

@Injectable({
  providedIn: 'root'
})
export class ChildKinderGardenService {
   url  = environment.base_url+"ChildKinderarden";

  constructor(private http:HttpClient) { }
  
  getChildren(kinderGardenName: string): Observable<Child[]>{
    const url = `${this.url}/${kinderGardenName}`;
    return this.http.get<Child[]>(url);

  }
}
