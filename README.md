# eShop-microservices
Practice the microservices architecture and implementation

# Catalog Microservice with CQRS Pattern

## Overview

This project demonstrates a modular, scalable product catalog microservice built with .NET 8. It leverages the **CQRS (Command Query Responsibility Segregation)** pattern, MediatR for in-process messaging, and a vertical slice (feature-based) architecture. The solution is designed for maintainability, testability, and clear separation of concerns.

---

## Main Features

- **Product Catalog API**  
  Exposes endpoints for product management (e.g., create, list products) using ASP.NET Core Minimal APIs.

- **CQRS Implementation**  
  - **Commands**: Encapsulate write operations (e.g., create product).
  - **Queries**: Encapsulate read operations (e.g., get product list).
  - **Handlers**: Each command/query has a dedicated handler for business logic.

- **MediatR Integration**  
  Decouples API endpoints from business logic using MediatR for command/query dispatching.

- **Vertical Slice Architecture**  
  Organizes code by feature (not by layer), improving modularity and clarity. Each feature (e.g., Products/CreateProduct) contains its own models, handlers, and endpoints.

- **Dependency Injection**  
  Uses .NET's built-in DI for handler and service resolution.

- **Extensible Dispatcher**  
  A custom dispatcher abstracts command/query handling, making the system more flexible and testable.

---

## Technical Methodology

### 1. **CQRS Pattern**
- **Commands** and **Queries** are separated into distinct types and handlers.
- **Command Handlers** perform state-changing operations.
- **Query Handlers** perform data retrieval without side effects.

### 2. **MediatR**
- All commands and queries are sent via MediatR, which locates and invokes the appropriate handler.
- This reduces direct dependencies between API endpoints and business logic.

### 3. **Vertical Slice Architecture**
- Each feature (e.g., `Products/CreateProduct`) is self-contained:
  - **Endpoints**: Define HTTP routes and request handling.
  - **Handlers**: Implement business logic for commands/queries.
  - **Models**: Define request/response and domain models.

### 4. **Minimal APIs**
- Uses ASP.NET Core Minimal APIs for concise, testable endpoint definitions.
- Endpoints are grouped and registered via extension methods for clarity and reusability.

### 5. **Dependency Injection**
- All handlers and services are registered with the DI container.
- The dispatcher and MediatR are resolved via DI, supporting testability and loose coupling.

---

## Getting Started

1. **Build the Solution**
   - Requires .NET 8 SDK.

2. **Run the API**
   - Use `dotnet run` in the `Catalog.API` project directory.

3. **Explore Endpoints**
   - Use Swagger or any HTTP client to interact with `/products` endpoints.

---

## Project Structure


