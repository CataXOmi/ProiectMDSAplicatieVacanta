export class Vacanta {
    id: number;
    denumire: string;
    dataInceput: string;
    dataSfarsit: number;

  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }