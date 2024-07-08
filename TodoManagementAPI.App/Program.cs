using FluentValidation;
using FluentValidation.AspNetCore;
using TodoManagementAPI.App.MigrationExtension;
using TodoManagementAPI.Application.Validators;
using TodoManagementAPI.Infrastructure.ServiceContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService(builder.Configuration);

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdatePasswordValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProfileValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTodoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTodoPriorityValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTodoStatusValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
