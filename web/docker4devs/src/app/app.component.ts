import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ValueService } from './value.service';
import { Value } from "./value";
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  values: Observable<string[]>;
  @Input() value: Value;

  constructor(private valueService: ValueService) {
    this.value = { Name: null };
  }

  ngOnInit() {
    this.values = this.valueService.getValues();
  }

  addValue(): void {
    console.log(this.value);
    this.valueService.addValue(this.value).subscribe(
      complete => { this.values = this.valueService.getValues(); this.values.pipe },
      error => alert(error)
    );
  }
}
