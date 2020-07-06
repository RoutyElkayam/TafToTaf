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

  constructor(private http:HttpClient) { }

  login(username:string, password:string) :Observable<User>
  {
    return this.http.post<User>(this.url+"/login",{userName:username,password:password});
  }
}