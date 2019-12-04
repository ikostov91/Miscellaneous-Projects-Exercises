import { Directive } from '@angular/core';
import { Validator, AbstractControl, NG_VALIDATORS, ValidationErrors } from '@angular/forms';
import { HoursValidator } from './hours.validator';

@Directive({
  selector: '[hours][ngModel]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: HoursDirective,
    multi: true
  }]
})
export class HoursDirective implements Validator {

  private validator = HoursValidator;

  constructor() { }

  validate(control: AbstractControl): { [key: string] : any } {
    return this.validator(control);
  }

  registerOnValidatorChange?(fn: () => void): void {
    throw new Error("Method not implemented.");
  }
}
