# Library API (SQL Server)

A .NET Core / .NET 9 Web API for managing a library system, backed by SQL Server.  
This project is structured with clean architecture (Domain, Application, Infrastructure, API) and supports basic CRUD operations on books, authors, etc.

---

## 📁 Repository Structure
```
LibraryApiSqlServer/
├── Library.Api/ # API / presentation layer (controllers, endpoints)
├── Library.Application/ # Application logic (use cases, services, DTOs)
├── Library.Domain/ # Domain / core (entities, interfaces)
├── Library.Infrastructure/ # Data access, repository implementations, EF Core, DB context
├── LibraryApiSqlServer.sln
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── README.md
```

---

## ⚙️ Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download) or compatible .NET version  
- SQL Server instance (local or remote)  
- (Optional) A tool like **SQL Server Management Studio (SSMS)** for DB inspection  

---

## 🔧 Setup / Getting Started

**1. Clone the repository**

```bash
   git clone https://github.com/rashedulalam46/library-api-sqlserver.git
   cd library-api-sqlserver
```

**2. Configure connection string**
   
Open appsettings.json or appsettings.Development.json, and set up your ConnectionStrings:DefaultConnection to point to your SQL Server.

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDb;User Id=…;Password=…;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

```
**3. Apply migrations / create database**
   
In the Infrastructure project (or main solution root), run:

```
dotnet ef database update
```

This will create the database and necessary tables.

**4. Build & run the API**

```
dotnet build
dotnet run --project Library.Api
```

The default launch URL might be https://localhost:5001 (or as configured). Use a tool like Postman, curl, or HTTPie to test the endpoints.
