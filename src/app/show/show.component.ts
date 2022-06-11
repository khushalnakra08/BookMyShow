import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CinemaHall } from '../Models/cinema-hall.model';
import { Movie } from '../Models/movie.model';
import { Show } from '../Models/show.model';
import { CinemaHallService } from '../Services/cinema-hall.service';
import { MovieService } from '../Services/movie.service';
import { ShowService } from '../Services/show.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['../app.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private route: ActivatedRoute, private showService:ShowService,private cinemaHallService:CinemaHallService,private movieService:MovieService ) { }
  shows:Show[]=[];
  cinemaHall!:CinemaHall;
  movies:Movie[]=[];
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const currentCinemaHall = parseInt(params.get('id')!);
      if (currentCinemaHall) {
        this.showService.getShowByCinemaHall(currentCinemaHall).subscribe(s=>this.shows=s);
        this.cinemaHallService.getCinemaHall(currentCinemaHall).subscribe((c:any)=>this.cinemaHall=c);
      } 
    });
  }
}
