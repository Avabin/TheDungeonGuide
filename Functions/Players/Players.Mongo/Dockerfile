FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Players/Players.Mongo/Players.Mongo.csproj", "./Functions/Players/Players.Mongo/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Players.Core/Players.Core.csproj", "./Modules/Players.Core/"]
COPY ["Modules/Players.Mongo.Core/Players.Mongo.Core.csproj", "./Modules/Players.Mongo.Core/"]
COPY ["Shared/Functions.Mongo/Functions.Mongo.csproj", "./Shared/Functions.Mongo/"]
RUN dotnet restore "Functions/Players/Players.Mongo/Players.Mongo.csproj"
COPY . .
WORKDIR "/src/Functions/Players/Players.Mongo"
RUN dotnet build "Players.Mongo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Players.Mongo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Players.Mongo.dll"]
