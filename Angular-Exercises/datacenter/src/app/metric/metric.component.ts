import { Component, Input, ChangeDetectionStrategy, OnChanges, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-metric',
  templateUrl: './metric.component.html',
  styleUrls: ['./metric.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.Emulated
})
export class MetricComponent implements OnChanges {

  @Input() title: string = '';
  @Input('used') value: number;
  @Input('available') max: number;

  constructor() { }

  ngOnChanges(changes): void {
    if (changes.value && isNaN(changes.value.currentValue)) {
      this.value = 0;
    }
    if (changes.max && isNaN(changes.max.currentValue)) { 
      this.max = 0;
    }
  }

  isDanger() {
    return this.value / this.max > 0.7;
  }
}
