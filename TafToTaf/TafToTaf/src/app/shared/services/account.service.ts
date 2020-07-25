import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  url=environment.base_url+"Users";
  key='currentUser';
  user:Observable<User>=null;
  constructor(private http:HttpClient) { }

  login(username:string, password:string) 
  {
    debugger;
    return  this.user=this.http.post<User>(this.url+"/login",{password:password,userName:username}); 
  }
  currentUser()
  {
    return JSON.parse(localStorage.getItem(this.key));
  }
}