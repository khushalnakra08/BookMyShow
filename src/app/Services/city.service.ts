import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import { City } from '../Models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http:HttpClient) { }
  CityUrl='https://localhost:7204/api/city'
  getCities():Observable<City[]>{
    return this.http.get<City[]>(this.CityUrl);
  }
  getCity(id:number){
    return this.http.get(`${this.CityUrl}/${id}`);
  }
  addCity(cityData:any){
    return this.http.post(this.CityUrl,cityData);
  }
  editCity(id:number,cityData:any){
    return this.http.put(`${this.CityUrl}/${id}`, cityData);
  }
  deleteCity(id:number){
    return this.http.delete(`${this.CityUrl}/${id}`);
  }
}
