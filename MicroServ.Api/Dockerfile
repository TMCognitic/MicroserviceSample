#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MicroServ.Api/MicroServ.Api.csproj", "MicroServ.Api/"]
RUN dotnet restore "./MicroServ.Api/MicroServ.Api.csproj"
COPY . .
WORKDIR "/src/MicroServ.Api"
RUN dotnet build "./MicroServ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroServ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG MSSQL_IP
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionString="Data Source=$MSSQL_IP,1433;Initial Catalog=master;User Id=sa;Password=Test1234=;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
ENTRYPOINT dotnet MicroServ.Api.dll "$ConnectionString"