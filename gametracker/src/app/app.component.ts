import { Component } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'gametracker';
  results: Object = {};

  constructor(private _http: HttpService) {}

  ngOnInit() {
    this._http.getDataFromTestServer().subscribe(r => {
      console.log(r);
      this.results = r;
    });
  }
}
