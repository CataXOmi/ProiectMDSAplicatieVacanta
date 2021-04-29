export class Cazare {
    id: number;
    nume: string;
    tipCazare: string;
    pret: number;
    oras: string;
    adresa: string;
    setImagini: string;
    listaFacilitati: string[];
  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }