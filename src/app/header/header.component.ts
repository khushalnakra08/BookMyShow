import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../app.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  displayCity:boolean=false;
  displayList:boolean=false;
  displaySignIn:boolean=false;
  city(){
    this.displayCity?(this.displayCity=false):(this.displayCity=true)
  }
  list(){
    this.displayList?(this.displayList=false):(this.displayList=true)
  }
  signIn(){
    this.displaySignIn?(this.displaySignIn=false):(this.displaySignIn=true)
  }

}
