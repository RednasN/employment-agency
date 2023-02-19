import { FormInputBase } from "./form-input-base";

export class FormTextBox extends FormInputBase<string> {
  override controlType = 'textbox';
}