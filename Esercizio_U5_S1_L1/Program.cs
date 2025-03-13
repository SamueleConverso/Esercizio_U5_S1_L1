using Esercizio_U5_S1_L1.Data;
using Esercizio_U5_S1_L1.Services;
using FluentEmail.MailKitSmtp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Esercizio_U5_S1_L1_EfCore>(options =>
    options.UseSqlServer(connectionstring)
);

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<GenereService>();
builder.Services.AddScoped<PrestitoService>();
//

builder.Services.AddFluentEmail(builder.Configuration.GetSection("MailSettings").GetValue<string>("FromDefault"))
    .AddRazorRenderer()
    .AddMailKitSender(new SmtpClientOptions() {
        Server = builder.Configuration.GetSection("MailSettings").GetValue<string>("Server"),
        Port = builder.Configuration.GetSection("MailSettings").GetValue<int>("Port"),
        User = builder.Configuration.GetSection("MailSettings").GetValue<string>("Username"),
        Password = builder.Configuration.GetSection("MailSettings").GetValue<string>("Password"),
        UseSsl = builder.Configuration.GetSection("MailSettings").GetValue<bool>("UseSsl"),
        RequiresAuthentication = builder.Configuration.GetSection("MailSettings").GetValue<bool>("RequiresAuthentication"),
    });
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
