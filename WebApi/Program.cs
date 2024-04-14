using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));


builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

