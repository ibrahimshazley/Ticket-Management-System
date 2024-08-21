using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TicketManagement.Core.Abstraction.IRepositories;
using TicketManagement.Core.Abstraction.IServices;
using TicketManagement.Core.Mapping;
using TicketManagement.Infrastrucure.DBContext;
using TicketManagement.Infrastrucure.Repositories;
using TicketManagement.Infrastrucure.Services;
using TicketManagement.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




//builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
////builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationServices();

builder.Services.AddScoped(typeof(ITicketService), typeof(TicketService));
builder.Services.AddScoped(typeof(ITicketRepository), typeof(TicketRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
