import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthentificationService } from '../../services/authentification.service';
import { RegisterUser } from '../../models/register-user';
import { SimpleSnackBarService } from '../../services/simple-snack-bar.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthentificationService,
    private snackBar: SimpleSnackBarService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      firstName: ['', [Validators.required/*, Validators.pattern('[a-zA-Z]')*/]],
      lastName: ['', [Validators.required/*, Validators.pattern('[a-zA-Z]')*/]],
      username: ['', [Validators.required, Validators.minLength(4)]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  register() {
    if (this.form.valid) {
      let registerUser = new RegisterUser();
      registerUser.firstName = this.form.controls['firstName'].value;
      registerUser.lastName = this.form.controls['lastName'].value;
      registerUser.username = this.form.controls['username'].value;
      registerUser.password = this.form.controls['password'].value;

      this.authService.register(registerUser).subscribe(() => {
        this.router.navigate(['']);
        this.snackBar.openSuccess('User successfully created');
      });
    }
  }



}
