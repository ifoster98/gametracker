import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { Fooble, PsuedoNgrxService } from '../psuedo-ngrx.service';

@Component({
  selector: 'app-event-entry',
  templateUrl: './event-entry.component.html',
  styleUrls: ['./event-entry.component.scss']
})
export class EventEntryComponent implements OnInit {
  currentMatch: string | undefined = '';
  events: Fooble[] = [
    {"id": 1, "fooName": "Conversion"},
    {"id": 2, "fooName": "Try"},
    {"id": 3, "fooName": "Penalty"},
  ];

  constructor(private _ngrx: PsuedoNgrxService, private _game: GameService) {}

  ngOnInit(): void {
    this.currentMatch = this._ngrx.getMatch()?.name;
  }

  endMatch() {
    this._ngrx.endMatch();
  }

  registerEvent(bar: Fooble) {
  }

}
