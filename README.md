### RxManager - Medicine Tracker System

RxManager is a Single Page Application (SPA) built using ASP.NET Core Web API and vanilla JavaScript to manage medicine inventory and sales. 
The application enables users to track medicines, monitor stock levels, manage expiry dates, and record sales transactions with real time updates.


## Features

# 1. Medicine Management/Tracking

* Add new medicines from UI
* View medicines in a grid
* Track expiry dates and stock levels

# 2. Smart Visual Indicators

* Red highlight for medicines expiring within 30 days
* Yellow highlight for low stock (quantity < 10)

# 3. Search Functionality

* Real time search by medicine name

# 4. Sales Management

* Sell medicines directly from UI
* Automatic stock deduction
* Prevents selling beyond available stock

# 5. Sales History

* View all sales records
* Displays medicine name, quantity sold, and timestamp


## Tech Stack

* Backend: ASP.NET Core Web API (.NET 8)
* Frontend: HTML, CSS, JavaScript (SPA)
* Data Storage: JSON files (no database)
* Tools: Visual Studio, Git, GitHub


## Project Structure

RxManager/
│
|--- Controllers/       # API endpoints
|--- Models/            # Core data models
|--- DTOs/              # Data transfer objects
|--- Services/          # Business logic
|--- Helpers/           # Utility classes
|--- Data/              # JSON storage
|--- wwwroot/           # Frontend (HTML, JS, CSS)
|--- Program.cs         # App configuration


## How to Run the Project

# Prerequisites

* .NET SDK installed
* Visual Studio / VS Code

# Steps

1. Clone the repository:
   git clone https://github.com/your-username/RxManager.git

2. Navigate to project folder:
   cd RxManager

3. Run the application:
   dotnet run

4. Open browser:
   https://localhost:7223/


# Key Concepts Implemented

* Clean Architecture (Controller -> Service -> Helper)
* Separation of Concerns
* RESTful API design
* Form validation
* JSON based persistence
* Dynamic UI rendering


## Future Enhancements

* User authentication
* Role based access control
* Pagination
* Database integration (SQL Server)
* Cloud deployment (Azure)
* Dashboard & analytics


## Author

Manoj Kumar Dwivedi

## License

This project is open source and available for learning and demonstration purposes.
