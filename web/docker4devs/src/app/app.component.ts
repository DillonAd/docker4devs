import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ValueService } from './value.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  values: Observable<string[]>;

  constructor(private valueService: ValueService) {
    this.values = valueService.getValues();
  }
}
