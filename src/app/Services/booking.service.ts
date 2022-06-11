import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, tap } from 'rxjs';
import { Booking } from '../Models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  constructor(private http:HttpClient) { }
  BookingUrl='https://localhost:7204/api/booking'
  getBookings():Observable<Booking[]>{
    return this.http.get<Booking[]>(this.BookingUrl)
  }
  getBooking(id:number){
    return this.http.get(`${this.BookingUrl}/${id}`);
  }
  addBooking(bookingData:Booking):Observable<any>{
    return this.http.post(this.BookingUrl,bookingData).pipe(
      tap(() => {
        this.RefreshRequired.next();
      })
    );
  }
  editBooking(id:number,bookingData:Booking){
    return this.http.put(this.BookingUrl+id, bookingData);
  }
  deleteBooking(id:number){
    return this.http.delete(this.BookingUrl+id);
  }
  private refresh=new Subject<void>();
  get RefreshRequired(){
    return this.refresh;
  }
}
