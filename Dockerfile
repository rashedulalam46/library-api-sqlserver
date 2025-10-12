# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 5255
ENV ASPNETCORE_URLS=http://+:5255

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0-bookworm-slim AS build
ARG configuration=Release
WORKDIR /src
COPY ["LibraryApiSqlServer.csproj", "./"]
RUN dotnet restore "LibraryApiSqlServer.csproj"
COPY . .
RUN dotnet build "LibraryApiSqlServer.csproj" -c $configuration -o /app/build

# Publish stage
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LibraryApiSqlServer.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApiSqlServer.dll"]
