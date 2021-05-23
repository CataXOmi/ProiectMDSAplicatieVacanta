import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../shared/api.service';
import { LoginService } from '../login.service';
import { Subscription } from 'rxjs';
import { Cazare } from '../shared/cazare.model';
import { Restaurant } from '../shared/restaurant.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  addCazareForm: FormGroup;
  addAtractieForm: FormGroup;
  addRestaurantForm: FormGroup;
  addMancareForm: FormGroup;
  addFacilitateForm: FormGroup;
  success: boolean;
  logged: boolean;
  subscription: Subscription;

  constructor(public fb: FormBuilder, private api: ApiService, private data: LoginService) { }


  ngOnInit() {

    this.addCazareForm = this.fb.group({
      nume: [null, Validators.required],
      tipCazare: [null, Validators.required],
      pret: [null, Validators.required],
      oras: [null, Validators.required],
      adresa: [null, Validators.required],
      setImagini: [null],
      listaFacilitatiID: ['', Validators.required]
    });
    this.addAtractieForm = this.fb.group({
      denumire: [null, Validators.required],
      oraDeschidere: [null, Validators.required],
      oraInchidere: [null, Validators.required],
      pret: [null, Validators.required],
      oras: [null, Validators.required],
      adresa: [null, Validators.required],
      listaImagini: [null]
    });
    this.addMancareForm = this.fb.group({
      denumire: [null, Validators.required],
    });
    this.addFacilitateForm = this.fb.group({
      denumire: [null, Validators.required],
    });
    this.addRestaurantForm = this.fb.group({
      nume: [null, Validators.required],
      oraDeschidere: [null, Validators.required],
      oraInchidere: [null, Validators.required],
      oras: [null, Validators.required],
      adresa: [null, Validators.required],
      meniuID: ['', Validators.required],
      listaImagini: [null]
    });

    this.subscription = this.data.currentValue.subscribe(loginVal => this.logged = loginVal);

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  addNewAtractie() {
  
    this.api.addAtractie(this.addAtractieForm.value).subscribe(() => {

      this.success = true;
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

  addNewCazare() {

    const addedCazare = new Cazare({
      nume: this.addCazareForm.value.nume,
      tipCazare: this.addCazareForm.value.tipCazare,
      pret: this.addCazareForm.value.pret,
      adresa: this.addCazareForm.value.adresa,
      oras: this.addCazareForm.value.oras,
      listaFacilitatiID: this.transformInNumberArray(this.addCazareForm.value.listaFacilitatiID),
      setImagini: this.addCazareForm.value.setImagini
    });
  
    this.api.addCazare(addedCazare).subscribe(() => {

      this.success = true;
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


  addNewFacilitate() {
  
    this.api.addFacilitate(this.addFacilitateForm.value).subscribe(() => {

      this.success = true;
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

  addNewMancare() {
  
    this.api.addMancare(this.addMancareForm.value).subscribe(() => {

      this.success = true;
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


  addNewRestaurant() {

    const addedRestaurant = new Restaurant({
      nume: this.addRestaurantForm.value.nume,
      oraDeschidere: this.addRestaurantForm.value.oraDeschidere,
      oraInchidere: this.addRestaurantForm.value.OraInchidere,
      adresa: this.addRestaurantForm.value.adresa,
      oras: this.addRestaurantForm.value.oras,
      meniuID: this.transformInNumberArray(this.addRestaurantForm.value.meniuID),
      listaImagini: this.addRestaurantForm.value.listaImagini
    });
  
    this.api.addRestaurant(addedRestaurant).subscribe(() => {

      this.success = true;
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

  transformInNumberArray(string: string) {
    return JSON.parse('[' + string + ']');
  }
}
