FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
WORKDIR /app
EXPOSE 5255

ENV ASPNETCORE_URLS=http://+:5255

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["LibraryApiSqlServer.csproj", "./"]
RUN dotnet restore "LibraryApiSqlServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "LibraryApiSqlServer.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LibraryApiSqlServer.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApiSqlServer.dll"]
