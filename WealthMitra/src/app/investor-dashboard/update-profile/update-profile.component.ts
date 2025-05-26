import { Component, OnInit } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { FormGroup, FormBuilder,Validator } from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css']
})
export class UpdateProfileComponent implements OnInit {
  public updateForm!:FormGroup;
  constructor(private formBuilder : FormBuilder, private http : HttpClient, private router:Router) { }



  ngOnInit(): void {
  }
  update(){

  }
  // update(id: any, data: any): Observable<any> {
  //   return this.httpClient.put(`${this.apiUrl}/${id}`, data).pipe(
  //   catchError(this.handleError)
  //   );
  //   }
}
