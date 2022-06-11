import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, tap } from 'rxjs';
import { Movie } from '../Models/movie.model';
@Injectable({
  providedIn: 'root'
})
export class MovieService {
  constructor(private http:HttpClient) { }
  MovieUrl='https://localhost:7204/api/movie'
  getMovies():Observable<Movie[]>{
    return this.http.get<Movie[]>(this.MovieUrl);
  }
  getMovie(id:number){
    return this.http.get(`${this.MovieUrl}/${id}`);
  }
  addMovie(movieData:any) {
    return this.http.post(this.MovieUrl,movieData).pipe(
      tap(() => {
        this.RefreshRequired.next();
      })
    );
  }
  editMovie(id:number,movieData:any){
    return this.http.put(`${this.MovieUrl}/${id}`, movieData).pipe(
      tap(() => {
        this.RefreshRequired.next();
      })
    );
  }
  deleteMovie(id:number){
    return this.http.delete(`${this.MovieUrl}/${id}`).pipe(
      tap(() => {
        this.RefreshRequired.next();
      })
    );
  }
  private refresh=new Subject<void>();
  get RefreshRequired(){
    return this.refresh;
  }
}
