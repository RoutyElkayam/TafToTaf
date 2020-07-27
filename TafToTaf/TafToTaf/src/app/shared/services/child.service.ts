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
  getChildren() :Observable<Child[]>{
     return this.http.get<Child[]>(this.url);
  }
  editChild(child:Child){
    const url=`${this.url}/${child.Id}`;
    this.http.put(url,child);
  }
  deleteChild(id:number){
    const url=`${this.url}/${id}`;
    this.http.delete(url);
  }
  postChild(child:Child, kinderGardenName:string){
    const url = `${this.url}/${kinderGardenName}`;
    this.http.post(url,child)

  }
}
