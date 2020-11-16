#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Moradia/Moradia.Api.csproj", "Moradia/"]
COPY ["Moradia.Data/Moradia.Data.csproj", "Moradia.Data/"]
RUN dotnet restore "Moradia/Moradia.Api.csproj"
COPY . .
WORKDIR "/src/Moradia"
RUN dotnet build "Moradia.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Moradia.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Moradia.Api.dll"]