# Volkdiet
Software gestione diete .NET

Sviluppato in Visual Studio 2022, framework .NET core 6.
Utilizza database MSSqlServer o Postgress

🧭 Segui la [storia completa](https://www.youtube.com/playlist?list=PLzoe2DR2djDYePswOq71jRrZYwMP8sPNd) su **youtube** ⏳

---

## Installazione

Per eseguire in Visual Studio 2022:
1. Clonare il repository o scaricare lo zip
2. Impostare in **appsettings.json**(cartella *Web*)  il tipo di database: MsSql(SqlServer) o PgSql(Postgress)
3. Configurare anche la stringa di connessione
```
...
"ConnectionStrings": {
    "MsSqlConnection": "Server=??;Database=?;Trusted_Connection=True;MultipleActiveResultSets=true",
    "PgSqlConnection": "Server=??;port=5432;Database=??;User Id=?;Password=?;"
  },
...  
```
3. Installare il database (creazione tabelle e dati di base)
4. Eseguire l'applicativo da VS (F5, esegui, debug...)

## Struttura della soluzione di Visual Studio 🐺

```
VolkDiet
├── README.md                           <-- questo file
├── Web                                 <-- progetto dell'applicazione web (MVC Core)
│   ├── Controllers
│   ├── Views
│   ├── appsettings.json				<-- configurazione applicativo web                         
│   └── Program.cs						<-- punto di avvio dell'applicazione
│   └── Startup.cs						<-- configurazione servizi e app. 
├── VolkDiet.Core						<-- libreria con le funzioni di base, backend
│   ├── Caching                         
│   ├── Dataservices                    <-- services di accesso ai dati
│   ├── dbcontext                       
│   │   ├── VDDbContext					<-- dbcontext base da ereditare
│   │   └── VDEntity                    <-- entity base da ereditare
│   ├── EF								<-- entity framework models 
│   ├── Infrastructure 
│   │   ├── ApplicationBuilderExensions.cs
│   │   ├── TypeFinder.cs				<-- automazioni con reflection
│   │   ├── VDEngine					<-- engine per servizi,dipendenze...
│   ├── Localization					<-- localizzazione effettiva
│   └── Migration						<-- migration di entity framework  
├── VolkDiet.WebCore					<-- libreria con funzioni a supporto di applicazione web
   ├── VDWebVersion.cs                  <-- versione della parte web
   └── Mvc                             
       ├── BaseRazorpage.cs			    <-- pagina razor da ereditare
       └── ResourceDisplayAttribute.cs  <-- attributo per la localizzazione

```

### DONE
[X] Data provider selezionabile
[X] Migration
[X] Memory cache
[X] Localization

### TODO
[ ] Configurazione automatica db all'avvio
[ ] Menù applicazione
[ ] ...molto altro ...
Il progetto sarà successivamente aperto a eventuali collaborazioni.



