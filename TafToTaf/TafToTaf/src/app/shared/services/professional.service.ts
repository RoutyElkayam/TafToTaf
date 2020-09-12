import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Professional } from '../models/professional';
import { ProfessionalPost } from '../models/professionalPost';

@Injectable({
  providedIn: 'root'
})
export class ProfessionalService {
  private url=environment.base_url+"Professional";
  constructor(private http:HttpClient) { }

   //Get Single Child
   getProfessional(id: number): Observable<Professional> {
    const url = `${this.url}/${id}`;
    return this.http.get<Professional>(url);
  }
  getProfessionals() :Observable<Professional[]>{
    return  this.http.get<Professional[]>(this.url);
  }
  editProfessional(professional:Professional){
  const url=`${this.url}/${professional.id}`;
    return this.http.put(url,professional);
  }
  deleteProfessional(id:number){
    const url=`${this.url}/${id}`;
   return this.http.delete(url);
  }
  postProfessional(proffesional:ProfessionalPost){   
   return this.http.post(this.url,proffesional);
  }
  
}
