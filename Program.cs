using EMSWebApp.Components;
using EMSWebApp.Data;
using EMSWebApp.Models;
using EMSWebApp.Models.ModelEnums;
using EMSWebApp.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<EventNotificationService>();

QuestPDF.Settings.License = LicenseType.Community;
builder.Services.AddSingleton<TicketPdfService>();

builder.Services.AddHostedService<EventStatusWorker>();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddServerSideBlazor(options =>
{
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(2);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
});

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/login";
    options.LogoutPath = "/Account/logout";
    options.SlidingExpiration = true;
});

builder.Services.AddControllers();

var app = builder.Build();

app.Use(async (context, next) =>
{
    // Tells ngrok to skip the warning page on responses/fetches
    context.Response.Headers.Append("ngrok-skip-browser-warning", "true");
    await next();
});

var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                       ForwardedHeaders.XForwardedHost |
                       ForwardedHeaders.XForwardedProto
};

forwardedHeadersOptions.KnownNetworks.Clear();
forwardedHeadersOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardedHeadersOptions);

//app.UseForwardedHeaders(new ForwardedHeadersOptions
//{
//    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
//                       ForwardedHeaders.XForwardedHost |
//                       ForwardedHeaders.XForwardedProto
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    // Ensure the Admin role exists
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
    }

    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
    }

    // 2. Check if the admin user already exists
    var adminEmail = "admin2@ems.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        var newAdmin = new AppUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "System Administrator",
            EmailConfirmed = true // Bypasses email verification for this seed user
        };

        // 3. Create the admin with a default secure password
        var result = await userManager.CreateAsync(newAdmin, "admin123");

        if (result.Succeeded)
        {
            // 4. Assign the Admin role to this user
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
    }
}

// check if events is over upon start of the system
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    try
    {
        var DbFactory = services.GetRequiredService<IDbContextFactory<AppDbContext>>();
        using var Db = DbFactory.CreateDbContext();

        var now = DateTime.UtcNow;

        await Db.UserEvents
            .Where(e => e.EndDate < now && e.Status != EventStatusEnum.Completed)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(e => e.Status, EventStatusEnum.Completed));
    } catch(Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "Failed to update event status on startup");
    }
}

using (var scope = app.Services.CreateScope())
{
    var Dbfactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var db = Dbfactory.CreateDbContext();

    await db.Database.MigrateAsync();
}

app.Run();
