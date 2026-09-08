# geral — RAD Convênio (C# + React)

Development workspace for the RADINFO **Delphi → Web** migration. It contains a minimal
but complete vertical slice that exercises the documented architecture end to end:

- **Backend** (`backend/`): ASP.NET Core Web API (.NET 8) following the
  **Controller → Service → Repository** pattern with interfaces.
- **Frontend** (`frontend/`): React + TypeScript (Vite) with **MUI**, following the
  **View → Controller → Service** pattern and the RAD color theme.
- **Tests** (`backend.tests/`): xUnit tests for the `Criptografia` utility (the Delphi
  crypto component ported to C#).

The demo feature is **Criptografia**: it ports the legacy Delphi encryption component to
C# and exposes it through the API and a React screen (encrypt clear text → hexadecimal →
decrypt back).

## Prerequisites

- .NET SDK 8 (installed automatically by `.cursor/install.sh` into `~/.dotnet`)
- Node.js 22+ / npm

## Setup

```bash
bash .cursor/install.sh
```

This installs the .NET SDK (if missing), restores the backend, and installs the frontend
dependencies. It is idempotent and safe to re-run.

## Running

Backend (http://localhost:5044, Swagger at `/swagger`):

```bash
export DOTNET_ROOT="$HOME/.dotnet"; export PATH="$HOME/.dotnet:$PATH"
export ASPNETCORE_URLS="http://0.0.0.0:5044"
cd backend && dotnet run --no-launch-profile
```

Frontend (http://localhost:5173, proxies `/api` and `/health` to the backend):

```bash
cd frontend && npm run dev
```

In Cloud Agents both services start automatically via the `terminals` defined in
`.cursor/environment.json`.

## Tests

```bash
export DOTNET_ROOT="$HOME/.dotnet"; export PATH="$HOME/.dotnet:$PATH"
dotnet test
```

## API

| Method | Route | Description |
|---|---|---|
| `GET` | `/health` | Health check |
| `POST` | `/api/criptografia/criptografar` | Encrypt clear text → hexadecimal |
| `POST` | `/api/criptografia/descriptografar` | Decrypt hexadecimal → clear text |

Request body: `{ "texto": "<value>" }`
