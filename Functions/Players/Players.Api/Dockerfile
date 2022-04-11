FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Players/Players.Api/Players.Api.csproj", "./Functions/Players/Players.Api/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Players.Core/Players.Core.csproj", "./Modules/Players.Core/"]
RUN dotnet restore "Functions/Players/Players.Api/Players.Api.csproj"
COPY . .
WORKDIR "/src/Functions/Players/Players.Api"
RUN dotnet build "Players.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Players.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Players.Api.dll"]
