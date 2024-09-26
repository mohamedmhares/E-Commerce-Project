# E-Commerce Project

## Overview

This is the first version of an E-Commerce website where users can view products, explore product details, and manage their orders. The project utilizes modern web technologies, including .NET 6.0 for the backend, Angular 15 for the frontend, Bootstrap for responsive design, and Entity Framework for data access.

### Project Status
- **Current Version**: v1.0
- **Status**: This is the initial version of the project. Currently, users can view products, and I am actively working on implementing additional features, such as order management, user authentication, and payment gateways.

---

## Features

### Backend (.NET 6.0)
- **N-tier Architecture**: The backend is structured with a clear separation of concerns:
  - **Controllers**: Handle HTTP requests and responses, delegating logic to services.
  - **Services**: Contain business logic and interact with repositories.
  - **Repositories**: Handle database operations using Entity Framework.
  
- **Entity Framework Core**: 
  - **ORM** for managing data access between the application and SQL Server.
  - Implements **Code First Migrations** to manage schema changes.
  - Uses **LINQ** for querying the database efficiently.

- **Dependency Injection (DI)**:
  - Used throughout the project to inject dependencies (services, repositories) into controllers and other components.
  - Promotes loose coupling and enhances testability.
  - The `Startup.cs` or `Program.cs` configures the dependency container, which manages the lifetime of services.
  - Example of registering services in **Program.cs**:
    ```csharp
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddAutoMapper(typeof(Startup));
    ```

- **API Design**: RESTful API endpoints are designed to allow CRUD operations on products. Future versions will include endpoints for handling user orders, carts, and payments.

- **Error Handling Middleware**: Centralized error handling to catch and log exceptions, returning standardized error responses to the client.

- **Pagination, Filtering, Sorting, and Searching**:
  - Users can retrieve paginated product listings.
  - Products can be filtered based on categories, price ranges, and availability.
  - Sorting by price, name, or other attributes is supported.
  - Full-text search for product names and descriptions is available.

### Frontend (Angular 15)
- **Angular Framework**: The frontend is developed using Angular 15, offering a reactive and modular structure.
  - **Components**: Each section of the application (e.g., product listings, product details, cart) is represented by an Angular component.
  - **Services**: Used to interact with the backend API, manage state, and share data between components.
  - **Routing**: Angular's routing module is used to handle page navigation for viewing product listings, product details, and future pages like cart, orders, and profile.

- **Bootstrap 5**: 
  - Bootstrap is used to create a responsive, mobile-first design.
  - The layout dynamically adjusts for various screen sizes, ensuring an optimized user experience across devices.

### Design Patterns and Best Practices
- **Repository Pattern**: Abstracts data access logic, ensuring separation between business logic and data persistence.
- **Dependency Injection (DI)**: 
  - Injects dependencies like repositories and services into controllers.
  - Ensures loosely coupled components, promoting better testing and maintainability.
  - `AddScoped`, `AddSingleton`, and `AddTransient` are used to register services depending on their lifetime requirements.
  
- **DTOs (Data Transfer Objects)**: Used to transfer data between the frontend and backend, ensuring that only necessary data is exposed via the API.
- **AutoMapper**: Automates object mapping between DTOs and entities to simplify data transformation in service layers.
- **Unit of Work Pattern**: Manages database transactions, ensuring consistency and allowing for batch commits of multiple related operations.

---

## Technologies Used

- **Backend**: 
  - .NET 6.0 (LTS version)
  - Entity Framework Core (ORM)
  - SQL Server (Database)
  - AutoMapper (Object Mapping)
  - LINQ (Querying)
  - C#

- **Frontend**: 
  - Angular 15 (Frontend framework)
  - TypeScript (Main language)
  - Bootstrap 5 (CSS framework)
  - HTML5, CSS3

---

## Setup Instructions

### Prerequisites

- Install **.NET 6.0 SDK**: [Download .NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- Install **Node.js** (for Angular): [Download Node.js](https://nodejs.org/en/download/)
- Install **Angular CLI**: 
  ```bash
  npm install -g @angular/cli
