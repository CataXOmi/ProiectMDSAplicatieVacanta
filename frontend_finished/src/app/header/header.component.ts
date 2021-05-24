import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { CartModalComponent } from './cart-modal/cart-modal.component';
import { FavouritesModalComponent } from './favourites-modal/favourites-modal.component';
import { LoginService } from '../login.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {

  logged: boolean;
  username: string;
  subscription: Subscription;
  subscription1: Subscription;

  @ViewChild('cartModal') detailModal: CartModalComponent;
  @ViewChild('favouritesModal') favdetailModal: FavouritesModalComponent;

  constructor(private data: LoginService) { }

  ngOnInit() {
    this.subscription = this.data.currentValue.subscribe(loginVal => this.logged = loginVal);
    this.subscription1 = this.data.currentValue1.subscribe(userName => this.username = userName);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscription1.unsubscribe();
  }
  
  openCart() {
    this.detailModal.totalFinal = 0;
    this.detailModal.show();
  }

  openFavourites() {
    this.favdetailModal.show();
  }

  logoutUser() {
    console.log(this.logged);
    this.data.changeLoginValue(false, "");
    console.log(this.logged);
  }

  reloadCurrentPage() {
    window.location.reload();
   }
}