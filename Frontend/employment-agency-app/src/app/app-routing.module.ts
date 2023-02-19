import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyListComponent } from './company/company/company-list/company-list.component';
import { CompanyComponent } from './company/company/company.component';
import { CreateVacancyComponent } from './vacancy/create-vacancy/create-vacancy.component';
import { VacancyComponent } from './vacancy/vacancy.component';

const routes: Routes = [
  {
    path: 'vacancy',
    component: VacancyComponent,
    children: [
      { path: 'create', component: CreateVacancyComponent },
    ]
  },
  {
    path: 'company',
    component: CompanyComponent,
    children: [
      { path: 'list', component: CompanyListComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
