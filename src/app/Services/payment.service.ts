import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Payment } from '../Models/payment.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  constructor(private http:HttpClient) { }
  PaymentUrl='https://localhost:7204/api/payment'
  getPayments():Observable<Payment[]>{
    return this.http.get<Payment[]>(this.PaymentUrl);
  }
  getPayment(id:number){
    return this.http.get(`${this.PaymentUrl}/${id}`);
  }
}
