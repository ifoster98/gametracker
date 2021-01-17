import { Component } from '@angular/core';
import { GameService } from './game.service';
import { PsuedoNgrxService } from './psuedo-ngrx.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  enteredUserId: number | undefined = undefined;
  loginErrorMessage: string = '';

  constructor(private _ngrx: PsuedoNgrxService, private _game: GameService) {}

  ngOnInit() {
  }

  showLoginPage(): boolean {
    return this._ngrx.isLoggedIn();
  }

  login() {
    this._game.login(this.enteredUserId).subscribe(response => {
      if(response.body) 
        this._ngrx.login(this.enteredUserId);
      else
        this.loginErrorMessage = 'Invalid login used. Please try again.';
    }, error => {
      this.loginErrorMessage = 'Invalid login used. Please try again.';
    });
  }

  logout() {
    this._ngrx.logout();
  }
}
