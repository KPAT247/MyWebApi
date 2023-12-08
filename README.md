# CAPS

## Entity Framework Core
```bash
# instalar las herramientas dotnet-ef
dotnet tool install -g dotnet ef

# actualizar herramientas 
dotnet tool update -g dotnet ef

# crear la migracion inicial (req. compilar)
dotnet ef migrations add InitialCreate 

# construir la base de datos (req. compilar)
dotnet ef database update

# para revertir la migracion, elimina la base y
dotnet ef migrations remove
```
## controllers 
```bash
# crear un controlador 

```
<!-- hola -->
