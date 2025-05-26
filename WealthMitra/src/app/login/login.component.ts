// import{HttpClient} from '@angular/common/http';
// import {Component, OnInit } from '@angular/core';
// import {FormGroup,FormBuilder,Validators} from '@angular/forms';
// import {Router} from '@angular/router';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })
// export class LoginComponent implements OnInit {
  
//   user:any={
//     username:"raj.shinde@gmail.com",
//     password:"seed",
//     remember:""
//   }

//   ngOnInit(): void {
    
 // }

  // login(){
  //   this.http.get<any>("http://localhost:3000/signupUsers")
  //   .subscribe(res=>{
  //    const user = res.find((a:any)=>{
  //       return a.email === this.loginForm.value.email && a.password === this.loginForm.value.password
  //     });
  //   if(user){
  //     alert("login success");
  //     this.loginForm.reset();
  //     this.router.navigate(['dashboard'])
  //   }
  //   else{
  //     alert("User not found");
  //   }
  // },err=>{
  //   alert("something went wrong");
  // })
 //}





 import{HttpClient} from '@angular/common/http';
 import {Component, OnInit } from '@angular/core';
 import {FormGroup,FormBuilder,Validators} from '@angular/forms';
 import {Router} from '@angular/router';
 import { UserValidationService } from '../user-validation.service';
 
 
 
 @Component({
 selector: 'app-login',
 templateUrl: './login.component.html',
 styleUrls: ['./login.component.css']
 })
 
 
 
 export class LoginComponent implements OnInit {
 user:any={
 username:"",
 password:""
 };
 userName="";
 validUser:any=false;
 
 public loginForm!:FormGroup;
 constructor(private svc:UserValidationService) { }
 
 
 
 ngOnInit(): void {
 }
 onValidate(form:any):void{
 console.log("Form validation event handler is invoked....");
 console.log(form.username + " " +form.password)
 
 this.svc.validate(form.username,form.password).subscribe(
 data=>{
 console.log("valid user");
 this.userName=data.username;
 console.log(data);
 this.validUser=true;
 });
 }
 }
    

















