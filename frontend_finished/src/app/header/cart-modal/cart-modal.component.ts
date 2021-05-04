import { Component, OnInit, ViewChild } from '@angular/core';
import { Cazare } from 'src/app/shared/cazare.model';
import { CartService } from 'src/app/shared/cart.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from '../../shared/api.service';
import { Vacanta } from 'src/app/shared/vacanta.model';
import { Atractie } from 'src/app/shared/atractie.model';
import { Restaurant } from 'src/app/shared/restaurant.model';

@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.component.html',
  styleUrls: ['./cart-modal.component.css']
})

export class CartModalComponent implements OnInit {
  @ViewChild('cartModal') modal: ModalDirective;
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
  vacanteDisponibile: Vacanta[] = [];
  vacationsName: string[] = [];

  constructor(private cartService: CartService, private api : ApiService) { }

  ngOnInit() {
    this.displayVacations();
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

  displayVacations (){
    this.api.getVacante()
      .subscribe((data: Vacanta[]) => {
        this.vacanteDisponibile = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getVacanta(data[i].id)
            .subscribe((info: Vacanta) => {
              info.id = data[i].id;
              this.vacanteDisponibile.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
    for (let i = 0; i < this.vacanteDisponibile.length; i++)
    {
      this.vacationsName.push(this.vacanteDisponibile[i].denumire);
    }
}
}
