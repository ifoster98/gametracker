import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PsuedoNgrxService {

  private userId: number | undefined = undefined;
  private match: Match | undefined = undefined;

  constructor() { }

  login(userId: number | undefined) {
    this.userId = userId;
  }

  logout() {
    this.userId = undefined;
    this.match = undefined;
  }

  getUserId(): number | undefined {
    return this.userId;
  }

  isLoggedIn() : boolean {
    return this.userId !== undefined;
  }

  chooseMatch(match: Match) {
    this.match = match;
  }

  endMatch() {
    this.match = undefined;
  }

  getMatch(): Match | undefined {
    return this.match;
  }

  isAtMatch(): boolean {
    return this.match !== undefined;
  }

  currentPage() : ViewPage {
    if(!this.isLoggedIn())
      return ViewPage.None;
    if(!this.isAtMatch())
      return ViewPage.MatchSelection;
    return ViewPage.EventEntry;
  }
}

export enum ViewPage {
  None,
  MatchSelection,
  EventEntry,
  EventEdit
}

export interface Match {
  id: number;
  name: string;
}

export interface Fooble {
  id: number;
  name: string;
}
