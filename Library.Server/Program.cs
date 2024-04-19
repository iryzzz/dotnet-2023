using AutoMapper;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            // ��������� EnableSensitiveDataLogging
            optionsBuilder.EnableSensitiveDataLogging();
            
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseMySQL(builder.Configuration["ConnectionString"])
            );

            var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
