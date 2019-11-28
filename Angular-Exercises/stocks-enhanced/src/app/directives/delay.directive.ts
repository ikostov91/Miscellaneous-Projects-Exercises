import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appDelay]'
})
export class DelayDirective {

  @Input() set appDelay(ms: number) {
    setTimeout(() => {
      this.viewContainer.createEmbeddedView(this.templateRef);
    }, ms);
  }

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef) { }

}
