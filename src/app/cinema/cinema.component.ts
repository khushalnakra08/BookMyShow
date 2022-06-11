import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Cinema } from '../Models/cinema.model';
import { City } from '../Models/city.model';
import { CinemaService } from '../Services/cinema.service';
import { CityService } from '../Services/city.service';

@Component({
  selector: 'app-cinema',
  templateUrl: './cinema.component.html',
  styleUrls: ['../app.component.css']
})
export class CinemaComponent implements OnInit {
  cinemas:Cinema[]=[];
  city!:City;
  constructor(private route: ActivatedRoute, private cinemaService:CinemaService,private cityService:CityService ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const currentCity = parseInt(params.get('id')!);
      if (currentCity) {
        this.cinemaService.getCinemaByCity(currentCity).subscribe(c=>this.cinemas=c)
        this.cityService.getCity(currentCity).subscribe((c:any)=>this.city=c)
      } 
    });
  }
}
