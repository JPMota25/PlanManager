using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanManager.Api.Middlewares;
using PlanManager.Aplication;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Aplication.Services.PlanManager;
using PlanManager.Aplication.Services.Profiles;
using PlanManager.Aplication.Services.Utils;
using PlanManager.Domain.Repositories;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Domain.Repositories.Utils;
using PlanManager.Infrastructure.Data;
using PlanManager.Infrastructure.Repositories;
using PlanManager.Infrastructure.Repositories.PlanManager;
using PlanManager.Infrastructure.Repositories.Profiles;
using PlanManager.Infrastructure.Repositories.Utils;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();
LoadConfiguration(app);


app.UseCors("MyCorsPolicy");
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
// CreateSuperUser(app);
app.MapControllers();
app.Run();

return;

void ConfigureMvc(WebApplicationBuilder builderMvc) {
	builderMvc.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; }).AddJsonOptions(x => {
		x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
	});
}

void ConfigureServices(WebApplicationBuilder builderServices) {
	builderServices.Services.AddCors(options => {
		options.AddPolicy("MyCorsPolicy", policy => {
			policy.WithOrigins("http://localhost:5173");
			policy.WithMethods("GET", "POST", "PUT", "DELETE");
			policy.WithHeaders("Content-Type", "Authorization");
			policy.AllowCredentials();
		});
	});
	builderServices.Services.AddEndpointsApiExplorer();
	builderServices.Services.AddSwaggerGen();

	builderServices.Services.AddDbContext<PlanManagerDbContext>(options => options.UseSqlServer(
		builderServices.Configuration.GetConnectionString("DefaultConnection"), sqlOptions => {
			sqlOptions.MigrationsAssembly("PlanManager.Infrastructure");
			sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
		}));

	builderServices.Services.AddMediatR(cfg => {
		cfg.LicenseKey =
			@"eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg0Njc4NDAwIiwiaWF0IjoiMTc1MzE5MTk3NSIsImFjY291bnRfaWQiOiIwMTk4MzI2MWNhOGQ3N2I3OTI0YWYzMjJkZGMyMWRiNCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazBzNjUybjBrNDQyNTFxZnlkbXBiNWZ2Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.sNIU0A6D6cLhTY_IBCfvdPCqafMuILYiHBetepMPByxz1TzRIQKqY5D9zaaN6lHZA5H9jD4TIDFwacycqVZdK1AxZi8Iyr3ie6JvPSSiKD5DIFkFWMvk4DC13Kdac55GY_KQE_ley7fOoJy9Pp9cppzqAIhjM3FnvOw-5DNR0Q_ikmhRG2XzQizY_EIuwhRt5NqQj-_HpEYY28HvEe7_ESduu12hOGZOcQZNh2CdK4CkStLwgrcRapZDHUhiX3IC0K9nDOOJ6r6QectaeDUiWKmxkTXkjlj2q-7fDtKM0yztwJaMjypQRQKP8Ws0rDTvbco1ziTSDB6tQY70YBcuyg";
		cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
	});

	builderServices.Services.AddLogging();

	builderServices.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

	builderServices.Services.AddHttpContextAccessor();

	builderServices.Services.AddScoped<ILogActivityService, LogActivityService>();
	builderServices.Services.AddScoped<IPasswordHashService, PasswordHashService>();
	builderServices.Services.AddScoped<ITokenService, TokenService>();
	builderServices.Services.AddScoped<IPersonService, PersonService>();
	builderServices.Services.AddScoped<IUserService, UserService>();
	builderServices.Services.AddScoped<ICustomerService, CustomerService>();
	builderServices.Services.AddScoped<IPlanPermissionService, PlanPermissionService>();
	builderServices.Services.AddScoped<IPlanService, PlanService>();
	builderServices.Services.AddScoped<IPlanPermissionRelationService, PlanPermissionRelationService>();
	builderServices.Services.AddScoped<ISignService, SignService>();
	builderServices.Services.AddScoped<ILicenseService, LicenseService>();
	builderServices.Services.AddScoped<ICompanyService, CompanyService>();

	builderServices.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
	builderServices.Services.AddScoped<IPersonRepository, PersonRepository>();
	builderServices.Services.AddScoped<IUserRepository, UserRepository>();
	builderServices.Services.AddScoped<ICustomerRepository, CustomerRepository>();
	builderServices.Services.AddScoped<ILogActivityRepository, LogActivityRepository>();
	builderServices.Services.AddScoped<IPlanPermissionRepository, PlanPermissionRepository>();
	builderServices.Services.AddScoped<IPlanRepository, PlanRepository>();
	builderServices.Services.AddScoped<IPlanPermissionRelationRepository, PlanPermissionRelationRepository>();
	builderServices.Services.AddScoped<ISignRepository, SignRepository>();
	builderServices.Services.AddScoped<ILicenseRepository, LicenseRepository>();
	builderServices.Services.AddScoped<ICompanyRepository, CompanyRepository>();
	builderServices.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}

void ConfigureAuthentication(WebApplicationBuilder builderAuthentication) {
	var jwtKey = builderAuthentication.Configuration.GetValue<string>("JwtKey");
	var key = Encoding.ASCII.GetBytes(jwtKey!);
	builderAuthentication.Services.AddAuthentication(x => {
		x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	}).AddJwtBearer(x => {
		x.TokenValidationParameters = new TokenValidationParameters {
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
}

void LoadConfiguration(WebApplication appConfig) {
	Configuration.JwtKey = appConfig.Configuration.GetValue<string>("JwtKey")!;
}