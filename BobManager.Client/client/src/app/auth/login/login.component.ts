import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LoginDto } from 'src/app/models/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {

  user: LoginDto;

  constructor(private router: Router,
    private authService: AuthService) {
    this.user = { email: "", password: "", isRemember: false };
  }

  login() {
    if(this.user.email.length < 4)
    {
      alert("Input email.");
      return null;
    }
    if(this.user.password.length < 6)
    {
      alert("Input password.");
      return null;
    }
    this.authService.login(this.user).subscribe(res => {
      if(res.isSuccessful){
        localStorage.setItem('token',res.data);
        this.router.navigate(['/home']);
      }
      else {
				alert(res.message);
			}
    });
    console.log(this.user);
    return null;
  }
}