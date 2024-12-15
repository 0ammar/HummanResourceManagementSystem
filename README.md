# Human Resources Management System (HRMS) - Backend

## Project Overview

The **Human Resources Management System (HRMS)** is a backend solution designed to efficiently manage employee data, departmental processes, and other HR-related tasks. Developed with **ASP.NET Core**, **Entity Framework**, and **SQL Server**, this system allows for seamless management of employee records, contracts, and departments, supporting various HR functions such as contract creation, employee tracking, and departmental operations.

The application follows best practices like **Agile methodology**, **SOLID principles**, and **Dependency Injection**, ensuring that it is maintainable, scalable, and easy to extend. It integrates various services like **Contract Services**, **Employee Services**, **Department Services**, and **Lookup Services**, while also incorporating **LINQ** for efficient data querying, **Encryption** for data security, and **Multi-Validations** for maintaining data integrity.

## Technologies Used

- **Backend**:  
  - ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=flat&logo=dotnet&logoColor=white) **ASP.NET Core** for building the RESTful APIs.
  - ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white) **C#** for server-side development.
  - ![Entity Framework](https://img.shields.io/badge/Entity_Framework-7A6F52?style=flat&logo=dotnet&logoColor=white) **Entity Framework** for data access and ORM.
  - ![SQL Server](https://img.shields.io/badge/SQL_Server-0078D4?style=flat&logo=microsoft-sql-server&logoColor=white) **SQL Server** for managing relational data.

- **Design Patterns**:  
  - ![Base Layer Pattern](https://img.shields.io/badge/Base_Layer_Pattern-1E1E1E?style=flat&logo=layer&logoColor=white) **Base Layer Pattern** for organizing project structure.
  - ![Dependency Injection](https://img.shields.io/badge/Dependency_Injection-1F9C8D?style=flat&logo=dependencyinjection&logoColor=white) **Dependency Injection** for better testability and separation of concerns.
  - ![SOLID Principles](https://img.shields.io/badge/SOLID_Principles-BC2F2F?style=flat&logo=dotnet&logoColor=white) **SOLID Principles** for creating maintainable and scalable code.

- **Tools and Services**:  
  - ![Swagger](https://img.shields.io/badge/Swagger-25A14A?style=flat&logo=swagger&logoColor=white) **Swagger** for API documentation.
  - ![Serilog](https://img.shields.io/badge/Serilog-00A1F1?style=flat&logo=serilog&logoColor=white) **Serilog** for logging and troubleshooting.
  - ![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white) **Git** and **GitHub** for version control.

## Key Features

- **Contract Management**:  
  Efficiently create, update, and manage employee contracts, track contract statuses, and manage deadlines.  
  ![Contract Management](https://img.shields.io/badge/Contract_Management-FFD700?style=flat&logo=contract&logoColor=black)

- **Employee Management**:  
  Maintain and organize employee records, including personal and professional details, performance tracking, and department assignments.  
  ![Employee Management](https://img.shields.io/badge/Employee_Management-32CD32?style=flat&logo=employee&logoColor=white)

- **Department Management**:  
  Manage departments within the organization, assign employees to departments, and track departmental activities and performance.  
  ![Department Management](https://img.shields.io/badge/Department_Management-FF6347?style=flat&logo=building&logoColor=white)

- **Lookup Services**:  
  Use lookup services to reference critical data like employee roles, positions, and statuses for consistency and ease of management.  
  ![Lookup Services](https://img.shields.io/badge/Lookup_Services-00BFFF?style=flat&logo=search&logoColor=white)

- **Logging and Monitoring**:  
  Integrated with **Serilog** to provide robust logging, making it easier to monitor system operations and troubleshoot any issues.  
  ![Logging](https://img.shields.io/badge/Logging-800080?style=flat&logo=logstash&logoColor=white)

- **LINQ Querying**:  
  Efficient and readable data querying with **LINQ**, providing optimized database queries for improved performance.  
  ![LINQ](https://img.shields.io/badge/LINQ-FF1493?style=flat&logo=dotnet&logoColor=white)

- **Encryption**:  
  **Data Encryption** implemented for protecting sensitive employee and contract information, ensuring security and confidentiality.  
  ![Encryption](https://img.shields.io/badge/Encryption-4B0082?style=flat&logo=padlock&logoColor=white)

- **Multi-Validations**:  
  Multi-level validations for data inputs (email, passwords, employee details) to ensure high data integrity and minimize errors.  
  ![Validation](https://img.shields.io/badge/Validation-32CD32?style=flat&logo=check-circle&logoColor=white)

## How to Run the Application

1. Clone the repository:  
   ```bash
   git clone https://github.com/0ammar/HummanResourceManagementSystem.git
