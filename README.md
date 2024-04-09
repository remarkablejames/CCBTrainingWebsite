# CCB Traing Website Repo

This repository contains the source code for the CCB Training website. 
The CCB Training website is designed to provide comprehensive resources and materials for individuals seeking to enhance their skills and knowledge in helping homeless people in Ottawa.

## How to Clone and Run the Repository Locally

### Prerequisites:
- .NET 8 SDK
- Postgres DB
- Integrated Development Environment (IDE) such as JetBrains Rider, Visual Studio, or any other compatible IDE

### Setting Up The Database
TThe application is designed to utilize a Postgres Database, although this can be easily modified. By default, the repository installs Postgres database providers to seamlessly integrate with Entity Framework Core, and the connection string template within the `appSettings.json` file is configured for Postgres DB. Should you wish to alter this configuration, you will need to install the appropriate database provider package from NuGet across all projects that interact with the DbContext. Subsequently, adjust the `DbConnectionString` to align with your specific database credentials.

Having met the aforementioned criteria, you should be able to successfully build and execute the project without encountering any errors.

## Design Decisions and Architectural Styles
The CCB Training website is built upon the principles of Clean Architecture, which emphasizes separation of concerns and maintainability. This architectural style promotes a clear separation between business logic, application-specific code, and infrastructure concerns. The repository pattern is employed to abstract away data access logic, allowing for flexibility and testability in managing data persistence. Additionally, the Command Query Responsibility Segregation (CQRS) pattern is utilized to separate read and write operations, optimizing performance and scalability. By adhering to Clean Architecture and leveraging Repository and CQRS patterns, the CCB Training website achieves a robust and modular design, facilitating easier maintenance, testing, and future enhancements.

more info about this design pattern: https://youtu.be/tLk4pZZtiDY?si=ThhEM90TPdHnMl9e

