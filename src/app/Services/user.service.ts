import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }
  UserUrl='https://localhost:7204/api/user'

  registerUser(userData:any):Observable<any>{
    return this.http.post(this.UserUrl+'/register',userData);
  }
  loginUser(userData:any):Observable<any>{
    return this.http.post(this.UserUrl+'/login',userData);
  }
  getProfile(){
    return this.http.get(this.UserUrl+'/profile');
  }
}
