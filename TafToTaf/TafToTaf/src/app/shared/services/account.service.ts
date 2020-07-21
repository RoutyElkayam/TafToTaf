import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  url=environment.base_url+"users";
  key='currentUser';
  
  constructor(private http:HttpClient) { }

  login(username:string, password:string) 
  {
    let user={'userName':username,'password':password};
    this.http.post<User>(this.url+"/login",user)
    .subscribe((res)=>{
      localStorage.setItem('currentuser',JSON.stringify(user));
    }
    ,(err)=>{console.log('error',err)});
   
    
  }
  currentUser()
  {
    return JSON.parse(localStorage.getItem(this.key));
  }
}