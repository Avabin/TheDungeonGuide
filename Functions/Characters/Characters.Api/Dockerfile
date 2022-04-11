FROM ghcr.io/avabin/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/Characters/Characters.Api/Characters.Api.csproj", "./Functions/Characters/Characters.Api/"]
COPY ["Shared/Functions.Infrastructure/Functions.Infrastructure.csproj", "./Shared/Functions.Infrastructure/"]
COPY ["Modules/Characters.Core/Characters.Core.csproj", "./Modules/Characters.Core/"]
RUN dotnet restore "Functions/Characters/Characters.Api/Characters.Api.csproj"
COPY . .
WORKDIR "/src/Functions/Characters/Characters.Api"
RUN dotnet build "Characters.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Characters.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["/bin/sh", "-c", "sudo /etc/init.d/sshd start && dotnet Characters.Api.dll"]
