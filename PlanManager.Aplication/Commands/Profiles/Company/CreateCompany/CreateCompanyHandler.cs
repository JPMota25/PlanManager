using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.Profiles.Company;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.Profiles.Company.CreateCompany
{
    public class CreateCompanyHandler : Notifiable<Notification>, IRequestHandler<CreateCompanyCommand, ResultDto<ResponseCompanyCreated>>
    {
        private readonly ICompanyService _companyService;
        private readonly ILogActivityService _logActivityService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonService _personService;

        public CreateCompanyHandler(ICompanyService companyService, ILogActivityService logActivityService, IUnitOfWork unitOfWork, IPersonService personService)
        {
            _companyService = companyService;
            _logActivityService = logActivityService;
            _unitOfWork = unitOfWork;
            _personService = personService;
        }

        public async Task<ResultDto<ResponseCompanyCreated>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Person person = request.Person;
            if (!person.IsValid)
                return ResultDto<ResponseCompanyCreated>.Fail(new Notification("Person.Invalid", "Person used to create company is invalid"));

            var company = new Domain.Entities.Profiles.Company(person.Id);

            await _personService.AddPerson(person);
            await _companyService.AddCompany(company);
            await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateCompany, company.Id,
                "Company Created Successfully.");
            await _unitOfWork.CommitAsync();
            return ResultDto<ResponseCompanyCreated>.Ok(new ResponseCompanyCreated());
        }
    }
}
