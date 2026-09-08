#!/usr/bin/env bash
# Idempotent bootstrap for the RAD Convênio dev environment (C# backend + React frontend).
set -euo pipefail

REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
DOTNET_DIR="$HOME/.dotnet"
DOTNET_CHANNEL="8.0"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_NOLOGO=1

echo "==> Ensuring .NET SDK ${DOTNET_CHANNEL} is installed"
if [ ! -x "${DOTNET_DIR}/dotnet" ]; then
  curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh
  bash /tmp/dotnet-install.sh --channel "${DOTNET_CHANNEL}" --install-dir "${DOTNET_DIR}"
else
  echo "    .NET SDK already present at ${DOTNET_DIR}"
fi

export DOTNET_ROOT="${DOTNET_DIR}"
export PATH="${DOTNET_DIR}:${PATH}"

echo "==> dotnet version: $(dotnet --version)"

echo "==> Restoring backend (.NET) dependencies"
dotnet restore "${REPO_ROOT}/backend/RadConvenioAPI.csproj"
dotnet restore "${REPO_ROOT}/backend.tests/RadConvenioAPI.Tests.csproj"

echo "==> Installing frontend (npm) dependencies"
cd "${REPO_ROOT}/frontend"
if [ -f package-lock.json ]; then
  npm ci
else
  npm install
fi

echo "==> Install complete."
