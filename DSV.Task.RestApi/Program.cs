using DSV.Task.RestApi.Domain.Entities;
using DSV.Task.RestApi.Repositories;
using DSV.Task.RestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepository<Person>, PersonRepository>();
builder.Services.AddSingleton<IRepository<Planet>, PlanetRepository>();
builder.Services.AddSingleton<IRepository<Starship>, StarshipRepository>();
builder.Services.AddSingleton<ApiService>();
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    //used for the Angular App which will use the 4200 port
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
