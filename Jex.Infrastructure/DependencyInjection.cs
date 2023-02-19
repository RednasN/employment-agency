using Jex.Application.Contracts.Persistence;
using Jex.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddDbContext<JexDbcontext>();
            return services;
        }
    }
}
