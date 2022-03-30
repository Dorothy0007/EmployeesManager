using EmployeesManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EmployeesManagerDbContext>();
builder.Services.AddDbContext<EmployeesManagerDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EmployeesManager")));
//builder.Services.AddDbContext<EmployeesManagerWebContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesManager")));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IEmployeesRepository, EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
