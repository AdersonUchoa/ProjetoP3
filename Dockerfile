FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo
COPY . .

# Encontra e restaura o primeiro .csproj
RUN dotnet restore $(find . -name "*.csproj" | head -1)

# Encontra e publica o primeiro .csproj  
RUN dotnet publish $(find . -name "*.csproj" | head -1) -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "Proj3.API.dll"]