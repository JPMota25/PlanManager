using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanManager.Api.Midlewares;
using PlanManager.Aplication;
using PlanManager.Aplication.Interfaces;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Aplication.Services.Profiles;
using PlanManager.Aplication.Services.Utils;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.Repositories;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Domain.Repositories.Utils;
using PlanManager.Infrastructure.Data;
using PlanManager.Infrastructure.Repositories;
using PlanManager.Infrastructure.Repositories.Profiles;
using PlanManager.Infrastructure.Repositories.Utils;

var builder = WebApplication.CreateBuilder(args);

// ConfigureAuthentication(builder);
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

void ConfigureMvc(WebApplicationBuilder builderMvc) {
	builderMvc.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; }).AddJsonOptions(x => {
		x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
	});
}

void ConfigureServices(WebApplicationBuilder builderServices) {
	builderServices.Services.AddCors(options => {
		options.AddPolicy("MyCorsPolicy", // Nome da política
			policy => {
				policy.WithOrigins("http://localhost:5173"); // Origens permitidas
				policy.WithMethods("GET", "POST", "PUT", "DELETE"); // Métodos HTTP permitidos
				policy.WithHeaders("Content-Type", "Authorization"); // Headers permitidos
				// policy.AllowAnyOrigin(); // Permite todas as origens (não recomendado para produção)
				// policy.AllowAnyMethod(); // Permite todos os métodos (não recomendado para produção)
				// policy.AllowAnyHeader(); // Permite todos os headers (não recomendado para produção)
				policy.AllowCredentials(); // Permite credenciais (cookies, autenticação)
			});
	});
	builderServices.Services.AddEndpointsApiExplorer();
	builderServices.Services.AddSwaggerGen();

	builderServices.Services.AddDbContext<PlanManagerDbContext>(options => options.UseSqlServer(
		builderServices.Configuration.GetConnectionString("DefaultConnection"), sqlOptions => {
			sqlOptions.MigrationsAssembly("PlanManager.Infrastructure");
			sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
		}));

	builderServices.Services.AddHttpContextAccessor();

	builderServices.Services.AddScoped<ILogActivityService, LogActivityService>();
	builderServices.Services.AddScoped<IPasswordHashService, PasswordHashService>();
	builderServices.Services.AddScoped<ITokenService, TokenService>();
	builderServices.Services.AddScoped<IPersonService, PersonService>();
	builderServices.Services.AddScoped<IUserService, UserService>();
	builderServices.Services.AddScoped<ICustomerService, CustomerService>();

	builderServices.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
	builderServices.Services.AddScoped<IPersonRepository, PersonRepository>();
	builderServices.Services.AddScoped<IUserRepository, UserRepository>();
	builderServices.Services.AddScoped<ICustomerRepository, CustomerRepository>();
	builderServices.Services.AddScoped<ILogActivityRepository, LogActivityRepository>();
}

void ConfigureAuthentication(WebApplicationBuilder builderAuthentication) {
	var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
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