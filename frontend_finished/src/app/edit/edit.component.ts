import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { EditCazareModalComponent } from './edit-cazare-modal/edit-cazare-modal.component';
import { EditArtistModalComponent } from './edit-artist-modal/edit-artist-modal.component';
import { EditSongModalComponent } from './edit-song-modal/edit-song-modal.component';
import { Cazare } from '../shared/cazare.model';
import { Restaurant } from '../shared/restaurant.model';
import { Atractie } from '../shared/atractie.model';
import { EditRestaurantModalComponent } from './edit-restaurant-modal/edit-restaurant-modal.component';
import { EditAtractieModalComponent } from './edit-atractie-modal/edit-atractie-modal.component';
import { LoginService } from '../login.service';
import { Subscription } from 'rxjs';
import { LoginComponent } from '../login/login.component';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit, OnDestroy {
  atractii: Atractie[] = [];
  cazari: Cazare[] = [];
  restaurante: Restaurant[] = [];
  logged: boolean;
  subscription: Subscription;



  @ViewChild('editCazareModal') editCazareModal: EditCazareModalComponent;
  @ViewChild('editRestaurantModal') editRestaurantModal: EditRestaurantModalComponent;
  @ViewChild('editArtistModal') editArtistModal: EditArtistModalComponent;
  @ViewChild('editAtractieModal') editAtractieModal: EditAtractieModalComponent;
  @ViewChild('LoginComponent') loginPage: LoginComponent;


  constructor(private api: ApiService, private data: LoginService) { }

  ngOnInit() {
    this.getCazari();
    this.getAtractii();
    this.getRestaurante();
    this.subscription = this.data.currentValue.subscribe(loginVal => this.logged = loginVal);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  getCazari() {
    this.api.getCazari()
      .subscribe((data: Cazare[]) => {
        this.cazari = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getCazare(data[i].id)
            .subscribe((info: Cazare) => {
              info.id = data[i].id;
              this.cazari.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getAtractii() {
    this.api.getAtractii()
      .subscribe((data: Atractie[]) => {
        this.atractii = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getAtractie(data[i].id)
            .subscribe((info: Atractie) => {
              info.id = data[i].id;
              this.atractii.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getRestaurante() {
    this.api.getRestaurante()
      .subscribe((data: Restaurant[]) => {
        this.restaurante = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getRestaurant(data[i].id)
            .subscribe((info: Restaurant) => {
              info.id = data[i].id;
              this.restaurante.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  /*getSongs() {
    this.api.getSongs()
      .subscribe((data: Song[]) => {
        this.songs = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }*/

  deleteCazare(id: number) {
    this.api.deleteCazare(id)
      .subscribe(() => {
        this.cazari = [];
        this.getCazari();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteAtractie(id: number) {
    this.api.deleteAtractie(id)
      .subscribe(() => {
        this.getAtractii();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteRestaurant(id: number) {
    this.api.deleteRestaurant(id)
      .subscribe(() => {
        this.getRestaurante();
      },
        (error: Error) => {
          console.log(error);
        });

  }

  showM1(id: number): void {
    this.editCazareModal.show(id);
  }

  showM2(id: number): void {
    this.editAtractieModal.show(id);
  }

  showM3(id: number): void {
    this.editRestaurantModal.show(id);
  }

  changeE(event: string) {
    if (event === 'cazare') {
      this.getCazari();
    }
    if (event === 'atractie') {
      this.getAtractii();
    }
    if (event === 'restaurant') {
      this.getRestaurante();
    }


  }

}
