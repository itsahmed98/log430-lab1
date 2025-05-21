# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY client/*.csproj ./client/
RUN dotnet restore ./client/client.csproj

COPY . .
RUN dotnet publish ./client/client.csproj -c Release -o /out

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "client.dll"]
