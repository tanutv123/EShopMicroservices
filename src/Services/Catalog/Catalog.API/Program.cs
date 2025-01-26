var builder = WebApplication.CreateBuilder(args);

//Add DI Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure HTTP pipeline
app.MapCarter();


app.Run();
