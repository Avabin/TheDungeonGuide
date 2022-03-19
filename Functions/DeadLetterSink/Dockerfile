FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Functions/DeadLetterSink/DeadLetterSink.csproj", "./Functions/DeadLetterSink/"]
COPY ["Modules/EventHandler.Infrastructure/EventHandler.Infrastructure.csproj", "./Modules/EventHandler.Infrastructure/"]
RUN dotnet restore "Functions/DeadLetterSink/DeadLetterSink.csproj"
COPY . .
WORKDIR "/src/Functions/DeadLetterSink"
RUN dotnet build "DeadLetterSink.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeadLetterSink.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeadLetterSink.dll"]
