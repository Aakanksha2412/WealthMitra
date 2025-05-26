import{HttpClient} from '@angular/common/http';
import {Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  
  public registerForm!:FormGroup;
  constructor(private formBuilder : FormBuilder, private http : HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      fname:['',Validators.required],
      mname:['',Validators.required],
      lname:['',Validators.required],
      email:['',Validators.required],
      aemail:['',Validators.required],
      mnumber:['',Validators.required],
      amnumber:['',Validators.required],
      pan:['',Validators.required],
      aadhar:['',Validators.required],
      dob:['',Validators.required],
      age:['',Validators.required],
      gender:['',Validators.required],
      ms:['',Validators.required],
      add1:['',Validators.required],
      add2:['',Validators.required],
      pincode:['',Validators.required],
      uname:['',Validators.required],
      password:['',Validators.required]
    })
  }

signUp(){
  this.http.post<any>("http://localhost:3000/signupUsers",this.registerForm.value)
  .subscribe(res=>{
    alert("Signup Successful");
    this.registerForm.reset();
    this.router.navigate(['login'])
  },err=>{
    alert("something went wrong, please fill all the fields.");
  })
}
}















