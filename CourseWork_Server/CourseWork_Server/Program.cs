using CourseWork_Server;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    j => j.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
);
builder.Services.AddSingleton<DBFitnessClubContext>();


builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.AllowTrailingCommas = true;
});

builder.Services.AddSingleton<CourseWork_Server.DBFitnessClubContext>();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();