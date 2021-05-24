import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ApiService } from '../shared/api.service';
import { Utilizator } from '../shared/utilizator.model';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  isLoggedIn: boolean;
  submitted = false;
  loading = false;
  loginError: string;
  loginForm: FormGroup;
  registerForm: FormGroup;
  inLogin = true;
  inRegister = false;
  utilizatori: Utilizator[] = [];
  success: boolean;
  subscription: Subscription

  constructor(private api: ApiService, private fb: FormBuilder, private router: Router, private data: LoginService) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      parola: [null, Validators.required]
    });

    this.registerForm = this.fb.group({
      nume: [null, Validators.required],
      prenume: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      telefon: [null],
      username: [null, Validators.required],
      parola: [null, Validators.required]
    });

    this.api.getUtilizatori().subscribe((data: Utilizator[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getUtilizator(data[i].id).subscribe((info: Utilizator) => {
          info.id = data[i].id;
        
          this.utilizatori.push(info);
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },
      (er: Error) => {
        console.log('err', er);
      });
    
      this.subscription = this.data.currentValue.subscribe(loginVal => this.isLoggedIn = loginVal);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  get f() { return this.loginForm.controls; }

  get f1() { return this.registerForm.controls; }

  onLoginSubmit(){  

    this.submitted = true;
    this.loading = true;
    for (let i = 0; i < this.utilizatori.length; i++)
    {
      if (this.loginForm.get('email').value === this.utilizatori[i].email && this.loginForm.get('parola').value === this.utilizatori[i].parola)
      {
        this.data.changeLoginValue(true, this.utilizatori[i].username);
        console.log(this.isLoggedIn);
         this.router.navigate(['']);
        break;
      }
      else {
        this.loginError = "Nu s-a putut realiza logarea. Va rugam sa incercati din nou!";
        this.loading = false;
      }
      } 
    }

    onRegisterSubmit(){  

      this.submitted = true;
      this.loading = true;
      console.log(this.registerForm.value);
      this.api.addUtilizator(this.registerForm.value).subscribe(() => {

        this.registerForm.reset();
        this.data.changeLoginValue(true, this.registerForm.value.username);
        this.success = true;
        setTimeout(() => {
          this.success = null;
        }, 3000);
        this.router.navigate(['']);
      },
        (error: Error) => {
          console.log(error);
          this.registerForm.reset();
          this.success = false;
          setTimeout(() => {
            this.success = null;
          }, 3000);
        });
    }
}
