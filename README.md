# Stock Social ASP.NET API

This repository contains the source code for the Stock Social API, a project developed using ASP.NET Core. The API provides various functionalities related to stock and social interactions, enabling developers to integrate stock-related social features into their applications.

## Features

- **Stock Data Retrieval**: Fetch and manage stock information.
<!-- - **User Management**: Create and manage user accounts. -->
- **Social Interactions**: Allow users to interact socially around stock data, such as commenting and sharing insights.
<!-- - **Authentication**: Secure user authentication and authorization. -->
- **Data Persistence**: Utilize Entity Framework Core for data storage and management.

## Project Structure

The repository is organized as follows:

- **`api`**: Contains the main API project files.
  - **Controllers**: Define the API endpoints and handle HTTP requests.
  - **Data**: Contains the database context and migrations.
  - **Dtos**: Data Transfer Objects used for data interchange.
  - **Interfaces**: Define the service interfaces.
  - **Mappers**: Mapping configurations between entities and DTOs.
  - **Migrations**: Database migration files.
  - **Models**: Define the data models.
  - **Repositories**: Implementations of the data access layer.
  - **Program.cs**: The entry point of the application.
  - **appsettings.json**: Configuration settings for the application.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or later

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/elnaddar/stock_social_asp_net_api.git
   cd stock_social_asp_net_api
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Update the database:

   ```bash
   dotnet ef database update
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

## Usage

Once the application is running, you can access the API at http://localhost:5039. Use tools like Postman to test the API endpoints. Additionally, you can test and explore the API using the Swagger UI available at http://localhost:5039/swagger/index.html.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes. Ensure that your code adheres to the existing style and includes appropriate tests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please open an issue on the repository or contact the project maintainer.
