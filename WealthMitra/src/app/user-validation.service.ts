import { HttpClient } from '@angular/common/http';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';



@Injectable({

  providedIn: 'root'

})

export class UserValidationService {

  constructor(private http:HttpClient) { }

  validate(username:string,password:string):Observable<any>{

    let  credentials:any={

                            "username":username,

                            "password":password

                        };

    // return this.http.post("https://localhost:5001/Users/authenticate",credentials);

    return this.http.post("http://localhost:4000/Users/authenticate",credentials);

  }

}