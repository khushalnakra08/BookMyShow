import { Component, OnInit } from '@angular/core';
import { MovieService } from '../Services/movie.service';
import { Movie } from '../Models/movie.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['../app.component.css']
})
export class MoviesComponent implements OnInit {
  movies:Movie[]=[];
  constructor(private movieService:MovieService,private router: Router) { }

  ngOnInit(): void {
    this.getMovies();
    this.movieService.RefreshRequired.subscribe(o=>{
      this.getMovies();
    })
  }
  getMovies(){
    this.movieService.getMovies().subscribe(m=>this.movies=m)
  }
}
