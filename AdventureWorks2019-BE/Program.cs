using AdventureWorks2019BE.Data;
using AdventureWorks2019BE.Repositories.AdventureWorks.PersonArea;
using AdventureWorks2019BE.Repositories.SigeoRepositories;
using AdventureWorks2019BE.Services;
using AdventureWorks2019BE.Services.AdventureWorks.PersonArea;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AdventureWorks2019Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks2019SqlServer")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Services Dependency Injection
builder.Services.AddScoped<UserService>();

#region AdventureWorks
builder.Services.AddScoped<PersonService>();
#endregion

#endregion

#region Repositories Dependency Injection
builder.Services.AddScoped<UserRepository>();

#region AdventureWorks
builder.Services.AddScoped<PersonRepository>();
#endregion

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
