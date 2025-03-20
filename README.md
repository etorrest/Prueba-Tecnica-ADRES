AdquisicionesADRES

Este repositorio contiene la solución AdquisicionesADRES, desarrollada en .NET 8 con una arquitectura limpia (Clean Architecture). Incluye proyectos para el dominio, la infraestructura y una API, así como un cliente Blazor para la interfaz de usuario.

Requerimientos
Antes de iniciar, verifica que tengas instalado:

.NET 8 SDK

Puedes descargar la versión más reciente desde dotnet.microsoft.com.
Visual Studio 2022 (o superior)

Asegúrate de incluir las cargas de trabajo de ASP.NET y desarrollo web y/o .NET Core cross-platform.
Alternativamente, puedes usar Visual Studio Code u otro editor compatible con .NET.
SQL Server (local o remoto)

Necesitas un servidor SQL (como SQL Server Developer o Express) para crear la base de datos del proyecto.
Git (opcional, pero recomendado)

Descarga e instala Git desde git-scm.com/downloads para clonar este repositorio.

Tecnologías Utilizadas

.NET 8
C#

ASP.NET Core Web API

Blazor

Clean Architecture (proyectos de Domain, Application, Infrastructure, Presentation)

Entity Framework Core (para acceso a datos)

SQL Server (base de datos)

Estructura del Proyecto
La solución sigue una arquitectura limpia, con proyectos separados:

AdquisicionesADRES.sln

├─ AdquisicionesADRES.Domain

│  ├─ Entities

│  ├─ ValueObjects

│  └─ Interfaces

├─ AdquisicionesADRES.Infrastructure

│  ├─ Data

│  ├─ Migrations

│  └─ Repositories

├─ AdquisicionesADRES.API

│  ├─ Controllers

│  ├─ Middlewares

│  └─ appsettings.json

├─ AdquisicionesADRES.Client (Blazor)

│  ├─ Pages

│  ├─ Shared

│  └─ wwwroot



Configuración de la Base de Datos


La aplicación requiere una base de datos denominada, por ejemplo, AdquisicionesADRESDB. Puedes crearla de dos maneras:

Opción A: Script SQL

Localiza el archivo de script SQL (p. ej. CreateDatabase.sql) en la carpeta Scripts o en la raíz del repositorio.

Ábrelo en tu SQL Server Management Studio (SSMS) o herramienta similar.

Modifica el nombre de la base de datos si fuera necesario (por defecto, AdquisicionesADRESDB).

Ejecuta el script para crear la base de datos y las tablas requeridas.

Opción B: Migraciones de Entity Framework

Si la solución utiliza migraciones de Entity Framework y prefieres que EF cree y actualice la base de datos:

1. Asegúrate de que la cadena de conexión (ConnectionStrings:DefaultConnection) en appsettings.json de AdquisicionesADRES.API apunte a tu instancia de SQL Server. Por ejemplo:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=MI_SERVIDOR\\SQLEXPRESS;Database=AdquisicionesADRESDB;Trusted_Connection=True;"
  }
}

2. Abre la Consola del Administrador de Paquetes en Visual Studio (Tools > NuGet Package Manager > Package Manager Console) o usa la terminal con dotnet:

cd AdquisicionesADRES.Infrastructure

dotnet ef database update --startup-project ../AdquisicionesADRES.API


Esto aplicará las migraciones y creará la base de datos con las tablas definidas en el proyecto de infraestructura.


Configuración y Ejecución del Proyecto


1. Clona el repositorio (o descárgalo como ZIP)
    git clone https://github.com/tu-usuario/AdquisicionesADRES.git
   
Luego abre la solución en Visual Studio con el archivo AdquisicionesADRES.sln.


2. Verifica la cadena de conexión

En AdquisicionesADRES.API/appsettings.json, revisa el DefaultConnection para que apunte a la instancia de SQL Server que creaste.


3. Compila la solución

  En Visual Studio, selecciona Build > Build Solution.

  O desde la línea de comandos:
    dotnet build AdquisicionesADRES.sln



4. Crea la base de datos (si no lo has hecho ya)

  Usando el script SQL o las migraciones de EF, como se explicó arriba.


5. Ejecuta la API

  Ejecuta AdquisicionesADRES.API como proyecto de inicio (Set as Startup Project).

  Visual Studio abrirá automáticamente una ventana de navegador con la API en https://localhost:5001 o similar.
  
  También podrás ver Swagger si está configurado, p. ej. en https://localhost:5001/swagger.


6. Ejecuta la aplicación Blazor (Cliente)

Si tienes un proyecto separado para el Cliente, asegúrate de que tenga su propia configuración en Visual Studio o lánzalo con:

  dotnet run --project AdquisicionesADRES.Client
  
Esto abrirá la aplicación en el navegador, apuntando a la API en https://localhost:5001 (o la ruta que corresponda).


    
