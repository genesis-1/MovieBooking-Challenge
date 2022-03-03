using Microsoft.EntityFrameworkCore;
using Skillsbox.Challenge.MovieBooking.API;
using Skillsbox.Challenge.MovieBooking.Business.Repository;
using Skillsbox.Challenge.MovieBooking.Data;
using Skillsbox.Challenge.MovieBooking.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddCors(o => o.AddPolicy("Skillsbox", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

//Api calls

app.MapGet("/categories", async (ICategoryService _categoryService) => await _categoryService.GetAll());

app.MapGet("/categories/{id}", async (int id, ICategoryService _categoryService) => await _categoryService.Get(id));

app.MapPost("/categories", async (CategoryDTO categoryDTO , ICategoryService _categoryService) => await _categoryService.Create(categoryDTO));

app.MapPut("/categories", async (CategoryDTO categoryDTO , ICategoryService _categoryService) => await _categoryService.Update(categoryDTO));

app.MapDelete("/categories/{id}", async (int id , ICategoryService _categoryService) => await _categoryService.Delete(id));






// Configure the HTTP request pipeline.
app.UseSwagger();
if (!app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillsBox Movie Challenge Api v1");
        c.RoutePrefix = String.Empty;
    });
}
else
{
    app.UseSwaggerUI(c => {
    });
}

app.UseHttpsRedirection();
app.UseCors("Skillsbox");


app.Run();
