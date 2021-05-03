
import {Injectable} from '@angular/core';
import {Cazare} from './cazare.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  cazari: Cazare[] =[];
  dataStart: string[] = [];
  dataSfarsit: string[] = [];


  constructor() {

  }

  add(cazare: Cazare, datastart: string, datasfarsit: string){
    this.cazari.push(cazare);
    this.dataStart.push(datastart);
    this.dataSfarsit.push(datasfarsit);

  }

  get() {
    return [this.cazari, this.dataStart, this.dataSfarsit];
  }


}
