import { Component, Input, OnInit } from '@angular/core';
import { Booking } from '../Models/booking.model';
import { CinemaHall } from '../Models/cinema-hall.model';
import { Cinema } from '../Models/cinema.model';
import { City } from '../Models/city.model';
import { Movie } from '../Models/movie.model';
import { Payment } from '../Models/payment.model';
import { Show } from '../Models/show.model';
import { ShowService } from '../Services/show.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['../app.component.css']
})
export class DetailsComponent implements OnInit {

   @Input() booking!:Booking;
   @Input() show!:Show;
   @Input() movie!:Movie;
   @Input() cinemaHall!:CinemaHall;
   @Input() cinema!:Cinema;
   @Input() payment!:Payment;
   @Input() city!:City;
  constructor(private showService:ShowService) { }

  ngOnInit(): void {
    this.showService.getShow(this.booking.showId!).subscribe((data:any) => {
      this.show = data;
      });
  }
}
