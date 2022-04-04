import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from "../register";
@Injectable({  
  providedIn: 'root'  
})  
export class LoginService {  
  Url: string;  
  header: any;  
  constructor(private http : HttpClient) {   
  
    this.Url = 'http://localhost:14812/api/account/';  
  
    const headerSettings: {[name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings);  
  }  
  Login(model : any){  
    debugger;  
     var a =this.Url+'login';  
   return this.http.post<any>(this.Url+'login',model,{ headers: this.header});  
  }  
   CreateUser(register:Register)  
   {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };  
    return this.http.post<Register[]>(this.Url + '/register/', register, httpOptions)  
   }  
} 