# Open Resource Server

## Installation and running

Setup and configuration

``cp appsettings.dev.json appsettings.json``

## Deploy

1. Publish the application:

    ```bash
    dotnet publish -c Release -o /path/to/publish/directory
    ```

2. Create a service file for this application:

    ```bash 
    sudo nano /etc/systemd/system/myapp.service
    ```

3. Copy content of service which is located in deployment directory
4. Start the service:
    ```bash
   sudo systemctl start
    ```
5. Enable the service to start on boot (after success):
    ```bash
   sudo systemctl enable myapp
    ```

## Working methods

Migration create

``dotnet ef migrations add <Table name> -o database/Migrations``

## References

- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) A framework for building web apps and services with .NET and C#.
- [Swagger](https://swagger.io/) A framework for building web apps and services with .NET and C#.
- [EF Core Tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) Dotnet Entity Framework Core tools reference - .NET Core CLI

### Resources

- [Naming namespace](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces)
- [Name classes](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names)
- [Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

### Links

- [Rest API]( https://medium.com/@jeslurrahman/understand-the-web-rest-api-asp-net-core-web-api-in-c-8236e2bcb0f1)
- [Top Level Statement](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/top-level-statements)
- [Postgres Connection](https://medium.com/@saisiva249/how-to-configure-postgres-database-for-a-net-a2ee38f29372)
- [Map in C#](https://www.c-sharpcorner.com/blogs/dictionary-and-maps-in-c-sharp)
- [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0)
- [Classification of Regions](https://github.com/kenjebaev/regions)