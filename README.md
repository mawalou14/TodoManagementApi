# Todo Management API

The Todo Management API is a .NET Core web application designed to manage user todos and provide authentication services. It offers the following features:

- **User Authentication:**
  - User registration with email and password.
  - User login with JWT token-based authentication.
  - Password hashing for secure storage.

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

To run the application locally:
1. Clone this repository.
2. Configure the database connection in `appsettings.json`.
3. Run migrations to create the database schema.
4. Build and run the application.

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

## Contributors

- Add your name here if contributing.
