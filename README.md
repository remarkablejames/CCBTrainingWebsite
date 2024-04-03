# CCB Traing Website Repo

This repository contains the source code for the CCB Training website. 
The CCB Training website is designed to provide comprehensive resources and materials for individuals seeking to enhance their skills and knowledge in helping homeless people in Ottawa.

## How to Clone and Run the Repository Locally
To clone and run the repository locally, follow these instructions:

1. .NET 8 SDK is required
2. clone the repo
3. open it in JetBrains Rider/ Visual Studio or anywhere else you like
4. build and run

## Design Decisions and Architectural Styles
The CCB Training website is built upon the principles of Clean Architecture, which emphasizes separation of concerns and maintainability. This architectural style promotes a clear separation between business logic, application-specific code, and infrastructure concerns. The repository pattern is employed to abstract away data access logic, allowing for flexibility and testability in managing data persistence. Additionally, the Command Query Responsibility Segregation (CQRS) pattern is utilized to separate read and write operations, optimizing performance and scalability. By adhering to Clean Architecture and leveraging Repository and CQRS patterns, the CCB Training website achieves a robust and modular design, facilitating easier maintenance, testing, and future enhancements.

more info about this design pattern: https://youtu.be/tLk4pZZtiDY?si=ThhEM90TPdHnMl9e

