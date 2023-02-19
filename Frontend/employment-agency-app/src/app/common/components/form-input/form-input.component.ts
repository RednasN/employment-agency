import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormInputBase } from '../../models/form-input-base';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
})
export class FormInputComponent {
  @Input() public field!: FormInputBase<string | boolean>;
  @Input() public form!: FormGroup;

  public get isValid() {
    const control = this.form.controls[this.field.key];    
    return !(control && control.touched && !control.valid);
  }
}
