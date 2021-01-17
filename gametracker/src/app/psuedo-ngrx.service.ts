import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PsuedoNgrxService {

  private userId: number | undefined = undefined;
  private matchId: number | undefined = undefined;

  constructor() { }

  login(userId: number | undefined) {
    this.userId = userId;
  }

  logout() {
    this.userId = undefined;
    this.matchId = undefined;
  }

  getUserId(): number | undefined {
    return this.userId;
  }

  isLoggedIn() : boolean {
    return this.userId !== undefined;
  }

  chooseMatch(matchId: number) {
    this.matchId = matchId;
  }

  endMatch() {
    this.matchId = undefined;
  }

  getMatchId(): number | undefined {
    return this.matchId;
  }

  isAtMatch(): boolean {
    return this.matchId !== undefined;
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
