# Academy Calendar API
This is the Academy Calendar API built with ASP.NET Core.

## Developer utilities
This section shows some useful información for the developers.

### Entity Framework
- Create first migration: 
    ```
    dotnet ef migrations add InitialCreate -o Data/Migrations
    ```
- Add migration: 
    ```
    dotnet ef migrations add <migration-name>
    ```
- Update database: 
    ```
    dotnet ef database update
    ```
- Update to previous version: 
    ```
    dotnet ef database update <previous-migration-name>
    ```
- Remove migration: 
    ```
    dotnet ef migrations remove
    ```
- Remove database: 
    ```
    dotnet ef database drop
    ```

### Docker
- Build the docker container: 
    ```
    docker build -t <docker-username>/<docker-repository-name> . 
    ```
    \<docker-username> is the one used when signing up to docker <br />
    \<docker-repository-name> could be the app name for example. Must be lowercase (for example, academy-calendar-api) <br />
- Run the docker image:
    ```
    docker run --rm -it -p 8080:80 <docker-project-image>
    ```
    -it allows us to see the logs while running, not necessary <br />
    --rm removes the docker instance when docker stops running <br />
    \<docker-project-image> is represented like: \<docker-username>/\<docker-repository-name>:\<version>, where version could be "latest" <br />
