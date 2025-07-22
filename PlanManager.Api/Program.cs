using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanManager.Api.Middlewares;
using PlanManager.Aplication;
using PlanManager.Aplication.Commands.CreateCustomer;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Aplication.Mappings;
using PlanManager.Aplication.Services.Profiles;
using PlanManager.Aplication.Services.Utils;
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

	builderServices.Services.AddMediatR(cfg => {
		cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzg0Njc4NDAwIiwiaWF0IjoiMTc1MzE5MTk3NSIsImFjY291bnRfaWQiOiIwMTk4MzI2MWNhOGQ3N2I3OTI0YWYzMjJkZGMyMWRiNCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazBzNjUybjBrNDQyNTFxZnlkbXBiNWZ2Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.sNIU0A6D6cLhTY_IBCfvdPCqafMuILYiHBetepMPByxz1TzRIQKqY5D9zaaN6lHZA5H9jD4TIDFwacycqVZdK1AxZi8Iyr3ie6JvPSSiKD5DIFkFWMvk4DC13Kdac55GY_KQE_ley7fOoJy9Pp9cppzqAIhjM3FnvOw-5DNR0Q_ikmhRG2XzQizY_EIuwhRt5NqQj-_HpEYY28HvEe7_ESduu12hOGZOcQZNh2CdK4CkStLwgrcRapZDHUhiX3IC0K9nDOOJ6r6QectaeDUiWKmxkTXkjlj2q-7fDtKM0yztwJaMjypQRQKP8Ws0rDTvbco1ziTSDB6tQY70YBcuyg";
		cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateCustomerHandler).Assembly);
});

	builderServices.Services.AddLogging();
	builderServices.Services.AddAutoMapper(typeof(CustomerProfile));

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