import { Component, OnInit, ViewChild } from '@angular/core';
import { Cazare } from '../shared/cazare.model';
import { DetailModalComponent } from '../cazare/detail-modal/detail-modal.component';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  cazari: Cazare[] = [];
  searchText: string;
  title: string;

  @ViewChild('detailModal') detailModal: DetailModalComponent;


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getCazari().subscribe((data: Cazare[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getCazare(data[i].id).subscribe((info: Cazare) => {
          info.id = data[i].id;
          if (!info.setImagini) {
            info.setImagini = 'https://image.freepik.com/free-vector/booking-hotel-online-cartoon-icon-illustration-business-technology-icon-concept_138676-2126.jpg';
          }
        
          this.cazari.push(info);
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },
      (er: Error) => {
        console.log('err', er);
      });
  }

  showDM(id: number): void {
    this.detailModal.show(id);
  }
}
