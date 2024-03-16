using Hackathon.Backend.NETT.Core.Application.CreateVideo;
using Hackathon.Backend.NETT.Core.Application.UploadVideo;
using Hackathon.Backend.NETT.Core.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
