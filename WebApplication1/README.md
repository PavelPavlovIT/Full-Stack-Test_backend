# Full-Stack-Test Backend (ASP.NET Core 8)

Backend API for the Full-Stack test project. The solution is split into multiple projects to keep responsibilities separated and to make future scaling easier.

## Project Structure

| Project | Path | Responsibility |
|---|---|---|
| `WebApplication1` | `./WebApplication1` | Main ASP.NET Core API host (controllers, DI, `Program.cs`, Swagger, CORS). |
| `Services` | `./Services` | Business logic layer (pricing rules, invoice calculation via `PricingService`). |
| `Data` | `./Data` | In-memory data store (`AppDataStore`) implemented with thread-safe collections (`ConcurrentDictionary`). |
| `Common` | `./Common` | Shared domain models (e.g. `Student`, `Course`, `Invoice`). |

## How to Run

1. Ensure you have **.NET SDK 8** installed.
2. From the repository root, go to the API host project folder:

```bash
cd WebApplication1
```

3. Run the API:

```bash
dotnet run
```

4. Open Swagger UI:

- `http://localhost:<port>/swagger`

> Note: CORS is configured to allow requests from the React frontend.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/students` | Returns the list of students. |
| `GET` | `/api/courses` | Returns the list of courses. |
| `POST` | `/api/invoices/preview` | Calculates and returns an invoice preview (pricing/discounts) without persisting a payment. |

## Key Logic

- **Money is represented using `decimal`** to avoid floating-point rounding issues.
- Rounding follows common financial rules using:

```csharp
MidpointRounding.AwayFromZero
```

- The API implements **graceful error handling** (e.g., a clean `404 Not Found` JSON response when requested entities are not found).

## Tech Decisions

- **Singleton lifetime for in-memory storage**: `AppDataStore` is registered as a singleton so the application keeps a single consistent in-memory state for the entire process lifetime.
  - This is appropriate for an in-memory store (no DB) and matches the intent of sharing state across requests.
  - Thread-safety is ensured via `ConcurrentDictionary`.

- **Separated class library projects (`Common`, `Data`, `Services`)**:
  - Keeps the API host thin (only HTTP concerns).
  - Encourages clean boundaries between models, storage, and business logic.
  - Makes it easier to test and replace implementations later (e.g., swap the in-memory `Data` layer for a database).
