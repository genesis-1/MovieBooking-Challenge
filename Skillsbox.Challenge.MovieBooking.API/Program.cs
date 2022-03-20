using Hangfire;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Skillsbox.Challenge.MovieBooking.API;
using Skillsbox.Challenge.MovieBooking.API.Config;
using Skillsbox.Challenge.MovieBooking.API.Infrastructure.Service;
using Skillsbox.Challenge.MovieBooking.API.Service;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

using Skillsbox.Challenge.MovieBooking.Infrastructure;
using Skillsbox.Challenge.MovieBooking.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.SetupControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.SetupMediatr();
builder.Services.SetupInMemoryCaching(builder.Configuration);
builder.Services.SetupSqliteDb(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.SetupNSwag();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddCors(o => o.AddPolicy("Skillsbox", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

//Api calls




// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHangfireDashboard("/jobs");
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});

app.UseRouting();

app.UseHttpsRedirection();
app.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapControllers();
});


app.Run();
