import { Component, OnInit } from '@angular/core';
import { CompanyDto, CompanyService } from 'src/app/common/api';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss']
})
export class CompanyListComponent implements OnInit {

  public companies: CompanyDto[] = [];
  
  private filterCompaniesWithVacanciesActive = false;

  constructor(private readonly companyService: CompanyService) {}

  public ngOnInit(): void {
    this.companyService.companyGet(true).subscribe(result => {
      this.companies = result;
    });
  }

  public hasVacancies(company : CompanyDto) : boolean {
      return company.vacancies.length > 0;
  }

  public onOnlyWithVacanciesChanged(event: Event ) {
    
    this.filterCompaniesWithVacanciesActive = (event.target as HTMLInputElement).checked;
  }

  public filterCompaniesWithVacancies = (company: CompanyDto): boolean => !this.filterCompaniesWithVacanciesActive || company.vacancies.length > 0;
}
