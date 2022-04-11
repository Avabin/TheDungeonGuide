FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Dices.Api/Dices.Api.csproj", "./Functions/Dices.Api/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
RUN dotnet restore "Functions/Dices.Api/Dices.Api.csproj"
COPY . .
WORKDIR "/src/Functions/Dices.Api/"
RUN dotnet build "Dices.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dices.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dices.Api.dll"]
