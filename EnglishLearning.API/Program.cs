using EnglishLearning.Application;
using EnglishLearning.Application.Common.Constants;
using EnglishLearning.Application.Common.Messages;
using EnglishLearning.Application.Common.Models;
using EnglishLearning.API.Middleware;
using EnglishLearning.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "https://english-learning-ui.mehpas.workers.dev",
                "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray());

        var response = new ApiErrorResponse
        {
            Success = false,
            Message = CommonMessages.ValidationFailed,
            ErrorCode = GlobalErrorCodes.DogrulamaHatasi,
            Errors = errors
        };

        return new BadRequestObjectResult(response);
    };
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
