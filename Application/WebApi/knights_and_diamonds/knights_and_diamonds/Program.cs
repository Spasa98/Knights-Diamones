using DAL.DataContext;
using DAL.Repositories;
using DAL.Repositories.Contracts;
using BLL.Services.Contracts;
using BLL.Services;
using SignalR.HubConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.Models;
using SignalR.GameHub;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using DAL.UnitOfWork;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins
                          (
                              "http://localhost:4200",
                              "https://localhost:4200",
                              "http://127.0.0.1:4200",
                              "https://127.0.0.1:4200",
                              "http://localhost:1200",
                              "https://localhost:1200",
                              "http://127.0.0.1:1200",
                              "https://127.0.0.1:1200"
                           )
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddSignalR(options=>
{ 
    options.EnableDetailedErrors = true; 
});

builder.Services.AddControllers();

builder.Services.Configure<FormOptions>(o =>
{
	o.ValueLengthLimit = int.MaxValue;
	o.MultipartBodyLengthLimit = int.MaxValue;
	o.MemoryBufferThreshold = int.MaxValue;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connectig your database
builder.Services.AddDbContext<KnightsAndDiamondsContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Konekcija")));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<ICardService,CardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITurnService, TurnService>();
builder.Services.AddScoped<IEffectService, EffectService>();
builder.Services.AddScoped<IRPSGameService, RPSGameService>();
builder.Services.AddScoped<IConnectionService, ConnectionService>();
builder.Services.AddScoped<IDeckService, DeckService>();






var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
    app.UseRouting();
    app.UseCors(MyAllowSpecificOrigins);
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
     
        endpoints.MapHub<MyHub>("/toastr");

	});
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
	RequestPath = new PathString("/Resources")
});

app.MapControllers();

app.Run();
