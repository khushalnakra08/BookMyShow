export interface Booking {
    id:number;
    numberOfSeats:number;
    time:Date;
    name:string;
    phoneNo:string;
    email:string;
    status?:number;
    userID?:number;
    showId?:number
    
}
