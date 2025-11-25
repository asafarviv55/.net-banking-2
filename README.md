# .NET Banking 2

ASP.NET Core Web API with React SPA frontend.

## Tech Stack

- Backend: .NET 6.0 / ASP.NET Core
- Frontend: React 18 with Bootstrap
- Build: npm / dotnet CLI

## Prerequisites

- .NET 6.0 SDK
- Node.js 18+

## Setup

```bash
cd Project1/ClientApp
npm install
cd ..
dotnet restore
dotnet run
```

## Docker

```bash
docker build -t banking-app .
docker run -p 5000:80 banking-app
```

## Project Structure

```
Project1/
├── ClientApp/          # React frontend
│   ├── src/
│   │   ├── components/ # React components
│   │   └── App.js      # Main app
│   └── package.json
├── Controllers/        # API controllers
├── Program.cs          # App entry point
└── appsettings.json    # Configuration
```

## API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/weatherforecast` | GET | Weather data (demo) |
