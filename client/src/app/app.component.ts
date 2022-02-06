import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Dating App Title!';
  ulr:string = 'https://localhost:7046/api/users/';
  users:any;

  constructor(private http: HttpClient){}

  ngOnInit() {
    this.getUsers();
    
  }
  getUsers(){
    this.http.get(this.ulr).subscribe(response =>{
      this.users=response;      
    },error=>{
      console.log(error);      
    })
  }
}
