# Setup project

### Development environment

I ran this command to create a PostgreSQL with Postgis extension database conveniently.

```shell
docker run -d --name ambev_developer_evaluation_database_dev -e POSTGRES_DB=developer_evaluation -e POSTGRES_USER=developer -e POSTGRES_PASSWORD=ev@luAt10n -p 5432:5432 -v ambev_pg_data:/var/lib/postgresql/data --restart unless-stopped postgis/postgis:13-3.5
```
The commands below must be executed from `src` folder

To create a migration run the command below:

```shell
dotnet ef migrations add CartAndProduct --project ./Ambev.DeveloperEvaluation.ORM --startup-project ./Ambev.DeveloperEvaluation.WebApi
```

Just in case you need to undo the previous migrations run:
```shell
dotnet ef migrations remove --project ./Ambev.DeveloperEvaluation.ORM --startup-project ./Ambev.DeveloperEvaluation.WebApi
```

Finally, to `up` the migrations into database run the command below but recall to configure the `appsettings.json` at `Ambev.DeveloperEvaluation.WebApi`.
```shell
dotnet ef database update --project ./Ambev.DeveloperEvaluation.ORM --startup-project ./Ambev.DeveloperEvaluation.WebApi  
```