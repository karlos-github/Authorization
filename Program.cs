
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
			builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

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