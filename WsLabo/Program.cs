using Microsoft.EntityFrameworkCore;
using WsLabo.Context;
using Microsoft.AspNetCore.Cors;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(5001));
var service = builder.Services.AddControllers();
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
    option.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost",
                                                      "http://127.0.0.1");
                              }));
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<LaboDbContext>(x=> x.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
