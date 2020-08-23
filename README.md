# About

Building a CRUD system for Command with MSSQL as RDBM, as a simple .Net Core 3.1 WebAPI which covers all type of endpoints such as (GET, POST, PUT, PATCH, DELETE) using plenty of techs like :
- IoC (using the default for registration of Db, Repositories ....)
- Repository design pattern
- Implementing swagger OpenAPI for WebAPI documentation.
- Integaration of docker files (dockerfile, docker-compose, docker-combose.debug, .dockerignore)
- Using DTOs(Data Transfer Object) pattern

# Endpoints planing

| URI | Verb | Operation | Description | Success | Failure |
| --- | ---- | --------- | ----------- | ------- | ------- |
| `/api/commands` | GET | READ | Read all resources | 200 OK | 400 Bad Request / 404 Not Found |
| `/api/commands/{id}` | GET | READ | Read a single resource | 200 OK | 400 Bad Request / 404 Not Found |
| `/api/commands` | POST | CREATE | Create a new resource | 201 OK | 400 Bad Request / 405 Not Allowed |
| `/api/commands/{id}` | PUT | UPDATE | Update an entire resource | 204 No Content | ... |
| `/api/commands/{id}` | PATCH | UPDATE | Update partial resource | 204 No Content | ... |
| `/api/commands/{id}` | DELETE | DELETE | Delete a single resource | 200 OK / 204 No Content| ... |
| `/api/commands` | DELETE | DELETE | Delete all resources | 200 OK / 204 No Content| ... |

# How to run the project

Basically, these are the simple steps for how to run the project locally:

## Requirements 

1. A RDBM(MSSQL, MYSQL, SqlLite) should be preconfigured yet locally or has a **ConnectionString** of a hosted RDBM somewhere else, *Note: configure which RDBM would you use for the project on startup.cs file and also replace the default ConnectionString on Json file*.
2. .Net Core 3.1 SDK.
3. Entity Framework Core.
4. Code Editor (VS Code is recommended) [Download VS Code](https://code.visualstudio.com/Download).
5. Postman to establish the test for project endpoints (else use browser is mostly enough)

After making sure the your machine respond correctly to the requirements above, next steps :
1. Use git source control to clone the project locally
2. Use Terminal to build the entire project, typing the follwing command:
    ```bash
    .../CommanderAPI> dotnet build
    ```
3. Run the Entity framework core immigration:
   ```bash
    .../CommanderAPI> dotnet ef database update
    ```
4. Run the project:
    ```bash
    .../CommanderAPI> dotnet run
    ```
   the project will run on 2 ports, which are (localhost:5000, localhost:5001), the first which normal HTTP and Secode with HTTPS.
5. Use postman to test exemple :
    ```bash
    http://localhost:5000/api/commands
    ```
    to get list of commands
