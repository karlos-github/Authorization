
using AuthorizationStudio9.Model;
using AuthorizationStudio9.Repository;
using AuthorizationStudio9.Service;

namespace AuthorizationStudio9
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IRoleRepository, RoleRepository>();
			builder.Services.AddScoped<IRoleService, RoleService>();
			builder.Services.AddScoped<IActionRepository, ActionRepository>();
			builder.Services.AddScoped<IActionService, ActionService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
			builder.Services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
			builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
			builder.Services.AddScoped<IUserRoleService, UserRoleService>();
			builder.Services.AddScoped<IAuthorizationActionService, AuthorizationActionService>();
			builder.Services.AddScoped<IAuthorizationActionRepository, AuthorizationActionRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			//if (app.Environment.IsDevelopment())
			//{
				app.UseSwagger();
				app.UseSwaggerUI();
			//}

			//app.UseHttpsRedirection();
			//app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}