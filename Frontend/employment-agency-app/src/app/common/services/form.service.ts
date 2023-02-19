import { Injectable } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { FormInputBase } from "../models/form-input-base";

@Injectable({
    providedIn: 'root'
})
export class FormService {

    public createFormGroup(fields: FormInputBase<string | boolean>[]): FormGroup {
        const group: Record<string, FormControl> = {};
        fields.sort((a, b) => a.order - b.order).forEach(field => {
            group[field.key] = field.required ? new FormControl(field.value || '', Validators.required)
                : new FormControl(field.value || '');
        });

        return new FormGroup(group);
    }
}