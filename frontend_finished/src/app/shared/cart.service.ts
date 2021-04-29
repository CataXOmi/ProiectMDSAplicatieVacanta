
import {Injectable} from '@angular/core';
import {Cazare} from './cazare.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  cazari: Cazare[] =[];


  constructor() {

  }

  add(cazare: Cazare){
    this.cazari.push(cazare);

  }

  get() {
    return this.cazari;
  }


}
