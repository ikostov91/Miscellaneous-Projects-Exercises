import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appCardType]'
})
export class CardTypeDirective implements OnInit {

  @Input() appCardType: number = 0;
  @Input() increaseClass = 'increase';
  @Input() decreaseClass = 'decrease';

  constructor(private el: ElementRef) { }

  ngOnInit(): void {
    if (this.appCardType) {
      if (this.appCardType >= 0) {
        this.el.nativeElement.classList.add(this.increaseClass);
        this.el.nativeElement.classList.remove(this.decreaseClass);
      } else if (this.appCardType <= 0) {
        this.el.nativeElement.classList.add(this.decreaseClass);
        this.el.nativeElement.classList.remove(this.increaseClass);
      } else {
        this.el.nativeElement.classList.remove(this.increaseClass);
        this.el.nativeElement.classList.remove(this.decreaseClass);
      }
    }
  }
}
