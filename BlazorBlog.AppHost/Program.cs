using Projects;

var builder = DistributedApplication.CreateBuilder(args);


var postgres = builder.AddPostgres("postgres")
                      .WithContainerName("blogdb_postgres")
                      .WithPgAdmin()
                      .WithPgWeb()
                      .WithLifetime(ContainerLifetime.Persistent);


var dbName = "blogdb";
var creationScript = $$"""
    -- Create the database
    CREATE DATABASE {{dbName}};

    """;

var blogDb = postgres.AddDatabase(dbName)
                     .WithCreationScript(creationScript);

var migrations = builder.AddProject<Projects.BlazorBlog_MigrationService>("Migrations")
                        .WithReference(blogDb)
                        .WithReference(postgres)
                        .WaitFor(postgres);

var webUi = builder.AddProject<Projects.BlazorBlog_UI>("BlazorUI")
                   .WithReference(blogDb);

builder.Build().Run();
