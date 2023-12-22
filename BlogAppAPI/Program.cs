using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Implementation;
using BlogApp.DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBrandRepository,BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(CreateBrandDTOValidation).Assembly);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

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
