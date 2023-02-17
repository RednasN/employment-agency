﻿using AutoMapper;
using Jex.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jex.Application.Vacancy.Commands.UpdateVacancy
{
    public record UpdateVacancyCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; init; }
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

            if(vacancy != null)
            {
                vacancy.Title = request.Title;
                vacancy.Description = request.Description;
                await _vacancyRepository.Update(vacancy);
            }
        }
    }
}
