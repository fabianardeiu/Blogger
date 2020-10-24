import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthentificationService } from '../../services/authentification.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  error: boolean;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthentificationService
  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.form.valid) {
      let user = new User();
      user.username = this.form.controls['username'].value;
      user.password = this.form.controls['password'].value;

      this.authService.login(user).subscribe(person => {
        if (person != null) {
          this.router.navigate(['home']);
          localStorage.setItem('person', person.firstName + ' ' + person.lastName);
        } else {
          this.error = true;
        }
      })
    }
    else {
      this.form.markAllAsTouched;
    }
  }

  logout() {
    localStorage.clear();
  }


}
