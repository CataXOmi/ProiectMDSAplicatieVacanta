import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {HttpClientModule} from '@angular/common/http';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { EditAlbumModalComponent } from './edit/edit-album-modal/edit-album-modal.component';
import { EditArtistModalComponent } from './edit/edit-artist-modal/edit-artist-modal.component';
import { EditSongModalComponent } from './edit/edit-song-modal/edit-song-modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HomeComponent } from './home/home.component';
import { SearchPipe } from './shared/search.pipe';
import { DetailModalComponent } from './home/detail-modal/detail-modal.component';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { CartModalComponent } from './header/cart-modal/cart-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    AddComponent,
    EditComponent,
    EditAlbumModalComponent,
    EditArtistModalComponent,
    EditSongModalComponent,
    HomeComponent,
    SearchPipe,
    DetailModalComponent,
    HeaderComponent,
    CartModalComponent,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
