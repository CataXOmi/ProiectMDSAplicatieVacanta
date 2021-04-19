export class Utilizator {
    id: number;
    username: string;
    nume: string;
    prenume: string;
    email: string;
    telefon: string;
    parola: string;
    fotografie: number[];
    rezervare: number[];
  
    constructor(input?: any) {
      Object.assign(this, input);
    }
  }