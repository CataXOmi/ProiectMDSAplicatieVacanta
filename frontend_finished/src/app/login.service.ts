import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  
  private loginReference = new BehaviorSubject(false);
  currentValue = this.loginReference.asObservable();

  constructor() { }

  changeLoginValue(loginValue: boolean) {
    this.loginReference.next(loginValue);
  }
}
