import { Component, OnInit } from '@angular/core';
import { Booking } from '../Models/booking.model';
import { CinemaHall } from '../Models/cinema-hall.model';
import { Cinema } from '../Models/cinema.model';
import { City } from '../Models/city.model';
import { Movie } from '../Models/movie.model';
import { Payment } from '../Models/payment.model';
import { Show } from '../Models/show.model';
import { BookingService } from '../Services/booking.service';
import { CinemaHallService } from '../Services/cinema-hall.service';
import { CinemaService } from '../Services/cinema.service';
import { CityService } from '../Services/city.service';
import { MovieService } from '../Services/movie.service';
import { PaymentService } from '../Services/payment.service';
import { ShowService } from '../Services/show.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['../app.component.css']
})
export class BookingListComponent implements OnInit {

  constructor(private bookingService:BookingService, private showService:ShowService, private movieService:MovieService, private cinemaHallService:CinemaHallService,private cinemaService:CinemaService, private cityService:CityService, private paymentService:PaymentService) { }
  bookings:Booking[]=[];
  bookingData!:Booking;
  paymentData!:Payment;
  showData!:Show;
  movieData!:Movie;
  cinemaHallData!:CinemaHall;
  cinemaData!:Cinema;
  cityData!:City;
  movieId!:number;
  showId!:number;
  cinemaHallId!:number;
  cinemaId!:number;
  cityId!:number;
  paymentId!:number;
  ngOnInit(): void {
    this.getBookings();
    this.bookingService.RefreshRequired.subscribe(r=>{
      this.getBookings();
    })
  }
  displayDetail:boolean=false;
  details(id:number){
  this.displayDetail=true;
    if(id!=null)
    {
      this.bookingService.getBooking(id).subscribe((data:any) => {
        this.bookingData = data;
        this.showId=data.showId;
        this.paymentId=data.showId;
        });
        if(this.paymentId!=null){
          this.paymentService.getPayment(this.paymentId).subscribe((data:any) => {
            this.paymentData = data;
            })
          }
        if(this.showId!=null){
          this.showService.getShow(this.showId).subscribe((data:any) => {
            this.showData = data;
            this.movieId=data.movieId;
            this.cinemaHallId=data.cinemaHallId;
            }
          );
            if(this.movieId!=null){
              this.movieService.getMovie(this.movieId).subscribe((data:any) => {
                this.movieData = data;
                });
            }
            if(this.cinemaHallId!=null){
              this.cinemaHallService.getCinemaHall(this.cinemaHallId).subscribe((data:any) => {
                this.cinemaHallData = data;
                this.cinemaId=data.cinemaId;
                });
                if(this.cinemaId!=null){
                  this.cinemaService.getCinema(this.cinemaId).subscribe((data:any) => {
                    this.cinemaData = data;
                    this.cityId=data.cityId;
                    });
                    if(this.cityId!=null)
                    {
                     this.cityService.getCity(this.cityId).subscribe((data:any) => {
                      this.cityData = data;
                      });
                    }
                }
            }
        }
    }
  }
  getBookings(){
    this.bookingService.getBookings().subscribe(m=>this.bookings=m)
  }
}
