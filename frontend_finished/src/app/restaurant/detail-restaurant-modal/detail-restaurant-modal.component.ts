import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Restaurant } from '../../shared/restaurant.model';
import { ApiService } from '../../shared/api.service';
import { CartService } from '../../shared/cart.service';

@Component({
  selector: 'app-detail-restaurant-modal',
  templateUrl: './detail-restaurant-modal.component.html',
  styleUrls: ['./detail-restaurant-modal.component.css']
})
export class DetailRestaurantModalComponent implements OnInit {

  @ViewChild('detailRestaurantModal') modal: ModalDirective;
  restaurant = new Restaurant();
  //studio: string;
  dataRezervare: string = "";
  numarPersoane: number;
  isLoggedIn: string;

  constructor(private api: ApiService, private cart: CartService) { }

  ngOnInit() {}

  show(id: number): void {
    this.getRestaurant(id);
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

  getRestaurant(id: number) {
    this.api.getRestaurant(id)
      .subscribe((data: Restaurant) => {
        this.restaurant = data;
        this.restaurant.id = id;
        if (!data.listaImagini) {
          this.restaurant.listaImagini = 'assets/24769916.jpg';
        }
        //this.getStudio(this.album.studioId);
      },
        (err: Error) => {
          console.log('err', err);

        });
  }

  addCart(restaurant: Restaurant) {
    this.cart.add_restaurant(restaurant, this.dataRezervare, this.numarPersoane);
    //console.log(this.dataStart, "+", this.dataSfarsit);
    this.modal.hide();
  }

}
