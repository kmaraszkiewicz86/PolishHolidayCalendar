# Polish Holiday Calendar - DDD Implementation

This project implements a DDD (Domain-Driven Design) architecture with CQRS pattern for managing Polish public holidays.

## Project Structure

The solution consists of the following projects:

### 1. **PolishHolidayCalendar.Domain** (Class Library)
- Contains the core domain entities and interfaces
- Uses CQRS pattern with `Kmaraszkiewicz86.SimpleCqrs` package version 0.1.4
- **Entities:**
  - `PublicHoliday` - Represents a public holiday with properties like Date, LocalName, Name, CountryCode, etc.
- **Interfaces:**
  - `IHttpService` - Interface for fetching holidays from external API
  - `IPublicHolidayRepository` - Interface for saving holidays to database
  - `IPublicHolidayQuery` - Interface for querying holidays from database

### 2. **PolishHolidayCalendar.Infrastructure** (Class Library)
- Implements the infrastructure concerns
- References: Domain project, EF Core, EF Core SQL Server
- **Services:**
  - `HttpService` - Fetches public holiday data from Nager.Date API (`https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}`)
- **Repositories:**
  - `PublicHolidayRepository` - Saves holidays to database using EF Core
- **Queries:**
  - `PublicHolidayQuery` - Fetches data from database
    - Uses `.FromSqlRaw()` for standard queries (GetAllAsync, GetByYearAsync)
    - Uses LINQ for admin queries (GetByIdAsync)
- **Data:**
  - `PublicHolidayDbContext` - EF Core DbContext for database operations

### 3. **PolishHolidayCalendar.Application** (Class Library)
- Application layer for business logic and use cases
- Currently empty, ready for implementing application services and commands/queries

### 4. **PolishHolidayCalendar.ConsoleApp** (Console Application)
- Demonstration application showing how to use the services
- Shows example of fetching holidays from the API

## Key Features

1. **DDD Architecture** - Clean separation of concerns with Domain, Infrastructure, and Application layers
2. **CQRS Pattern** - Implemented using SimpleCqrs package
3. **HTTP Service** - Fetches data from Nager.Date public holidays API
4. **Repository Pattern** - Saves data to database
5. **Query Pattern** - 
   - Uses EF Core `.FromSqlRaw()` for fetching data (as required)
   - Admin queries use LINQ (as specified)
6. **Entity Framework Core** - For database operations with SQL Server

## Technologies Used

- .NET 10.0
- Kmaraszkiewicz86.SimpleCqrs 0.1.4
- Entity Framework Core 10.0.2
- Entity Framework Core SQL Server 10.0.2
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Http

## Getting Started

### Prerequisites
- .NET 10.0 SDK or later
- SQL Server (for database operations)

### Building the Solution
```bash
dotnet build
```

### Running the Console App
```bash
dotnet run --project src/PolishHolidayCalendar.ConsoleApp/PolishHolidayCalendar.ConsoleApp.csproj
```

## Implementation Details

### HttpService
The `HttpService` fetches data from the Nager.Date API:
- Endpoint: `GET https://date.nager.at/api/v3/PublicHolidays/{year}/{countryCode}`
- Example: `GET https://date.nager.at/api/v3/PublicHolidays/2026/PL`

### PublicHolidayRepository
Saves holidays to the database with duplicate checking based on Date and CountryCode.

### PublicHolidayQuery
- `GetAllAsync()` - Uses `.FromSqlRaw("SELECT * FROM PublicHolidays")`
- `GetByYearAsync(year)` - Uses `.FromSqlRaw("SELECT * FROM PublicHolidays WHERE YEAR(Date) = {0}", year)`
- `GetByIdAsync(id)` - Uses LINQ: `.Where(h => h.Id == id).FirstOrDefaultAsync()`

## Database Setup

To set up the database, you'll need to:
1. Configure connection string in your application
2. Create migrations: `dotnet ef migrations add InitialCreate --project src/PolishHolidayCalendar.Infrastructure`
3. Update database: `dotnet ef database update --project src/PolishHolidayCalendar.Infrastructure`

## Next Steps

- Add application layer services and use cases
- Implement CQRS commands and queries using SimpleCqrs
- Add API/Web project for RESTful endpoints
- Add unit and integration tests
- Configure dependency injection container
- Add logging and error handling
