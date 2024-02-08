using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//habilitar cors
builder.Services.AddCors(options=>{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        //.AllowHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//ActiveDesignerEventArgs politeca
app.UseCors("Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
