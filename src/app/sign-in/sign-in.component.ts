import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../Services/user.service';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['../app.component.css']
})
export class SignInComponent implements OnInit {
  signInForm!:FormGroup;
  register:boolean=false;
  constructor(private userService:UserService) {
    this.signInUser();
   }


  ngOnInit(): void {
    this.signInForm.reset();
  }
  signInUser(){
    this.signInForm=new FormGroup({
      userName:new FormControl('',[Validators.required]),
      email:new FormControl('',[Validators.required]),
      password:new FormControl('',[Validators.required]),
      phoneNumber:new FormControl('',[Validators.required])
    });
  }

  signIn(){
    console.warn(this.signInForm.value);
    this.userService.registerUser(this.signInForm.value).subscribe();
    this.signInForm.reset();
    this.register=true;
  }
}
