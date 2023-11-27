using healthcare_system.Data;
using healthcare_system.Data.Mock;
using healthcare_system.Repository;
using healthcare_system.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<DbSeeder>();


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<PatientMock>();
builder.Services.AddTransient<HospitalMock>();
builder.Services.AddTransient<DepartmentMock>();
builder.Services.AddTransient<DoctorMock>();
builder.Services.AddTransient<MedicineMock>();
builder.Services.AddTransient<PasswordHasher>();
builder.Services.AddTransient<AgeCalculator>();
builder.Services.AddTransient<UuidGenerator>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Hello blyat");
    var serviceProvider = scope.ServiceProvider;
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    var patientContext = serviceProvider.GetRequiredService<PatientMock>();
    var hospitalContext = serviceProvider.GetRequiredService<HospitalMock>();
    var departmentContext = serviceProvider.GetRequiredService<DepartmentMock>();
    var doctorContext = serviceProvider.GetRequiredService<DoctorMock>();
    var medicineContext = serviceProvider.GetRequiredService<MedicineMock>();

    var seeder = new DbSeeder(context, patientContext, hospitalContext, departmentContext, doctorContext, medicineContext);
    seeder.SeedData();

}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "patient",
    pattern: "{controller=Patient}/{action=Index}"
);

/*app.MapControllerRoute(
    name: "register",
    pattern: "{controller=RegisterUserController}/{action=Register}"
); */


app.Run();
