using BookMyShowTask.Models;
using BookMyShowTask.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<BookMyShowContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("BookMyShow")));
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<ICinemaHallService, CinemaHallService>();
builder.Services.AddScoped<ICinemaSeatService, CinemaSeatService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddDefaultIdentity<UserDetail>()
    .AddEntityFrameworkStores<BookMyShowContext>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApplicationSettings"));
var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"].ToString());

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:4200",
            ValidAudience = "https://localhost:4200",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
}
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});




var app = builder.Build();

app.UseCors("EnableCORS");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.Run();
