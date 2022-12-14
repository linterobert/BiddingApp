using BiddingApp.API.Background;
using BiddingApp.Aplication;
using BiddingApp.Aplication.Abstract;
using BiddingApp.Aplication.Commands;
using BiddingApp.Infrastructure;
using BiddingApp.Infrastructure.Data;
using BiddingApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
// Add services to the container.
builder.Services.AddHostedService<BackgroundNotification>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BiddingAppContext>(option => option.UseSqlServer(@"Data Source=(localdb)\local;Initial Catalog=BiddingApp.Database;Integrated Security=True"));
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
builder.Services.AddScoped<ICompanyProfileRepository, CompanyProfileRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IClientNotificationRepository, ClientNotificationRepository>();
builder.Services.AddScoped<ICompanyNotificationRepository, CompanyNotificationRepository>();
builder.Services.AddMediatR(typeof(CreateClientProfileCommand));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
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
