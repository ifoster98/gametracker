import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Fooble, Match } from './psuedo-ngrx.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private baseUrl = 'http://localhost';

  constructor(private http: HttpClient) { }

  login(userId: number | undefined) {
    return this.http.get(`${this.baseUrl}/LoginWithUserId/${userId}`, { observe: 'response' });
  }

  getMatches() {
    return this.http.get<Match[]>(`${this.baseUrl}/Matches`, { observe: 'response' });
  }

  getEvents() {
    return this.http.get<Fooble[]>(`${this.baseUrl}/Events`, { observe: 'response' });
  }
}
