FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Sessions/Sessions.Mongo/Sessions.Mongo.csproj", "./Functions/Sessions/Sessions.Mongo/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Sessions.Core/Sessions.Core.csproj", "./Modules/Sessions.Core/"]
COPY ["Shared/Functions.Mongo/Functions.Mongo.csproj", "./Shared/Functions.Mongo/"]
RUN dotnet restore "Functions/Sessions/Sessions.Mongo/Sessions.Mongo.csproj"
COPY . .
WORKDIR "/src/Functions/Sessions/Sessions.Mongo"
RUN dotnet build "Sessions.Mongo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sessions.Mongo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sessions.Mongo.dll"]
