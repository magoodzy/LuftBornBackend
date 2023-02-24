import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { takeWhile } from 'rxjs';
import { AddUsersRequest } from 'src/app/Core/interfaces/requests/AddUserRequest';
import { GenericResponse } from 'src/app/Core/interfaces/responses/GenericResponse';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  AddUserRequest=new AddUsersRequest();
  GenericResponse=new GenericResponse();
  baseUrl='http://Dummy';
  alive:boolean=true;
  isSpinner:boolean=false;
  constructor(public apiService:HttpClient
    ) { }

  ngOnInit(): void {
  }


  AddUser(form:any){
    this.GenericResponse.Message='';
    this.isSpinner=true;

    if(form.invalid){
      this.GenericResponse.Message='Invalid Data!';
      this.isSpinner=false;

    }

    if(form.valid){
      Object.assign(this.AddUserRequest,form.value);

      this.apiService.post(`${this.baseUrl}/AddUser`,this.AddUserRequest).pipe(takeWhile(() => this.alive)).subscribe(
        (res:any)=>{
          console.log(res);
          this.GenericResponse.Data=null;
          this.GenericResponse.Message=res.message;
          this.GenericResponse.Status=res.status;
          this.isSpinner=false;

        },(err:any)=>{
          console.log(err);
          this.isSpinner=false;
          this.GenericResponse.Message=err.error.message;
        }
      )

    }

    return this.GenericResponse.Message;

  }

}
