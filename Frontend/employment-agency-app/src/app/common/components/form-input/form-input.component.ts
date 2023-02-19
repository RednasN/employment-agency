import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormInputBase } from '../../models/form-input-base';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent {
  @Input() public field!: FormInputBase<string | boolean>;
  @Input() public form!: FormGroup;

  get isValid() {
    const control = this.form.controls[this.field.key];
    if (control && control.touched && !control.valid) {
      return false;
    }

    return true;
  }
}
