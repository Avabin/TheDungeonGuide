FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Sessions/Sessions.Api/Sessions.Api.csproj", "./Functions/Sessions/Sessions.Api/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Sessions.Core/Sessions.Core.csproj", "./Modules/Sessions.Core/"]
RUN dotnet restore "Functions/Sessions/Sessions.Api/Sessions.Api.csproj"
COPY . .
WORKDIR "/src/Functions/Sessions/Sessions.Api"
RUN dotnet build "Sessions.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sessions.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sessions.Api.dll"]
