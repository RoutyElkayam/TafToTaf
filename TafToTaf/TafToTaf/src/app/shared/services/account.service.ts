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
  user:Observable<User>=null;
  private key = 'token';
  public currentUser:User=null;

  constructor(private http:HttpClient) { }

  login(username:string, password:string) 
  {
    return  this.http.post(this.url+"/login",{password:password,userName:username}); 
  }
  getUser()
  {
    return this.http.get<User>(this.url);
    
  }
  token()
  {
    return localStorage.getItem(this.key);
  }
  // decodeToken(token: string): string
  // {
  //   return token.slice(231,235);
  // }
}