using AutoMapper;
using Jex.Application.Contracts.Persistence;
using Jex.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancy.Commands.UpdateVacancy
{
    public record UpdateVacancyCommand : IRequest
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Title { get; init; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; init; }
    }

    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand>
    {
        private readonly IVacancyRepository _vacancyRepository;
        public UpdateVacancyCommandHandler(IVacancyRepository VacancyRepository)
        {
            _vacancyRepository = VacancyRepository;
        }

        public async Task Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetById(request.Id);

            if (vacancy == null)
            {
                throw new ContentValidationException(nameof(request.Id), $"Vacancy with id {request.Id} does not exist");
            }

            vacancy.Title = request.Title;
            vacancy.Description = request.Description;
            await _vacancyRepository.Update(vacancy);
        }
    }
}
