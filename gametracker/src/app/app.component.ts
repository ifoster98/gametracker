import { Component } from '@angular/core';
import { GameService } from './game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  enteredUserId: number | undefined = undefined;
  userId: number | undefined = undefined;
  loginErrorMessage: string = '';

  constructor(private _game: GameService) {}

  ngOnInit() {
  }

  showLoginPage(): boolean {
    return this.userId === undefined;
  }

  login() {
    this._game.login(this.enteredUserId).subscribe(response => {
      console.log(response);
      if(response.body) 
        this.userId = this.enteredUserId;
      else
        this.loginErrorMessage = 'Invalid login used. Please try again.';
    }, error => {
      this.loginErrorMessage = 'Invalid login used. Please try again.';
    });
  }

  logout() {
    this.userId = undefined;
  }
}
