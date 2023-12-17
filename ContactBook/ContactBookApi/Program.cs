using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.EFCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactTypeValueReporitory, ContactTypeValueReporitory>();

            builder.Services.AddDbContext<ContactBookDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContactBookMsSql"));
            }); 

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}