FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln ./
COPY src/Application/UserManagement.Application/*.csproj src/Application/UserManagement.Application/
COPY src/Domain/UserManagement.Domain/*.csproj src/Domain/UserManagement.Domain/
COPY src/Infra/UserManagement.Infra/*.csproj src/Infra/UserManagement.Infra/
COPY src/Presentation/UserManagement.WebUI/*.csproj src/Presentation/UserManagement.WebUI/
COPY src/Presentation/UserManagement.WebUI.Core/*.csproj src/Presentation/UserManagement.WebUI.Core/
COPY tests/UserManagement.Tests/*.csproj tests/UserManagement.Tests/

RUN dotnet restore

COPY . .

RUN dotnet publish src/Presentation/UserManagement.WebUI/UserManagement.WebUI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "UserManagement.WebUI.dll"]