# ~NanoStore~ -> Blog

> [!WARNING]
> Este proyecto es de practica! no se debe usar en producción.

- Angular 15
- .NET 8 CORE
- gRPC
- Microservices

## Comandos

### Docker | DB

> [!NOTE] 
> [Documentación del docker con SQL-Server](https://learn.microsoft.com/es-mx/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&tabs=cli&pivots=cs1-bash)

```shell
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

```shell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=NanoShop0920." \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```

```shell
docker exec -t sql1 cat /var/opt/mssql/log/errorlog | grep connection
```

```shell
docker exec -it sql1 "bash"
```

```shell
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "NanoShop0920." -C
```

Deberiamos ver un promt `1>`

```shell
1> CREATE DATABASE NanoShopDB;
2> GO
```

```shell
1> SELECT Name from sys.databases;
2> Go
```

Aqui podemos crear tablas manualmente con: `USE NanoShopDB;` y luego escribimos el SQL.

> [!NOTE] 
> `localhost` == `127.0.0.1`

### Dotnet

Este comando sirve para generar las cosas faltantes de tipos, etc...

```shell
dotnet build
```

Ejecutar el programa

```shell
dotnet run
```

Si estas en `NixOS` puedes instalar el CLI de `entity framework` con el comando

```shell
dotnet tool install --create-manifest-if-needed dotnet-ef
```

Esto creara una carpeta `.config/dotnet-tools.json` con el siguiente contenido

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "dotnet-ef": {
      "version": "9.0.0",
      "commands": ["dotnet-ef"],
      "rollForward": false
    }
  }
}
```

Y ahora si podemos usar el comando:

```shell
dotnet ef migrations add <NOMBRE_MODELO>
```

Quitar una migración

```shell
dotnet ef migrations remove <NOMBRE_MODELO>
```
