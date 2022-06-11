import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Movie } from '../Models/movie.model';
import { Show } from '../Models/show.model';
import { MovieService } from '../Services/movie.service';
import { ShowService } from '../Services/show.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['../app.component.css']
})
export class MovieDetailComponent implements OnInit {
  selectedMovie!: Movie;
  selectedShow!: Show;
  constructor( private route: ActivatedRoute, private movieService:MovieService,private showService:ShowService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const currentMovie = parseInt(params.get('movieid')!);
      const currentShow = parseInt(params.get('showid')!);
      if (currentMovie) {
        this.getMovie(currentMovie).subscribe((data:any) => {
        this.selectedMovie = data;
        });
      } 
      if (currentShow) {
        this.showService.getShow(currentShow).subscribe((data:any) => {
        this.selectedShow = data;
        });
      } 
    });
  }
  getMovie(id:number){
    return this.movieService.getMovie(id);
  }

}
