import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Show } from '../Models/show.model';

@Injectable({
  providedIn: 'root'
})
export class ShowService {

  constructor(private http:HttpClient) { }
  showUrl='https://localhost:7204/api/show'
  getShows():Observable<Show[]>{
    return this.http.get<Show[]>(this.showUrl);
  }
  getShow(id:number){
    return this.http.get(`${this.showUrl}/${id}`);
  }
  getShowByCinemaHall(id:number):Observable<Show[]>{
    return this.http.get<Show[]>(`${this.showUrl+'/cinemaHall'}/${id}`);
  }
}
