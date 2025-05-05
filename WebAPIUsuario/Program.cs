using Microsoft.EntityFrameworkCore;
using WebAPIUsuario.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbUsuarioContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionBD"))
);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", (HttpContext context) => { 

//    context.Response.Redirect("/swagger/index.html",permanent:false);
//});

app.Use(async(context, next) => {
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
