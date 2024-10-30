using Microsoft.EntityFrameworkCore;
using OutboxPatternWithCdc.Apis;
using OutboxPatternWithCdc.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>((provider, optionsBuilder) =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Url"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddOutboxApi();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();