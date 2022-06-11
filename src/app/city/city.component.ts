import { Component, OnInit } from '@angular/core';
import { City } from '../Models/city.model';
import { CityService } from '../Services/city.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['../app.component.css']
})
export class CityComponent implements OnInit {
  cities:City[]=[]
  constructor(private cityService:CityService) { }

  ngOnInit(): void {
    this.cityService.getCities().subscribe(c=>this.cities=c)
  }

}
