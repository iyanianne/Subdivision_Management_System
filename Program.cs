var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();


app.MapControllerRoute(
    name: "homeowner",
    pattern: "Homeowner/{action=Login}/{id?}",
    defaults: new { controller = "Homeowner", action = "Login" });

app.MapControllerRoute(
    name: "staff",
    pattern: "Staff/{action=Login}/{id?}",
    defaults: new { controller = "Staff", action = "Login" });

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{action=Login}/{id?}",
    defaults: new { controller = "Admin", action = "Login" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Homeowner}/{action=Dashboard}/{id?}");

app.Run();
