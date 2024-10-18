
using QuanLyVatPhamAPI.Models.Item;
using QuanLyVatPhamAPI.Repository.ItemRepository;
using QuanLyVatPhamAPI.Repository;
using QuanLyVatPhamAPI.Service;
using Microsoft.EntityFrameworkCore;

namespace QuanLyVatPhamAPI
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

            //Register the database context pool
            builder.Services
                .AddDbContextPool<ItemContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ItemManagement")));

            // Đăng ký repository cơ sở
            builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Đăng ký repository cụ thể
            builder.Services.AddScoped<IRepository<Item>, ItemRepository>();

            // Đăng ký service cơ sở
            builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));

            // Đăng ký service cụ thể
            builder.Services.AddScoped<IService<Item>, ItemService>();

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
