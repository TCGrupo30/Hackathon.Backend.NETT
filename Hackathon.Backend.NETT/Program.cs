using Hackathon.Backend.NETT.Core.Application.CreateVideo;
using Hackathon.Backend.NETT.Core.Application.GetVideo;
using Hackathon.Backend.NETT.Core.Application.UploadVideo;
using Hackathon.Backend.NETT.Core.Infra;
using Hackathon.Backend.NETT.Core.Infra.Repositories;
using Hackathon.Backend.NETT.Core.Infra.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<HackathonDbContext>();

builder.Services.AddScoped<IHackathonRepository, HackathonRepository>();

builder.Services.AddScoped<ICreateVideoCommand, CreateVideoCommand>();
builder.Services.AddScoped<IUploadVideoCommand, UploadVideoCommand>();
builder.Services.AddScoped<IGetVideoQuery, GetVideoQuery>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<ICreateVideoCommand, CreateVideoCommand>();
builder.Services.AddScoped<IUploadVideoCommand, UploadVideoCommand>();
builder.Services.AddDbContext<HackathonDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
