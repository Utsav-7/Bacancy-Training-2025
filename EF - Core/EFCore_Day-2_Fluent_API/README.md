# Entity Framework : Day - 2 (.NET Core Web API with Entity Framework Core)
## Problem Statement: 
- Project Setup
  - Create a .NET Core Web API project.
  - Configure Entity Framework Core and define a DbContext with at least three related entities (Schema choice will be yours) :
    - Customer (One-to-Many → A customer can have multiple orders).
    - Order (Many-to-Many ↔ An order can contain multiple products, and a product can be in multiple orders).
    - Product
- Define entity classes (models) and map them to database tables using both:
  - Data Annotations (attributes for defining primary keys, relationships, constraints, etc.).
  - **Fluent API (override the OnModelCreating method in DbContext to configure relationships and constraints).**
- Implement primary keys and composite keys where necessary.
  - SQL Query Logging
    - Enable logging to capture and display the actual SQL queries executed by LINQ queries in the console or logs.
- Migrations using Code-First Approach
  - Use Entity Framework Core Code-First Migrations to generate and apply database migrations.
  - Ensure the migrations are applied to SQL Server Management Studio (SSMS).
  - Attach the generated migration script as part of the submission.
