import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CinemaHall } from '../Models/cinema-hall.model';

@Injectable({
  providedIn: 'root'
})
export class CinemaHallService {
  constructor(private http:HttpClient) { }
  CinemaHallUrl='https://localhost:7204/api/cinemaHall'
  getCinemaHalls():Observable<CinemaHall[]>{
    return this.http.get<CinemaHall[]>(this.CinemaHallUrl);
  }
  getCinemaHall(id:number){
    return this.http.get(`${this.CinemaHallUrl}/${id}`);
  }
  getCinemaHallByCinema(id:number):Observable<CinemaHall[]>{
    return this.http.get<CinemaHall[]>(`${this.CinemaHallUrl+'/cinema'}/${id}`);
  }
}
