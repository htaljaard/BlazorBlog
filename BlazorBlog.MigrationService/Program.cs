using BlazorBlog.MigrationService;
using BlazorBlog.UI.Data;

var builder = Host.CreateApplicationBuilder(args);


builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
.WithTracing(tracing => tracing.AddSource("BlazorBlog.MigrationService"));

builder.AddSqlServerDbContext<BlogDBContext>("blogdb");

var host = builder.Build();
host.Run();
