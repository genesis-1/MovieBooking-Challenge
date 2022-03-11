using Hangfire;
using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.API;
using Skillsbox.Challenge.MovieBooking.API.Config;
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
#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion
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

app.UseRouting();

app.UseHttpsRedirection();
app.UseEndpoints(endpointRouteBuilder =>
{
    endpointRouteBuilder.MapControllers();
});


app.Run();
