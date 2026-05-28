# SwapCheck 🔧

> Engine Swap Compatibility Tool — Built with real mechanic knowledge

![SwapCheck Screenshot](./screenshot.png)

**Live demo:** Select a vehicle, check which engines are compatible, 
and see difficulty ratings based on real mechanical compatibility rules.

Built to demonstrate proficiency with OEC's exact technology stack while 
solving a real-world automotive problem. As someone who has been rebuilding 
a 2003 Land Rover Discovery 2 SE7 4.6L V8 for 8 years, this domain is personal.

---

## The Problem

Engine swaps are complex. A shop or enthusiast needs to know:
- Will this engine physically fit in this vehicle?
- Does the mount pattern match?
- Is this a direct bolt-in or does it need custom fabrication?
- What are the notes a mechanic would need to know?

SwapCheck answers those questions through a clean, fast API and a 
modern React frontend.

---

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

---

## Architecture

Built with **Clean Architecture** — business logic is fully isolated 
from infrastructure concerns. Dependencies only point inward.

**Dependency Rule:** Domain knows nothing. Everything knows Domain.

---

## Domain Model

### Entities
- **Vehicle** — Make, Model, Year, Engine Bay Size, Mount Pattern, Orientation
- **Engine** — Name, Manufacturer, Displacement, Horsepower, Torque, 
  Aspiration Type, Fuel Type, Mount Pattern, ECU requirements
- **SwapCompatibility** — Links Vehicle + Engine with compatibility 
  result, difficulty level, and mechanic notes

### Enums
- `SwapDifficulty` — DirectBolt, AdapterNeeded, CustomFabrication, NotFeasible
- `AspirationType` — NaturallyAspirated, Turbocharged, Supercharged, etc
- `MountPattern` — 27 real world mount configurations
- `Cylinders`, `FuelType`, `EngineSize`, `Orientation`, `TransBoltPattern`

---

## API Endpoints

### GET /api/vehicles
Returns all available vehicles for the dropdown selector.

**Response:**
```json
[
  {
    "id": "28dd562d-82cb-499d-be67-0a4d29fd5765",
    "make": "Land Rover",
    "model": "Discovery",
    "year": 2003
  }
]
```

### GET /api/compatibility/{vehicleId}
Returns compatible engine options for a specific vehicle with 
difficulty ratings and mechanic notes.

**Response:**
```json
[
  {
    "id": "abc123",
    "isCompatible": true,
    "difficultyLevel": "DirectBolt",
    "notes": "Factory fit - original engine",
    "engine": {
      "engineName": "Rover V8",
      "manufacturer": "Land Rover",
      "mountPattern": "FrontLongitudinal",
      "engineSize": "Large"
    }
  },
  {
    "id": "def456",
    "isCompatible": false,
    "difficultyLevel": "CustomFabrication",
    "notes": "Requires custom mounts and adapter plate",
    "engine": {
      "engineName": "Chevrolet LS3",
      "manufacturer": "Chevrolet",
      "mountPattern": "FrontLongitudinal",
      "engineSize": "Large"
    }
  }
]
```

---

## Seeded Data

### Vehicles
- 2003 Land Rover Discovery
- 1969 Chevrolet Camaro
- 1965 Ford Mustang
- 2025 Dodge Charger

### Engines
- Rover V8 4.6L
- Chevrolet LS3 6.2L
- Ford Coyote 5.0L
- Dodge HEMI 5.7L

### Compatibility Records
| Vehicle | Engine | Compatible | Difficulty |
|---|---|---|---|
| Land Rover Discovery | Rover V8 | ✅ Yes | DirectBolt |
| Land Rover Discovery | Chevrolet LS3 | ❌ No | CustomFabrication |
| Chevrolet Camaro | Chevrolet LS3 | ✅ Yes | DirectBolt |
| Ford Mustang | Ford Coyote | ✅ Yes | DirectBolt |
| Dodge Charger | Dodge HEMI | ✅ Yes | DirectBolt |

---

## Key Architecture Decisions

**Why Clean Architecture?**
OEC serves 60,000+ dealerships globally. Enterprise software at that 
scale requires business rules isolated from infrastructure. If the 
database changes tomorrow the Domain and Application layers don't change.

**Why MediatR?**
Keeps controllers thin. Every request flows through a central mediator — 
like Redux for .NET. Nothing is tightly coupled. Handlers are independently 
testable without spinning up a controller or database.

**Why Repository Pattern?**
Handlers depend on interfaces not concrete implementations. Swap SQL 
Server for PostgreSQL — only the Infrastructure layer changes. Business 
logic stays untouched.

**Why AutoMapper?**
Entities never get exposed directly over the API. DTOs define exactly 
what shape the data takes over the wire. AutoMapper handles the conversion 
automatically by convention — matching property names without manual mapping.

**Why FluentValidation?**
Validation is a business rule — it belongs in the Application layer not 
the API layer. A VehicleId that's empty should be rejected regardless of 
whether the request comes from a REST API, message queue, or unit test.

---

## Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server Express (`localhost\SQLEXPRESS`)
- Node.js LTS

### Backend Setup
```bash
git clone https://github.com/ParisNation/SwapCheck.git
cd SwapCheck
dotnet restore
dotnet ef database update --project SwapCheck.Infrastructure --startup-project SwapCheck.API
dotnet run --project SwapCheck.API
```

API runs on `http://localhost:5069`
Swagger UI at `http://localhost:5069/swagger`

### Frontend Setup
```bash
cd swapcheck-client
npm install
npm run dev
```

Frontend runs on `http://localhost:5173`

---

## About

Built by **Paris Humphrey Jr.** — Senior Full Stack Engineer with 19 years 
of experience including 11 years embedded at CDC/HHS supporting mission 
critical public health technology across four administrations and four 
global outbreaks.

Currently exploring opportunities in the automotive software space — 
a personal passion that combines engineering expertise with hands-on 
mechanical knowledge.

**GitHub:** https://github.com/ParisNation/SwapCheck  
**LinkedIn:** https://www.linkedin.com/in/parishumphreyjr/