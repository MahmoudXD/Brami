using Basket.Core.Helper;
using Basket.EntityFramework;
using Basket.Core.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Basket.Core;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
var configuration = builder.Configuration;


// Add services to the container.
service.Configure<JWT>(configuration.GetSection("JWT"));
service.AddIdentity<ApplicationUser, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>();

service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
																			b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
//service.AddScoped<Basket.Core.Interfaces.Authentication.IAuthenticationService, Basket.EntityFramework.Repository.AuthenticationService>();
//service.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
service.AddTransient<IUnitOfWork, UnitOfWork>();

service.AddCors();

#region JWT config
service.AddAuthentication(options => {
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = false;
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidIssuer = configuration["Jwt:Issuer"],
		ValidAudience = configuration["Jwt:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
	};
	options.Events = new JwtBearerEvents()
	{
		OnAuthenticationFailed = c =>
		{
			c.NoResult();
			c.Response.StatusCode = 500;
			c.Response.ContentType = "text/plain";
			return c.Response.WriteAsync(c.Exception.ToString());
		},
		OnChallenge = context =>
		{
			context.HandleResponse();
			context.Response.StatusCode = 401;
			context.Response.ContentType = "application/json";
			var result = JsonConvert.SerializeObject("401 Not authorized");
			return context.Response.WriteAsync(result);
		},
		OnForbidden = context =>
		{
			context.Response.StatusCode = 403;
			context.Response.ContentType = "application/json";
			var result = JsonConvert.SerializeObject("403 Not authorized");
			return context.Response.WriteAsync(result);
		},
	};
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v1",
		Title = "Basket",
		Description = "Besket Ecomerce App",
		Contact = new Microsoft.OpenApi.Models.OpenApiContact
		{
			Name = "Mahmoud",
			Email = "Mahmoud@group-i.com"
		}
	});
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
