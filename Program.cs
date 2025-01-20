
using AzurePublishingAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace AzurePublishingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.

            // Add services to the container.
            //var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<ItemDBContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigins", policy =>
                {
                    policy.WithOrigins("https://blazorazurepublishing20250113105758.azurewebsites.net/")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowOrigins");       

            app.UseHttpsRedirection();
           

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
