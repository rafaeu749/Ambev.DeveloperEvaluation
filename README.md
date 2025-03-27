# Nttdata Developer Evaluation
## Configuration & Execution
All the app settings are configured to point to a Docker network with fixed ports for each container (API, DB, etc.)

Open in Visual Studio or run the following command

`docker compose up`

It is necessary to run the initial migration of database:

`dotnet ef database update --startup-project src/Ambev.DeveloperEvaluation.WebApi --project src/Ambev.DeveloperEvaluation.ORM`


