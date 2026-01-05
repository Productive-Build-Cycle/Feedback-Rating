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
- Follow **Clean Architecture** principles
- Keep the service fully independent

---

##  Architecture

The project follows **Onion Architecture** with clear separation of concerns:

- **API Layer** → `FeedbackRating.Api`
- **Application Layer** → Use cases, DTOs, validation
- **Domain Layer** → Business rules and entities
- **Infrastructure Layer** → EF Core, SQL Server, repositories
- **Framework Layer** → Shared base abstractions

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

### Register Rating
