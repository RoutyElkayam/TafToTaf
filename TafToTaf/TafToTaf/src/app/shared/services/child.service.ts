import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Child } from '../models/child';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class ChildService {
  url=environment.base_url+"Child";

  constructor(private http:HttpClient,private accontService:AccountService) { }

  //Get Single Child
  getChild(id: number): Observable<Child> {
    const url = `${this.url}/${id}`;
    return this.http.get<Child>(url);
  }

  getChildren() :Observable<Child[]>{
    return  this.http.get<Child[]>(this.url);
  }

  editChild(child:Child){
  const url=`${this.url}/${child.id}`;
    return this.http.put(url,child);
  }

  deleteChild(id:number){
    const url=`${this.url}/${id}`;
   return this.http.delete(url);
  }

  postChild(child, kinderGardenName:string){
    const url = `${this.url}/${kinderGardenName}`;
   return this.http.post(url,child)

  }

  getChildWorker(): Observable<Child[]>{
    console.log(this.accontService.userProffesional);
    let workerID=this.accontService.userProffesional.id;
    const url=`${this.url}/${"WorkerChildren"}/${workerID}`;
    return this.http.get<Child[]>(url);
  }
  getChildOfUser()
  {
    if(this.accontService.currentUser)
    {
      console.log(this.accontService.currentUser);
      let parentID=this.accontService.currentUser.id;
      const url=`${this.url}/${"ParentChild"}/${parentID}`;
      return this.http.get<Child>(url);
    } 
  }
}
