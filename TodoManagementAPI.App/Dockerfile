#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TodoManagementAPI.App/TodoManagementAPI.App.csproj", "TodoManagementAPI.App/"]
COPY ["TodoManagementAPI.Infrastructure/TodoManagementAPI.Infrastructure.csproj", "TodoManagementAPI.Infrastructure/"]
COPY ["TodoManagementAPI.Application/TodoManagementAPI.Application.csproj", "TodoManagementAPI.Application/"]
COPY ["TodoManagementAPI.Domain/TodoManagementAPI.Domain.csproj", "TodoManagementAPI.Domain/"]
RUN dotnet restore "./TodoManagementAPI.App/TodoManagementAPI.App.csproj"
COPY . .
WORKDIR "/src/TodoManagementAPI.App"
RUN dotnet build "./TodoManagementAPI.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TodoManagementAPI.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoManagementAPI.App.dll"]