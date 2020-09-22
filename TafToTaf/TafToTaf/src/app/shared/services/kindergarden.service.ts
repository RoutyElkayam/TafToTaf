import { Injectable } from '@angular/core';
import { KinderGarden } from '../models/kinderGarden';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class KindergardenService {

  url=environment.base_url+"KinderGarden";

  constructor(public http:HttpClient) { }
  
  getKinderGardens(): Observable<KinderGarden[]>{  
    return this.http.get<KinderGarden[]>(this.url);
    }
    
}

