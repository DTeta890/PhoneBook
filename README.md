# PhoneBook
ASP.NET Core 3.1 Web App
Model-View-Controller Architecture

The project is divided into 4 layers:
Data Layer (Entities Inheriting BaseEntity and Relationships)
Repository Layer (Entities Repositories of Operations Inheriting BaseRepository, DatabaseContext)
Service Layer (Instances of Repositories)
Web Layer (Application Layer, Business Logic, and UI)
-Dependency Injection (Scooped Repositories, Transient Services)

Layers are chained:
Data -> Repository -> Service -> Web

How to run the project:
1. Write Database Connection String on settings.json -> Repository Layer
2. Open Package Manager Console with default project (PhoneBook.Repository)
3. Write Command:
update-database -context DatabaseContext
4. Run the PhoneBook.Web project
