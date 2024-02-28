using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.Concrete;
using Mobilya.DataAccess.Abstract;
using Mobilya.DataAccess.Concrete.EntityFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer("server=DESKTOP-NOPPPVL\\SQLEXPRESS; database=MobilyaApiDb; integrated security=true; TrustServerCertificate = True;");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<Context>();


builder.Services.AddScoped<IUserDal,EfUserDal>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IRoleDal,EfRoleDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();

builder.Services.AddScoped<IUserRoleDal,EfUserRoleDal>();
builder.Services.AddScoped<IUserRoleService, UserRoleManager>();


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
