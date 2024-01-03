using healthcare_system.Data;
using healthcare_system.Data.Mock;
using healthcare_system.Models;
using healthcare_system.Repository;
using healthcare_system.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<DbSeeder>();


builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<ITermReservationRepository, TermReservationRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddControllersWithViews();
/*builder.Services.AddDefaultIdentity<Doctor>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>(); */


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Cloud")
    ));



builder.Services.AddTransient<PatientMock>();
builder.Services.AddTransient<HospitalMock>();
builder.Services.AddTransient<DepartmentMock>();
builder.Services.AddTransient<DoctorMock>();
builder.Services.AddTransient<MedicineMock>();
builder.Services.AddTransient<TermReservationMock>();
builder.Services.AddTransient<ApplicationUserMock>();
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
    var termReservationContext = serviceProvider.GetRequiredService<TermReservationMock>();
    var applicationUserContext = serviceProvider.GetRequiredService<ApplicationUserMock>();

    var seeder = new DbSeeder(context, patientContext, hospitalContext, departmentContext, doctorContext, medicineContext, termReservationContext, applicationUserContext);
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
app.UseAuthentication();
app.MapRazorPages();
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
