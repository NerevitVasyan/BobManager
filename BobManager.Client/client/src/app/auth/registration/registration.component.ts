import { Component, OnInit } from '@angular/core';
import { RegisterDto } from 'src/app/models/register.model';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
	selector: 'app-registration',
	templateUrl: './registration.component.html',
	styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

	user: RegisterDto;

	constructor(private router: Router,
		private authService: AuthService) {
		this.user = { email: "", password: "", confirmPassword: "" };
	}

	register() {
		if (!this.isEmail(this.user.email)) {
			alert("Input correct Email.");
			return null;
		}
		if(this.user.password.length < 6)
		{
			alert("Bad password.");
			return null;
		}
		if (this.user.password != this.user.confirmPassword) {
			alert("Passwords don't identical.");
			return null;
		}
		this.authService.register(this.user).subscribe(res => {
			if (res.isSuccessful) {
				localStorage.setItem('token', res.data)
				this.router.navigate(['/home']);
			}
			else {
				alert(res.message);
			}
		});
		return null;
	}

	isEmail(search: string): boolean {
		var serchfind: boolean;
		var regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
		serchfind = regexp.test(search);
		console.log(serchfind)
		return serchfind
	}
}
