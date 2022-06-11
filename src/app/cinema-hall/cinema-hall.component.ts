import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CinemaHall } from '../Models/cinema-hall.model';
import { Cinema } from '../Models/cinema.model';
import { CinemaHallService } from '../Services/cinema-hall.service';
import { CinemaService } from '../Services/cinema.service';

@Component({
  selector: 'app-cinema-hall',
  templateUrl: './cinema-hall.component.html',
  styleUrls: ['../app.component.css']
})
export class CinemaHallComponent implements OnInit {
  cinemaHalls:CinemaHall[]=[];
  cinema!:Cinema;
  constructor(private route: ActivatedRoute, private cinemaService:CinemaService,private cinemaHallService:CinemaHallService ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const currentCinema = parseInt(params.get('id')!);
      if (currentCinema) {
        this.cinemaHallService.getCinemaHallByCinema(currentCinema).subscribe(c=>this.cinemaHalls=c)
        this.cinemaService.getCinema(currentCinema).subscribe((c:any)=>this.cinema=c)
      } 
    });
  }
}
