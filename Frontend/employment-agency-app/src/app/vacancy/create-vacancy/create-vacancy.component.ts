import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CompanyService, CreateVacancyCommand, VacancyService } from 'src/app/common/api';
import { FormDropDown } from 'src/app/common/models/form-drop-down';
import { FormInputBase } from 'src/app/common/models/form-input-base';
import { FormTextBox } from 'src/app/common/models/form-text-box';
import { FormService } from 'src/app/common/services/form.service';

@Component({
  selector: 'app-create-vacancy',
  templateUrl: './create-vacancy.component.html'
})

export class CreateVacancyComponent implements OnInit {

  public isSuccess = false;
  public isError = false;

  public form: FormGroup = new FormGroup({});

  private dropDownField = new FormDropDown({
    key: 'companyId',
    label: 'Bedrijf',
    required: true,
    type: "dropdown",
    options: [],
    order: 1
  });

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
    }),
    this.dropDownField
  ];

  public get controls() {
    return this.form.controls;
  }

  constructor(
    private readonly companyService: CompanyService,
    private readonly vacancyService: VacancyService,
    private readonly formService: FormService) { }

  public ngOnInit(): void {
    this.companyService.companyGet().subscribe(result => {

      const items = result.map(x => {
        const dropdownItem: { key: string; value: string } = { key: x.id.toString(), value: x.name };
        return dropdownItem;
      });

      this.dropDownField.options = items;

      this.form = this.formService.createFormGroup(this.formFields);
    })
  }  

  public onSubmit() {
    this.form.markAllAsTouched();
    this.isSuccess = false;
    this.isError = false;

    if (this.form.valid) {
      const vacancy = this.form.value as CreateVacancyCommand;
      this.vacancyService.vacancyPost(vacancy).subscribe({
        next: () => { this.isSuccess = true },
        error: () => { this.isError = true }
      });
    }
  }
}
