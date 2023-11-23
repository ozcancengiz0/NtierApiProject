using DomainModel.Extensions;
using DomainService.Extensions;
using Dto.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.LoadDomainModelExtension(builder.Configuration);
builder.Services.LoadDomainServiceExtension();
builder.Services.LoadDtoExtension();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors",
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
