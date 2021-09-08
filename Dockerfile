FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /usermanagement

COPY *.sln ./
COPY UserManagement.Data/*.csproj ./UserManagement.Data/
COPY UserManagement.Core/*.csproj ./UserManagement.Core/
COPY UserManagement.Domain/*.csproj ./UserManagement.Domain/
COPY UserManagement.Infra/*.csproj ./UserManagement.Infra/
COPY UserManagement/*.csproj ./UserManagement/
COPY UserManagement.Tests/*.csproj ./UserManagement.Tests/
RUN dotnet restore

WORKDIR /usermanagement
COPY . .
RUN dotnet build -c Release -o /out

FROM build-env AS publish
RUN dotnet publish -c Release -o /usermanagement

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /usermanagement
EXPOSE 80

COPY --from=publish /usermanagement .

ENTRYPOINT [ "dotnet", "UserManagement.WebUI.dll" ]