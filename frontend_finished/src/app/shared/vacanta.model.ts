export class Vacanta {
    id: number;
    denumire: string;
    dataInceput: string;
    dataSfarsit: number;
    oras: string;
    tara: string;

  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }