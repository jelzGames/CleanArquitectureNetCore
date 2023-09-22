using DatabaseMIgrations.Interfaces;
using DatabaseMIgrations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductUnitAplication.Interfaces;
using ProductUnitAplication.Services;
using ProductUnitDomain.Interfaces;
using ProductUnitDomain.Services;
using ProductUnitInfra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductUnitAppServices, ProductUnitAppServices>();
builder.Services.AddScoped<IProductUnitDSServices, ProductUnitDSServices>();
builder.Services.AddScoped<IProductUnitRepository, ProductUnitRepository>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean Architecture", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean architecture");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ParamIndex}/{id?}");

app.MapControllers();

app.Run();
