import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CompanyService, CreateVacancyCommand, VacancyService } from 'src/app/common/api';
import { FormDropDown } from 'src/app/common/models/form-drop-down';
import { FormInputBase } from 'src/app/common/models/form-input-base';
import { FormTextBox } from 'src/app/common/models/form-text-box';
import { FormService } from 'src/app/common/services/form.service';

@Component({
  selector: 'app-create-vacancy',
  templateUrl: './create-vacancy.component.html',
  styleUrls: ['./create-vacancy.component.scss']
})
export class CreateVacancyComponent implements OnInit {

  public isSuccess = false;
  public isError = false;

  public form: FormGroup = new FormGroup({});

  public formFields: FormInputBase<string | boolean>[] = [
    new FormTextBox({
      key: 'title',
      type: 'textbox',
      label: 'Titel',
      required: true,
      order: 2
    }),
    new FormTextBox({
      key: 'description',
      type: 'textbox',
      label: 'Omschrijving',
      required: true,
      order: 3
    })
  ];

  constructor(
    private companyService: CompanyService,
    private vacancyService: VacancyService,
    private formService: FormService) { }

  ngOnInit(): void {
    this.companyService.companyGet().subscribe(result => {

      const items = result.map(x => {
        const dropdownItem: { key: string; value: string } = { key: x.id.toString(), value: x.name };
        return dropdownItem;
      });

      this.formFields.push(new FormDropDown({
        key: 'companyId',
        label: 'Bedrijf',
        required: true,
        type: "dropdown",
        options: items,
        order: 1
      }));

      this.form = this.formService.createFormGroup(this.formFields);
    })
  }

  get controls() {
    return this.form.controls;
  }

  public onSubmit() {
    this.form.markAllAsTouched();
    this.isSuccess = false;
    this.isError = false;

    if (this.form.valid) {
      const vacancy = this.form.value as CreateVacancyCommand;
      this.vacancyService.vacancyPost(vacancy).subscribe({
        next: () => { this.isSuccess = true },
        error: () => { this.isSuccess = false }
      });
    }
  }
}
