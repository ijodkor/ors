# Open Resource Server

## Installation and running

1. Setup and configuration
    ```bash
    cp appsettings.dev.json appsettings.json
    ```
2. Run migrations:
    ```bash
    dotnet ef database update
    ```

## Deploy

1. Publish the application:

    ```bash
    dotnet publish -c Release -o /path/to/publish/directory
    ```

2. Create a service file for this application or just copy to systemd:

    ```bash 
    sudo nano /etc/systemd/system/ors-server.service
    ```

3. Start the service:
    ```bash
   sudo systemctl start ors-server
    ```
4. Enable the service to start on boot (after success):
    ```bash
   sudo systemctl enable ors-server
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
- [Custom status code response](https://www.telerik.com/blogs/return-json-result-custom-status-code-aspnet-core)
- [Custom Response](https://medium.com/@nibasnazeem/handling-non-success-status-codes-with-custom-responses-in-asp-net-core-api-3b6f12700a2)

### Issues

- [Unable to locate package dotnet-sdk-8.0](https://stackoverflow.com/questions/77498786/unable-to-locate-package-dotnet-sdk-8-0)
- [Cors Allow](https://stackoverflow.com/questions/73405732/enable-cors-for-any-port-on-localhost-as-well-as-for-the-list-of-specific-domain)
