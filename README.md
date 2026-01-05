# Feedback & Rating Service 

A standalone RESTful API built with **.NET 10** and **SQL Server** for collecting textual feedback and numeric ratings on tasks or projects, and calculating average scores.

This project is designed purely for **learning, practice, and team-based technical exercises**.  
It has no commercial or personal intent.

---

##  Project Goals

- Collect numeric ratings for Tasks or Projects
- Register textual feedback (comments)
- Validate all inputs strictly
- Prevent duplicate ratings per user per target
- Calculate and return average scores
- Follow **Onion Architecture** principles
- Keep the service fully independent

---

##  Architecture

The project follows **Onion Architecture** with clear separation of concerns:

- **API Layer**  
  Handles HTTP requests and responses  
  (`FeedbackRating.Api`)

- **Application Layer**  
  Use cases, DTOs, validations, business workflows

- **Domain Layer**  
  Core entities and business rules (Rating, Feedback)

- **Infrastructure Layer**  
  EF Core, SQL Server, repositories, mappings

- **Framework Layer**  
  Shared base abstractions and utilities


---

##  Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- RESTful API design

---

##  Assumptions

- Users, Tasks, and Projects already exist
- This service only receives their IDs
- No external service integration at this stage
- Rating range is limited (e.g. 1–5)

---

## 🔗 API Endpoints

## 🔗 API Endpoints

### POST api/Feedback/Create
Creates a textual feedback (comment) for a specific task or project.  
Validates that the feedback message is not empty and prevents duplicate submissions per user.

---

### POST api/Rating/Register
Registers a numeric rating for a task or project.  
Ensures the rating value is within the allowed range (e.g. 1–5) and prevents duplicate ratings by the same user for the same target.

---

### GET api/Rating/GetByTarget/ByTarget/{targetId}/{targetType}
Returns all ratings submitted for a specific task or project.  
Used for listing or reviewing individual rating records.

---

### GET api/Rating/GetAverage/Average/{targetId}/{targetType}
Calculates and returns the average rating score for a specific task or project.  
Provides a clear numeric representation of overall user satisfaction.
