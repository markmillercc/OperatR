using OperatR;
using System.Reflection;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => { options.CustomSchemaIds(type => Regex.Replace(type.ToString(), "[^a-zA-Z0-9 -]", "")); });

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var app = builder.Build();

var group = app.MapGroup("");

var igroup = group.MapGroup("ig");

group.AddEndpointFilter<ModelStateValidationEndpointFilter>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
