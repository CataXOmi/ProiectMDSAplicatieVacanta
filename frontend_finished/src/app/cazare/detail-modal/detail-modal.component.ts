import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Cazare } from '../../shared/cazare.model';
import { ApiService } from '../../shared/api.service';
import { CartService } from '../../shared/cart.service';

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {
  @ViewChild('detailModal') modal: ModalDirective;
  cazare = new Cazare();
  //studio: string;
  isLoggedIn: string;

  constructor(private api: ApiService, private cart: CartService) { }

  ngOnInit() {}

  show(id: number): void {
    this.getCazare(id);
    this.modal.show();
  }

  /*getStudio(id: number) {
    this.api.getStudio(id)
      .subscribe((data: Album) => {
        this.studio = data.name;
      },
        (err: Error) => {
          console.log('err', err);

        });
  }*/

  getCazare(id: number) {
    this.api.getCazare(id)
      .subscribe((data: Cazare) => {
        this.cazare = data;
        this.cazare.id = id;
        if (!data.setImagini) {
          this.cazare.setImagini = 'https://image.freepik.com/free-vector/booking-hotel-online-cartoon-icon-illustration-business-technology-icon-concept_138676-2126.jpg';
        }
        //this.getStudio(this.album.studioId);
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  addCart(cazare: Cazare) {
    this.cart.add(cazare);
    this.modal.hide();
  }
}
