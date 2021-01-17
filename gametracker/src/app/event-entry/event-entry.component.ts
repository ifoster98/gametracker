import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { Fooble, PsuedoNgrxService } from '../psuedo-ngrx.service';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-event-entry',
  templateUrl: './event-entry.component.html',
  styleUrls: ['./event-entry.component.scss']
})
export class EventEntryComponent implements OnInit {
  currentMatch: string | undefined = '';
  events: Fooble[] | null = null;
  message: string = '';

  constructor(private _ngrx: PsuedoNgrxService, private _game: GameService) {}

  ngOnInit(): void {
    this.currentMatch = this._ngrx.getMatch()?.name;
    this._game.getEvents().subscribe(response => {
      this.events = response.body;
    });
  }

  endMatch() {
    this._ngrx.endMatch();
  }

  registerEvent(bar: Fooble) {
    let eventTime = formatDate(new Date(), 'yyyy-MM-ddTHH:mm:ss', 'en');
    this._game.saveEvent(this._ngrx.getUserId(), this._ngrx.getMatch()?.id, eventTime, bar.id).subscribe(result => {
      this.message = 'Entry saved successfully.';
    }, error => {
      this.message = 'Error saving entry.';
    });
  }

}
