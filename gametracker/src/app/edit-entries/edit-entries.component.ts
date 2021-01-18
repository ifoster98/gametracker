import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { MatchEvent, PsuedoNgrxService } from '../psuedo-ngrx.service';

@Component({
  selector: 'app-edit-entries',
  templateUrl: './edit-entries.component.html',
  styleUrls: ['./edit-entries.component.scss']
})
export class EditEntriesComponent implements OnInit {
  currentMatch: string | undefined = '';
  matchEvents: MatchEvent[] | undefined = undefined;

  constructor(private _ngrx: PsuedoNgrxService, private _game: GameService) {}

  ngOnInit(): void {
    this.currentMatch = this._ngrx.getMatch()?.name;
    this.matchEvents = this._ngrx.getMatchEvents();
  }

  endEdit(): void {
    this._ngrx.endEditing();
  }
}
