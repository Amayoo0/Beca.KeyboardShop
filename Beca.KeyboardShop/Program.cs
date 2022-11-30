using Beca.KeyboardShop.DbContexts;
using Beca.KeyboardShop.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Newtonsoft.Json;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/keyboardShop.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

/* This make sure that Kestrel is launch
 * Config the public repository for files.
 */
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KeyboardShopIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'KeyboardShopIdentityContextConnection' not found.");

// Dependency Injection: Add services to the container.
/* builder.Services.AddScoped    -> To repositories
 * builder.Services.AddTransient -> Same to Singleton, but create one over an over again.
 * builder.Services.AddSingleton -> Create just one singleton when the request comes in
 */
builder.Services.AddScoped<IKeyboardShopRepository, KeyboardShopRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddIdentity<User, IdentityRole>();
//builder.Services.AddAuthentication()
//  .AddCookie()
//  .AddJwtBearer(cfg =>
//  {
//      cfg.TokenValidationParameters = new TokenValidationParameters()
//      {
//          ValidIssuer = builder.Configuration["Tokens:Issuer"],
//          ValidAudience = builder.Configuration["Tokens:Audience"],
//          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
//      };
//  });


//We're using Serilog. Comment this.
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
builder.Host.UseSerilog();

//To receive data in JSON format
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;

}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
})
.AddXmlDataContractSerializerFormatters();

builder.Services.AddControllersWithViews();

// It's important not to add any space bewteen ConnectionStrings and KeyboardShopDbContextConnection
//builder.Services.AddDbContext<KeyboardShopDbContext>(dbContextOptions => 
//    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:KeyboardShopDbContextConnection"])
//);

//Using SQLite is prety simple
builder.Services.AddDbContext<KeyboardShopDbContext>(DbContextOptions =>
    DbContextOptions.UseSqlite("Data Source=KeyboardShop.db")
);

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<KeyboardShopDbContext>();

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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // To see exception in development
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute(); // To understand MVC structure

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
