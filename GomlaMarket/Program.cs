using GomlaMarket.Controllers;
using GomlaMarket.db;
using GomlaMarketApi.web.Services.Contracts;
using GomlaMarketApi.web.Services.Implement;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dataContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddTransient<IitemsService, ItemsService>();
builder.Services.AddTransient<IuploadSalesData, UploadSalesDataService>();
builder.Services.AddTransient<IuploadPurchaseDataService, UploadPurchaseDataService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
