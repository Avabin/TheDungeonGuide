FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Characters/Characters.Mongo/Characters.Mongo.csproj", "./Functions/Characters/Characters.Mongo/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Characters.Core/Characters.Core.csproj", "./Modules/Characters.Core/"]
COPY ["Shared/Functions.Mongo/Functions.Mongo.csproj", "./Shared/Functions.Mongo/"]
RUN dotnet restore "Functions/Characters/Characters.Mongo/Characters.Mongo.csproj"
COPY . .
WORKDIR "/src/Functions/Characters/Characters.Mongo"
RUN dotnet build "Characters.Mongo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Characters.Mongo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Characters.Mongo.dll"]
