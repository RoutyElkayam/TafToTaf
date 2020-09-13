import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Child } from '../models/child';
import { stringify } from 'querystring';
import { toString } from '@ng-bootstrap/ng-bootstrap/util/util';

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
  getKinderGNameOfChild(childID:string){
    const url = `${this.url}`;
    let params = new HttpParams().append('ChildID',childID);
    return this.http.get<string>(url,{params});
  }
}
