#!/bin/bash

# Read the migrations path from appsettings.json
MIGRATIONS_PATH=$('.EntityFramework.MigrationsPath' appsettings.json)

# Check if a migration name was provided
if [ -z "$1" ]; then
  echo "You must specify a migration name."
  exit 1
fi

# Create the migration using the specified path
dotnet ef migrations add $1 -o "$MIGRATIONS_PATH"