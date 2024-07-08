# Todo Management API

The Todo Management API is a .NET Core web application designed for managing user todos and providing authentication services. It includes orchestration support using Docker Compose.

## Features

- **User Authentication:**
  - Register with email and password.
  - Login with JWT token-based authentication.
  - Password hashing for security.

- **Todo Management:**
  - Create, retrieve, update, and delete todos.
  - Set priorities (high, medium, low) and status (e.g., completed, pending) for todos.
  - Filter todos by user and status.

- **Profile Management:**
  - Update user profile information (e.g., full name).
  - Change user password securely.

- **Security Features:**
  - JWT token generation and validation.
  - Password hashing using BCrypt.
  - Role-based access control.

- **Orchestration Support:**
  - Docker Compose for managing multi-container Docker applications.
  - Includes Dockerfile for building the API container.
  - PostgreSQL database container integration.

## Technologies Used

- **Backend:**
  - .NET Core
  - Entity Framework Core for database interactions
  - JWT for authentication
  - BCrypt.Net for password hashing
  - FluentValidation for input validation

- **Database:**
  - PostgreSQL

## Getting Started

To run the application locally using Docker Compose:

1. Clone this repository.
2. Navigate to the project directory.
3. Run `docker-compose up --build` to build and start the containers.
4. Access the API at `http://localhost:5000`.

## API Endpoints

- **Authentication:**
  - `POST /auth/register`: Register a new user.
  - `POST /auth/login`: Authenticate and retrieve JWT token.

- **Todo Management:**
  - `GET /todos`: Get all todos.
  - `GET /todos/{id}`: Get a todo by ID.
  - `POST /todos`: Create a new todo.
  - `PUT /todos/{id}`: Update a todo.
  - `PATCH /todos/{id}/status`: Update todo status.
  - `PATCH /todos/{id}/priority`: Update todo priority.
  - `DELETE /todos/{id}`: Delete a todo.

- **User Profile:**
  - `GET /profile/{userId}/todos`: Get todos for a specific user.
  - `PATCH /profile/{userId}`: Update user profile.
  - `PATCH /profile/{userId}/password`: Change user password.
  - `DELETE /profile/{userId}`: Delete user account.
