# ToDoApp

ToDoApp is a simple console application designed to demonstrate clean architecture principles, dependency injection, and unit testing in C#. 
The application allows you to manage tasks with basic CRUD operations (Create, Read, Update, Delete) using a mock data repository.

## Project Structure

The solution consists of the following projects:

- **ToDoApp.Core**: Contains the core business logic and interfaces.
- **ToDoApp.Infrastructure**: Contains the implementation of the data repository.
- **ToDoApp.ConsoleApp**: The console application that acts as the presentation layer.
- **ToDoApp.Tests**: Contains unit tests for the core services and repository.

## Getting Started

### Prerequisites

- .NET SDK 8.0 or later
- A code editor like Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ToDoApp.git
   cd ToDoApp
