# Use .NET 9 SDK for building the project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["LibraryApiSqlServer.csproj", "./"]
RUN dotnet restore "LibraryApiSqlServer.csproj"

# Copy the rest of the files and build
COPY . .
RUN dotnet build "LibraryApiSqlServer.csproj" -c Release -o /app/build

# Publish the app
RUN dotnet publish "LibraryApiSqlServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use ASP.NET runtime image for final container (lighter and faster)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Expose port
EXPOSE 5255
ENV ASPNETCORE_URLS=http://+:5255

# Copy from build stage
COPY --from=build /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "LibraryApiSqlServer.dll"]

