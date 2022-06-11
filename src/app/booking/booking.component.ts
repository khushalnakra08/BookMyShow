import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Movie } from '../Models/movie.model';
import { Show } from '../Models/show.model';
import { BookingService } from '../Services/booking.service';
import { MovieService } from '../Services/movie.service';
import { ShowService } from '../Services/show.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['../app.component.css']
})
export class BookingComponent implements OnInit {
  bookingForm!:FormGroup;
  ticket:boolean=false;
  selectedMovie!: Movie;
  selectedShow!:Show;
  constructor( private route: ActivatedRoute,private bookingService:BookingService,private movieService:MovieService,private showService:ShowService) {     
    this.bookTicket()
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const currentMovie = parseInt(params.get('movieid')!);
      const currentShow= parseInt(params.get('showid')!);
      if (currentMovie) {
        this.movieService.getMovie(currentMovie).subscribe((data:any) => {
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
  bookTicket(){
    this.bookingForm=new FormGroup({
      name:new FormControl('',[Validators.required]),
      numberOfSeats:new FormControl('',[Validators.required]),
      phoneNo:new FormControl('',[Validators.required]),
      email:new FormControl('',[Validators.required]),
      time:new FormControl(''),
      showId:new FormControl('')
    });
  }
  book(){
    this.bookingForm.value.time=this.selectedShow.startTime;
    this.bookingForm.value.showId=this.selectedShow.id;
    this.bookingService.addBooking(this.bookingForm.value).subscribe()
    this.ticket=true;
  }
}
