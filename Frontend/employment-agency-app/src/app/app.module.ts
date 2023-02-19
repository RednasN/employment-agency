import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { environment } from 'src/environment';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuComponent } from './menu/menu.component';
import { CreateVacancyComponent } from './vacancy/create-vacancy/create-vacancy.component';
import { VacancyComponent } from './vacancy/vacancy.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormInputComponent } from './common/components/form-input/form-input.component';
import { CompanyComponent } from './company/company/company.component';
import { CompanyListComponent } from './company/company/company-list/company-list.component';
import { OverviewFilterPipe } from './common/pipes/overview-filter.pipe';
import { ApiModule, Configuration, ConfigurationParameters } from './common/api';

export function apiConfigFactory(): Configuration {
  const params: ConfigurationParameters = {
    basePath: environment.basePath,
  };
  return new Configuration(params);
}

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CreateVacancyComponent,
    VacancyComponent,
    FormInputComponent,
    CompanyComponent,
    CompanyListComponent,
    OverviewFilterPipe
  ],
  imports: [
    ApiModule.forRoot(apiConfigFactory),
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
