import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['../app.component.css']
})
export class LogInComponent implements OnInit {
  logInForm!:FormGroup;
  loginFail:boolean=false;
  constructor(private userService:UserService,private router: Router) {
    this.logInUser();
   }
   userdata: any;
  ngOnInit(): void {
  }
  logInUser(){
    this.logInForm=new FormGroup({
      email:new FormControl('',[Validators.required]),
      password:new FormControl('',[Validators.required])
    });
  }
  logIn(){
    console.warn(this.logInForm.value);
    this.userService.loginUser(this.logInForm.value).subscribe(
      result => {
        localStorage.setItem('token', result.token);
        localStorage.setItem('refreshToken', result.refreshToken);
        this.router.navigate(['profile']);
    },
    err => {
      if (err.status == 401)
        this.loginFail=true;
    }
    );
  }
}
