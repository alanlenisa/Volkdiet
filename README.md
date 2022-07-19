# Volkdiet
Appunti


### Scaffolding EF

Scaffold-Dbcontext "server=xxx;database=northwind;trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir <outdir>

### Migration

 add-migration InitialDbMsSql -Context volkDietMsSqlContext -outputdir <outdir>\Migrations\MsSql\
 add-migration InitialDbPgSql -Context volkDietPgSqlContext -outputdir <outdir>\Migrations\PgSql\

 remove-migration -context volkDietMsSqlContext
 remove-migration -context volkDietPgSqlContext

 update-database  -context volkDietMsSqlContext
 update-database  -context volkDietPgSqlContext


