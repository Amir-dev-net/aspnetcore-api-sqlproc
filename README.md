# StoredProcWebAPI

A simple ASP.NET Core Web API project demonstrating how to call SQL Server stored procedures using Entity Framework Core.

## 🚀 Features

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core with SQL Server
- Calls stored procedures using `FromSqlRaw` and `FromSqlInterpolated`
- Clean folder structure (Controllers, Models, Services, Data)
- Dependency Injection for DbContext and services
- API endpoint to fetch employees by department and status

---

## 📂 Project Structure

StoredProcWebAPI/
│
├── Controllers/ # API endpoints
├── Models/ # Data models (e.g., Employee.cs)
├── Services/ # Business logic (e.g., EmployeeService.cs)
├── Data/ # AppDbContext and EF config
├── appsettings.json # Connection string
├── Program.cs # Service registration and app config
└── README.md # Project info (this file)

---

## 🧑‍💻 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (Stored Procedures)
- .NET 6 or later

---

## 🧱 Setup Instructions

### 1. Clone the Repository

git clone https://github.com/Amir-dev-net/aspnetcore-api-sqlproc.git
cd aspnetcore-api-sqlproc

### 2. Configure the Database Connection
Update your connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=YourDbName;Trusted_Connection=True;"
}

### 3. Install Dependencies

dotnet restore

### 4. Run the Application
dotnet run
Visit: http://localhost:5000/swagger

🧪 Sample API Endpoint
Get Employees by Department & Status

GET /api/employees/by-department/{deptId}/status/{isActive}
Example:

GET /api/employees/by-department/2/status/true


🧩 Stored Procedure Sample
CREATE PROCEDURE sp_GetEmployeesByDeptAndStatus
    @DepartmentId INT,
    @IsActive BIT
AS
BEGIN
    SELECT Id, Name, Department
    FROM Employees
    WHERE DepartmentId = @DepartmentId AND IsActive = @IsActive
END

📄 License
This project is open-source and available under the MIT License.

🙌 Credits
Created by [AMIR HAMZA]
Inspired by clean, maintainable backend design principles.