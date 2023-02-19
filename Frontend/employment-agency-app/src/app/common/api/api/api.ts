export * from './company.service';
import { CompanyService } from './company.service';
export * from './vacancy.service';
import { VacancyService } from './vacancy.service';
export const APIS = [CompanyService, VacancyService];
