import { FormInputBase } from "./form-input-base";

export class FormDropDown extends FormInputBase<string> {
  override controlType = 'dropdown';
}