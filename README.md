# AGSR.TestTask

## AGSR.Patients

### Local site setup

Please see [Hosting ASP.NET Core images with Docker Compose over HTTPS](https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-8.0).

If you already have auto-generated cert please run following command:

```dotnet dev-certs https --clean```

Then you can use it:

```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

Copy `template.env` file to `.env` and set variables.

```
- ASPNETCORE_Kestrel__Certificates__Default__Password=<YOUR PASSWORD HERE>
```

Then just use `docker-compose up` and go to the [swagger](https://localhost:5001/swagger/index.html).

## Data tool

-l, --locale    (Default: en_US) Localization of generated data. See https://github.com/bchavez/Bogus

-u, --url       (Default: https://localhost:5001/) Base URL to AGSR.Patient API.

-c, --count     (Default: 100) Number of entities created.

--help          Display this help screen.

--version       Display version information.