# 📇 Administrador de Contactos – Backend (API REST)

Este proyecto representa el **backend** de una aplicación web full stack para la gestión de contactos. Expone una **API REST** construida con **ASP.NET Core**, que permite a un cliente (frontend en React) realizar operaciones CRUD sobre contactos y grupos.

El sistema permite:

- Crear, actualizar, eliminar y listar contactos.
- Crear y gestionar grupos de contactos.
- Consultar los contactos asociados a un grupo específico.

## ⚙️ Funcionalidades

La API REST del Administrador de Contactos permite:

### 📇 Gestión de Contactos
- ✅ Crear nuevos contactos.
- 📋 Listar todos los contactos.
- 🔍 Obtener contacto por ID.
- ✏️ Actualizar información de un contacto.
- 🗑️ Eliminar un contacto.

### 👥 Gestión de Grupos
- ✅ Crear nuevos grupos de contactos.
- 📋 Listar todos los grupos existentes.
- 🔍 Obtener grupo por ID.
- ✏️ Actualizar información de un grupo.
- 🗑️ Eliminar un grupo.

### 🔗 Asociaciones
- 👁️ Listar contactos asociados a un grupo específico.
- 🔄 Asociar contactos a grupos mediante relaciones.

## 🛠️ Tecnologías Usadas

### 🧱 Backend

- **[ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)**
- **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)** 
- **SQL Server**

### 🧩 Arquitectura y buenas prácticas

- **Patrón Repository**
- **Principios SOLID** 
- **Enfoque Database First**

### 🧪 Herramientas de desarrollo

- **[Postman](https://www.postman.com/)**

## 🚀 Instalación y Ejecución Local (Backend)

Sigue estos pasos para ejecutar el backend del Administrador de Contactos en tu entorno local usando **Visual Studio** y **SQL Server**:

---

### 1. Requisitos Previos

- [Visual Studio 2022 o superior](https://visualstudio.microsoft.com/) con el **workload .NET para desarrollo web**.
- [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (puede ser Express).
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (opcional pero recomendado).
- [Postman](https://www.postman.com/) (para probar los endpoints de la API).

---

### 2. Clona el repositorio

```bash
  git clone https://github.com/tu-usuario/administrador-contactos-backend.git
```
Abre la solución .sln con Visual Studio.

### 3. Configura la cadena de conexión
En el archivo appsettings.json, actualiza la cadena de conexión a tu instancia local de SQL Server:

```
  "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ContactosDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
Asegúrate de que la base de datos ContactosDB ya exista o será generada a partir del enfoque Database First si usas scaffolding.

### 4. Restaurar paquetes NuGet
Visual Studio lo hará automáticamente al abrir la solución, pero puedes hacerlo manualmente:

```
  dotnet restore

```
### 5. Compilar y ejecutar la API
Presiona F5 o haz clic en "Iniciar depuración" en Visual Studio. La API se ejecutará y abrirá en tu navegador (por defecto en https://localhost:5001 o http://localhost:5000).

6. Probar la API
Puedes usar Postman u otra herramienta similar para consumir los endpoints disponibles, por ejemplo:

```
  GET https://localhost:5001/api

```
✅ ¡Listo! Tu backend está corriendo y listo para comunicarse con el frontend React.

Asegúrate de que la URL base del backend coincida con la configurada en el frontend.

## Licencia

Administrador de Contactos es [MIT licensed](./LICENSE).

## Contacto
**Nombre:** Manuel Tamayo Montero.

**Correo:** manueltamayo9765@gmail.com
