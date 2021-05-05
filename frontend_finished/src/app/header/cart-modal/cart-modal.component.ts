import { Component, OnInit, ViewChild, OnDestroy} from '@angular/core';
import { Cazare } from 'src/app/shared/cazare.model';
import { CartService } from 'src/app/shared/cart.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from '../../shared/api.service';
import { ChooseVacationModalComponent } from './choose-vacation-modal/choose-vacation-modal.component';
import { Atractie } from 'src/app/shared/atractie.model';
import { Restaurant } from 'src/app/shared/restaurant.model';
import { LoginComponent } from 'src/app/login/login.component';
import { LoginService } from '../../login.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.component.html',
  styleUrls: ['./cart-modal.component.css']
})

export class CartModalComponent implements OnInit, OnDestroy {

  @ViewChild('cartModal') modal: ModalDirective;
  @ViewChild('chooseVacationModal') vacationModal: ChooseVacationModalComponent;
  @ViewChild('LoginComponent') loginPage: LoginComponent;
  rezervariCazari: Cazare[] = [];
  dateStart: string[] = [];
  dateSfarsit: string[] = [];
  rezervariAtractii: Atractie[] = [];
  numarBilete: number[] = [];
  dateViziteAtractii: string[] = [];
  rezervariRestaurante: Restaurant[] = [];
  dateRezervariRestaurante: string[] = [];
  numarPersoane: number[] = [];
  totalFinal = 0;
  differenceBetweenDates: number[] = [];
  totalCazare: number[] = [];
  totalAtractie: number[] = [];
  idVacanta: number = 0;
  success: boolean;
  logged: boolean;
  subscription: Subscription;


  constructor(private cartService: CartService, private api : ApiService, private data: LoginService) { }

  ngOnInit() {
    this.subscription = this.data.currentValue.subscribe(loginVal => this.logged = loginVal);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  show() {
    this.modal.show();
    var result = this.cartService.get();
    this.rezervariCazari = result[0] as Cazare[];
    this.dateStart = result[1] as string[];
    this.dateSfarsit = result[2] as string[];
    this.rezervariAtractii = result[3] as Atractie[];
    this.dateViziteAtractii = result[4] as string[];
    this.numarBilete = result[5] as number[];
    this.rezervariRestaurante = result[6] as Restaurant[];
    this.dateRezervariRestaurante = result[7] as string[];
    this.numarPersoane = result[8] as number[];
    var oneDay = 24 * 60 * 60 * 1000;
    for (let i = 0; i < this.dateStart.length; i++)
    {
      var firstDate = Date.parse(this.dateStart[i]);
      var secondDate = Date.parse(this.dateSfarsit[i]);
      this.differenceBetweenDates[i] = Math.round(Math.abs((firstDate-secondDate)/oneDay));
      this.totalCazare[i] = this.rezervariCazari[i].pret * this.differenceBetweenDates[i];
    }
    for (let i = 0; i < this.totalCazare.length; i++) {
      this.totalFinal += this.totalCazare[i];
    }

    for (let i = 0; i < this.rezervariAtractii.length; i++)
    {
      this.totalAtractie[i] = this.rezervariAtractii[i].pret * this.numarBilete[i];
    }
    for (let i = 0; i < this.totalAtractie.length; i++)
    {
      this.totalFinal += this.totalAtractie[i];
    }

  }

  delete(id: number, pret: number) {
    if ( id <= this.rezervariCazari.length)
    {
      this.rezervariCazari.splice(id, 1);
      this.dateStart.splice(id, 1);
      this.dateSfarsit.splice(id, 1);
    }
    else if (id >= this.rezervariCazari.length && id <= (this.rezervariCazari.length + this.rezervariAtractii.length))
    {
      this.rezervariAtractii.splice(id-this.rezervariCazari.length-1, 1);
      this.dateViziteAtractii.splice(id-this.rezervariCazari.length-1, 1);
      this.numarBilete.splice(id-this.rezervariCazari.length-1, 1);
    }
    else {
      this.rezervariRestaurante.splice(id-this.rezervariCazari.length-this.rezervariAtractii.length-1, 1);
      this.dateRezervariRestaurante.splice(id-this.rezervariCazari.length-this.rezervariAtractii.length-1, 1);
      this.numarPersoane.splice(id-this.rezervariCazari.length-this.rezervariAtractii.length-1, 1);
    }
    this.totalFinal = this.totalFinal - pret;
  }

  makeid(length: number) {
    var result           = [];
    var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+-*/@#$&\`~';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result.push(characters.charAt(Math.floor(Math.random() * 
 charactersLength)));
   }
   return result.join('');
}

  addRezervareC() {
    let date: any = {};
    for (let i = 0; i < this.rezervariCazari.length; i++)
    {
      date.vacantaID = this.vacationModal.get();
      date.cazareID = this.rezervariCazari[i].id;
      date.codRezervare = this.makeid(8);
      date.dataSosire = this.dateSfarsit[i];
      date.dataPlecare = this.dateStart[i];

      this.api.addRezervareCazare(date).subscribe(() => {

      this.success = true;
      this.delete(i, this.totalCazare[i]);
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
    (error: Error) => {
      console.log(error);
      this.success = false;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    });
    }
    console.log(date.vacantaID);
    console.log(date.cazareID);
    console.log(date.codRezervare);
    console.log(date.dataSosire);
    console.log(date.dataPlecare);
  }

  addTichetM() {
    let date: any = {};
    for (let i = 0; i < this.rezervariRestaurante.length; i++)
    {
      date.vacantaID = this.vacationModal.get();
      date.restaurantID = this.rezervariRestaurante[i].id;
      date.codTichet = this.makeid(5);
      date.dataVizita = this.dateRezervariRestaurante[i];

      this.api.addTichetMasa(date).subscribe(() => {

      this.success = true;
      this.delete(i + this.rezervariCazari.length + this.rezervariRestaurante.length + 1, 0);
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
    (error: Error) => {
      console.log(error);
      this.success = false;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    });
    }
    console.log(date.vacantaID);
    console.log(date.restaurantID);
    console.log(date.codTichet);
    console.log(date.dataVizita);
  }

  addBiletA() {
    let date: any = {};
    for (let i = 0; i < this.rezervariAtractii.length; i++)
    {
      date.vacantaID = this.vacationModal.get();
      date.atractieID = this.rezervariAtractii[i].id;
      date.codBilet = this.makeid(10);
      date.dataVizita = this.dateViziteAtractii[i];

      this.api.addBilet(date).subscribe(() => {

      this.success = true;
      this.delete(i + this.rezervariCazari.length + 1, this.totalAtractie[i]);
      setTimeout(() => {
        this.success = null;
      }, 3000);
    },
    (error: Error) => {
      console.log(error);
      this.success = false;
      setTimeout(() => {
        this.success = null;
      }, 3000);
    });
    }
    console.log(date.vacantaID);
    console.log(date.atractieID);
    console.log(date.codBilet);
    console.log(date.dataVizita);
  }

  doLater() {
    setTimeout(() => {
      this.addRezervareC();
      this.addTichetM();
      this.addBiletA();
  }, 5000);
  }
    
}
