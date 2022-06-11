import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { BookingComponent } from './booking/booking.component';
import { CinemaHallComponent } from './cinema-hall/cinema-hall.component';
import { CinemaComponent } from './cinema/cinema.component';
import { CityComponent } from './city/city.component';
import { LogInComponent } from './log-in/log-in.component';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { MoviesComponent } from './movies/movies.component';
import { ProfileComponent } from './profile/profile.component';
import { ShowComponent } from './show/show.component';
import { SignInComponent } from './sign-in/sign-in.component';
const routes: Routes = [
  {path:'movies',component:MoviesComponent,canActivate:[AuthGuard]},
  {path: 'movieDetail/:id', component: MovieDetailComponent ,canActivate:[AuthGuard]},
  {path: 'movieDetail/:movieid/:showid', component: MovieDetailComponent ,canActivate:[AuthGuard]},
  {path:'cities',component:CityComponent,canActivate:[AuthGuard]},
  {path: 'cinema/:id', component: CinemaComponent ,canActivate:[AuthGuard]},
  {path: 'cinemaHall/:id', component: CinemaHallComponent ,canActivate:[AuthGuard]},
  {path: 'show/:id', component: ShowComponent ,canActivate:[AuthGuard]},
  {path: 'booking/:id', component: BookingComponent ,canActivate:[AuthGuard]},
  {path: 'booking/:movieid/:showid', component: BookingComponent ,canActivate:[AuthGuard]},
  {path: 'signIn', component: SignInComponent },
  {path: 'logIn', component: LogInComponent },
  {path: 'profile',component:ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [MoviesComponent,MovieDetailComponent,CityComponent,CinemaComponent,CinemaHallComponent,ShowComponent,BookingComponent,SignInComponent,LogInComponent,ProfileComponent]
