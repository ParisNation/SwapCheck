# SwapCheck
Engine swap compatibility tool for automotive enthusiasts and repair shops.

Built to demonstrate proficiency with OEC's exact technology stack while solving 
a real-world automotive problem. As someone who has been rebuilding a 2003 Land Rover 
Discovery 2 SE7 4.6L V8 for 8 years, this domain is personal.

## What It Does
SwapCheck allows users to select a vehicle and find compatible engine swaps based on:
- Mount pattern compatibility
- Engine bay size
- Drivetrain orientation
- Transmission bolt pattern
- Swap difficulty rating (DirectBolt → AdapterNeeded → CustomFabrication → NotFeasible)

## Architecture
Built with Clean Architecture principles — business logic is fully isolated from 
infrastructure concerns. Dependencies only point inward.

## Tech Stack

### Backend
| Technology | Purpose |
|---|---|
| .NET 10 | Core framework |
| ASP.NET Core Web API | REST API layer |
| Entity Framework Core | ORM / Database access |
| SQL Server | Relational database |
| MediatR | CQRS pattern / Request handlers |
| AutoMapper | Entity to DTO mapping |
| FluentValidation | Request validation |
| OpenAPI / Swagger | API documentation |

### Frontend
| Technology | Purpose |
|---|---|
| React 19 | UI framework |
| TypeScript | Type safety |
| Vite | Build tool / Dev server |
| TanStack Query | Async state / Data fetching |
| Tailwind CSS 4 | Utility-first styling |

## Domain Model
- **Vehicle** — Make, Model, Year, Engine Bay Size, Mount Pattern, Orientation
- **Engine** — Name, Manufacturer, Displacement, Horsepower, Torque, Aspiration, Fuel Type, Mount Pattern, ECU requirements
- **SwapCompatibility** — Links Vehicle + Engine with compatibility result, difficulty level, and mechanic notes

## Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server Express
- Node.js (LTS)

### Backend Setup
```bash
git clone https://github.com/ParisNation/SwapCheck.git
cd SwapCheck
dotnet restore
dotnet ef database update --project SwapCheck.Infrastructure --startup-project SwapCheck.API
dotnet run --project SwapCheck.API
```

### Frontend Setup
```bash
cd swapcheck-client
npm install
npm run dev
```

## About The Developer
Senior Full Stack Engineer with 19 years of experience including 11 years embedded 
at CDC/HHS supporting public health technology initiatives. Currently exploring 
opportunities in the automotive software space — a personal passion that combines 
engineering expertise with hands-on mechanical knowledge.