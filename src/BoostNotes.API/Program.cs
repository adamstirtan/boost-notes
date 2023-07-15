using Microsoft.EntityFrameworkCore;

using BoostNotes.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BoostNotesDbContext>(options =>
    options.UseSqlite("Data Source=boostnotes.sqlite3"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
