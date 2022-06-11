import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/user.model';
import { UserService } from '../Services/user.service';
 
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['../app.component.css']
})
export class ProfileComponent implements OnInit {
  user!:any;
  constructor(private router: Router,private userService:UserService) { }
 
  ngOnInit(): void {
    this.userService.getProfile().subscribe(
      result=>{
        this.user=result;
      }
    )
  }
  logOut(){
    localStorage.removeItem('token');
    localStorage.removeItem("refreshToken");
    this.router.navigate(['signIn']);
  }
}
