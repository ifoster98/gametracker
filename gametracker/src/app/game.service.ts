import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private baseUrl = 'http://localhost';

  constructor(private http: HttpClient) { }

  login(userId: number | undefined) {
    return this.http.get(`${this.baseUrl}/LoginWithUserId/${userId}`, { observe: 'response' });
  }
}
