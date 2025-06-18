using PeliculasAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); //Se agrega el end pont de la API
builder.Services.AddSwaggerGen(); //se especifica que se usara swagger

builder.Services.AddOutputCache( opciones =>
    {
        opciones.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30); // el cache durar� 15 segundos
    });

//builder.Services.AddSingleton<IRepositorio, RepositorioPrueba>();

//builder.Services.AddTransient<ServicioTransient>();  //Tiempo de vida del servicio

//builder.Services.AddScoped<ServicioScoped>();  //Tiempo de vida del servicio

//builder.Services.AddSingleton<ServicioSingleton>();  //Tiempo de vida del servicio

var allowedhost = builder.Configuration.GetValue<string>("accesoHost")!.Split(",");


builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(corsOptions =>
    {
        //Permitir que cualquir lugar nos pueda comunicar, cualquir metodo HTTP se puede usar y cualquier cabecera por HTTP
        //corsOptions.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        corsOptions.WithOrigins(allowedhost).AllowAnyMethod().AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger(); //Uso de Swagger
    app.UseSwaggerUI(); //Uso interfaz de swagger
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();

app.Run();
