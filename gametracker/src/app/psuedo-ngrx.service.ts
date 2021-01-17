import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PsuedoNgrxService {

  private userId: number | undefined = undefined;

  constructor() { }

  login(userId: number | undefined) {
    this.userId = userId;
  }

  logout() {
    this.userId = undefined;
  }

  getUserId(): number | undefined {
    return this.userId;
  }

  isLoggedIn() : boolean {
    return this.userId === undefined;
  }
}
