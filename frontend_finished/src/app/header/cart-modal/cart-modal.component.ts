import { Component, OnInit, ViewChild } from '@angular/core';
import { Cazare } from 'src/app/shared/cazare.model';
import { CartService } from 'src/app/shared/cart.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from '../../shared/api.service';
import { Vacanta } from 'src/app/shared/vacanta.model';

@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.component.html',
  styleUrls: ['./cart-modal.component.css']
})

export class CartModalComponent implements OnInit {
  @ViewChild('cartModal') modal: ModalDirective;
  products: Cazare[] = [];
  dateStart: string[] = [];
  dateSfarsit: string[] = [];
  sum = 0;
  differenceBetweenDates: number[] = [];
  total: number[] = [];
  vacanteDisponibile: Vacanta[] = [];
  vacationsName: string[] = [];

  constructor(private cartService: CartService, private api : ApiService) { }

  ngOnInit() {
    this.displayVacations();
  }

  show() {
    this.modal.show();
    var result = this.cartService.get();
    this.products = result[0] as Cazare[];
    this.dateStart = result[1] as string[];
    this.dateSfarsit = result[2] as string[];
    var oneDay = 24 * 60 * 60 * 1000;
    for (let i = 0; i < this.dateStart.length; i++)
    {
      var firstDate = Date.parse(this.dateStart[i]);
      var secondDate = Date.parse(this.dateSfarsit[i]);
      this.differenceBetweenDates[i] = Math.round(Math.abs((firstDate-secondDate)/oneDay));
      this.total[i] = this.products[i].pret * this.differenceBetweenDates[i];
    }
    for (let i = 0; i < this.total.length; i++) {
      this.sum += this.total[i];
    }
  }

  delete(id: number, pret: number) {
    this.products.splice(id, 1);
    this.dateStart.splice(id, 1);
    this.dateSfarsit.splice(id, 1);
    this.sum = this.sum - pret;
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
