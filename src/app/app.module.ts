import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
 
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { MoviesComponent } from './movies/movies.component';
import { MovieService } from './Services/movie.service';
 
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { CityComponent } from './city/city.component';
import { CinemaComponent } from './cinema/cinema.component';
import { CinemaHallComponent } from './cinema-hall/cinema-hall.component';
import { ShowComponent } from './show/show.component';
import { BookingComponent } from './booking/booking.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BookingService } from './Services/booking.service';
import { CinemaHallService } from './Services/cinema-hall.service';
import { CinemaService } from './Services/cinema.service';
import { CityService } from './Services/city.service';
import { ShowService } from './Services/show.service';
import { BookingListComponent } from './booking-list/booking-list.component';
import { DetailsComponent } from './details/details.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { LogInComponent } from './log-in/log-in.component';
import { ProfileComponent } from './profile/profile.component';
import { UserService } from './Services/user.service';
import { AuthInterceptor } from './auth.interceptor';
import { JwtModule } from "@auth0/angular-jwt";

export function tokenGetter() { 
  return localStorage.getItem("token"); 
}
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MoviesComponent,
    MovieDetailComponent,
    CityComponent,
    routingComponents,
    CinemaComponent,
    CinemaHallComponent,
    ShowComponent,
    BookingComponent,
    BookingListComponent,
    DetailsComponent,
    SignInComponent,
    LogInComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CarouselModule.forRoot(),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7204"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [MovieService,BookingService,CinemaHallService,CinemaService,CityService,ShowService,UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }