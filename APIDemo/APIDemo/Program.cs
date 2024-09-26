using APIDemo.Infrastructure.Data;
using APIDemo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using APIDemo.Core.Interfaces;
using APIDemo.Middleware;

namespace APIDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(ConnectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductRebository, ProductRebository>();
            builder.Services.AddScoped(typeof(IGenericRebository<>), typeof(GenericRebository<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExcepetionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseStaticFiles();
        
            app.MapControllers();

            //the Following Code Is Written To Generate The Database When The App Started 
            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreContext>();
            var logger = Services.GetRequiredService<ILogger<Program>>();
            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "The error Occured During Migration");
            }

            app.Run();
        }
    }
}
