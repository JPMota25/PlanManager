using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.DTOs.Response.PlanManager.License;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.License.VerifyLicenseAuthencity
{
    public class GenerateLicenseHandler : Notifiable<Notification>, IRequestHandler<GenerateLicenseCommand, ResultDto<LicenseAuthencityResult>>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogActivityService _logActivityService;
        private readonly ISignService _signService;
        private readonly IPlanService _planService;
        private readonly ILicenseService _licenseService;
        private readonly IUnitOfWork _unitOfWork;

        public GenerateLicenseHandler(ICustomerService customerService, ILogActivityService logActivityService, ISignService signService, IPlanService planService, ILicenseService licenseService, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _logActivityService = logActivityService;
            _signService = signService;
            _planService = planService;
            _licenseService = licenseService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDto<LicenseAuthencityResult>> Handle(GenerateLicenseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid)
                return ResultDto<LicenseAuthencityResult>.Fail(new Notification("LicenseAuthencity", "LicenseAuthencity request failed"));

            //Verificar existencia do cliente e validade de informações juntamente com assinatura ligada a licença a ser validada

            var customer = await _customerService.GetCustomerByIdentification(request.CustomerIdentification);
            if (customer == null)
                return ResultDto<LicenseAuthencityResult>.Fail( new Notification("Customer.Validation", "Customer not exists or identification is invalid"));

            await _signService.VerifyLicensesToUpdateSignStatus(request.SignIdentification);
             
            //trazer as permissões que o plano possui
            IList<Domain.Entities.PlanManager.PlanPermission?> permissions = await _signService.GetPlanPermissionBySignIdentification(request.SignIdentification);

            //Gerar Jwt utilizando tokenSecret do cliente como secret key do jwt, dentro do jwt deve ter: permissoes do plano, plano referido com data final de validade
            var license = await _licenseService.GenerateJwt(customer, permissions, request.SignIdentification);

            await _unitOfWork.CommitAsync();

            return ResultDto<LicenseAuthencityResult>.Ok(new LicenseAuthencityResult(DateTime.Now, license));
        }
    }
}
