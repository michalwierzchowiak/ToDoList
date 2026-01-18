using System;
using Microsoft.EntityFrameworkCore;
using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(); // SignalR
builder.Services.AddDbContext<DatabaseAppContext>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.MapControllers();
app.MapHub<TodoHub>("/todohub");

app.Run();