import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { Cinema } from '../Models/cinema.model';

@Injectable({
  providedIn: 'root'
})
export class CinemaService {

  constructor(private http:HttpClient) { }
  CinemaUrl='https://localhost:7204/api/cinema'
  getCinemas():Observable<Cinema[]>{
    return this.http.get<Cinema[]>(this.CinemaUrl);
  }
  getCinema(id:number){
    return this.http.get(`${this.CinemaUrl}/${id}`);
  }
  getCinemaByCity(id:number):Observable<Cinema[]>{
    return this.http.get<Cinema[]>(`${this.CinemaUrl+'/city'}/${id}`);
  }
  addCinema(cinemaData:any){
    return this.http.post(this.CinemaUrl,cinemaData);
  }
  editCinema(id:number,cinemaData:any){
    return this.http.put(`${this.CinemaUrl}/${id}`, cinemaData);
  }
  deleteCinema(id:number){
    return this.http.delete(`${this.CinemaUrl}/${id}`);
  }
}
