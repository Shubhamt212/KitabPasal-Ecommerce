using KitabPasall.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<KitabPasall.Models.User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
    
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
SeedAdminUserAndRole(app.Services);
//app.Run();

static void SeedAdminUserAndRole(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<KitabPasall.Models.User>>();
        var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        context.Database.Migrate();

        if (!RoleManager.RoleExistsAsync("Admin").Result)
        {
            var Role = new IdentityRole("Admin");
            RoleManager.CreateAsync(Role).Wait();
        }
        var adminUser = new KitabPasall.Models.User { UserName = "admin11@example.com", Email = "admin11@example.com" };
        if (UserManager.FindByEmailAsync("admin11@example.com").Result == null)
        {
            var result = UserManager.CreateAsync(adminUser, "Admin@123").Result;
            if (result.Succeeded)
            {
                adminUser.EmailConfirmed = true;
                UserManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
