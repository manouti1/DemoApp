import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  model: any = {};

  errorMessage: string;
  constructor(private router: Router, private LoginService: LoginService) {
    this.errorMessage='';
  }

  ngOnInit() {
    sessionStorage.removeItem('UserName');
    sessionStorage.clear();
  }
  login() {
    debugger;
    this.LoginService.Login(this.model).subscribe(
      (data) => {
        debugger;
        if (data.Status == 'Success') {
          this.router.navigate(['/Dashboard']);
          debugger;
        } else {
          this.errorMessage = data.Message;
        }
      },
      (error) => {
        this.errorMessage = error.message;
      }
    );
  }
}
