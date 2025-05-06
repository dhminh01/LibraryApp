# LibraryApp

LibraryApp is a robust and scalable web application designed to manage library operations, including user management, book inventory, and borrowing processes. Built with modern technologies and best practices, it provides a clean architecture for extensibility and maintainability.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
- [Testing](#testing)
- [Contributing](#contributing)

## Features

- **User Management**: Register, update, and delete users with role-based access (Admin, User).
- **Book Management**: Add, update, and remove books from the library inventory.
- **Category Management**: Add, update, and remove categories from the library inventory.
- **Borrowing System**: Manage book borrowing function for user.
- **Secure Authentication**: Password hashing and role-based authorization.
- **RESTful API**: Exposes endpoints for all major functionalities.
- **Unit Testing**: Comprehensive unit tests for services using NUnit and Moq.

## Technologies

### Backend

- **Framework**: ASP.NET Core 8.0 (C#)
- **Database**: Entity Framework Core with SQL Server
- **Mapping**: AutoMapper for DTO-to-Entity mapping
- **Testing**: NUnit, Moq
- **Logging**: Serilog for structured logging
- **Dependency Injection**: Built-in ASP.NET Core DI
- **Configuration**: Environment variables and `appsettings.json`

### Frontend

- **Framework**: React 18 with TypeScript
- **Styling**: Tailwind CSS
- **State Management**: React Context API
- **HTTP Client**: Axios (via `http-service`)
- **Routing**: React Router DOM
- **Build Tool**: Vite
- **Type Safety**: TypeScript for type definitions

## Project Structure

```
LibraryApp/
├── backend/
│   ├── LibraryApp.Api/               # ASP.NET Core Web API
│   ├── LibraryApp.Application/       # Business logic, services, DTOs
│   ├── LibraryApp.Domain/            # Entities, interfaces, enums
│   ├── LibraryApp.Infrastructure/    # Data access, EF Core, seeding
│   ├── LibraryApp.Tests/             # Unit tests for services
│   ├── LibraryApp.sln                # Solution file
├── frontend/
│   ├── src/
│   │   ├── assets/                   # Images, SVGs, fonts
│   │   ├── components/               # Reusable UI components (buttons, layouts, etc.)
│   │   ├── context/                  # React Context for auth, user state
│   │   ├── helpers/                  # Utility functions (e.g., date formatting)
│   │   ├── http-service/             # Axios-based HTTP client for API calls
│   │   ├── pages/                    # Page components (e.g., Home, UserProfile)
│   │   ├── routers/                  # React Router configuration
│   │   ├── services/                 # Frontend service layer for API interactions
│   │   ├── types/                    # TypeScript type definitions
│   │   ├── utils/                    # General utilities (e.g., validation, string manipulation)
│   ├── public/                       # Static assets
│   ├── package.json                  # Frontend dependencies
├── README.md                         # Project documentation

```

## Getting Started

### Prerequisites

#### Backend

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

#### Frontend

- [Node.js 18+](https://nodejs.org/)
- [pnpm](https://pnpm.io/) (recommended) or [npm](https://www.npmjs.com/)
- [Git](https://git-scm.com/)

### Installation

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/dhminh01/LibraryApp.git
   cd LibraryApp
   ```

2. **Backend**: Restore dependencies:

   ```bash
   cd backend
   dotnet restore
   ```

3. **Frontend**: Install dependencies:
   ```bash
   cd frontend
   pnpm install  # or npm install
   ```

### Configuration

#### Backend

1. Configure the database connection string in `backend/src/LibraryApp.Api/appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=LibraryAppDb;Trusted_Connection=True;"
     }
   }
   ```

   _Optional, just for development:_

   For development, modify `backend/src/LibraryApp.Api/appsettings.json`:

   ```json
   {
     "AdminAccount": {
       "UserName": "your_admin_username",
       "Email": "your_admin_email",
       "Password": "your_admin_password",
       "FirstName": "your_admin_firstName",
       "LastName": "your_admin_lastName",
       "PhoneNumber": "your_admin_number",
       "Address": "your_admin_address",
       "DateOfBirth": "your_admin_dob"
     }
   }
   ```

2. Add migrations

   ```bash
   dotnet ef migrations add InitialCreate --project LibraryApp.Infrastructure --startup-project LibraryApp.Api
   ```

3. Apply database migrations:
   ```bash
   cd LibraryApp
   cd backend
   cd LibraryApp.API
   dotnet ef database update
   ```

#### Frontend

1. Configure the API base URL in `frontend/src/http-services/axios/config.ts`:

   ```typescript
   const ROOT_API = "YOUR_SERVER_URL";
   ```

### Running the Backend

1. Build the backend:

   ```bash
   cd backend
   dotnet build
   ```

2. Run the API:

   ```bash
   cd LibraryApp.Api
   dotnet run
   ```

3. Access the API at `https://localhost:5001` (or the port specified in `launchSettings.json`).
   - Swagger UI: `https://localhost:5001/swagger`

### Running the Frontend

1. Start the frontend development server:

   ```bash
   cd frontend
   pnpm dev  # or npm run dev
   ```

2. Access the application at `http://localhost:5173` (or the port specified by Vite).

## Testing

### Backend

Unit tests are located in `backend/tests/LibraryApp.Tests` and use NUnit with Moq.

1. Run tests:

   ```bash
   cd backend
   dotnet test
   ```

2. Test coverage:
   - Install `Test Adapter Converter (VSCode)`: [Download TAC](https://marketplace.visualstudio.com/items?itemName=ms-vscode.test-adapter-converter)

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m "Add YourFeature"`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.
