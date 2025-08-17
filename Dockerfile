FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Proj3.API/*.csproj ./Proj3.API/
RUN dotnet restore "./Proj3.API/Proj3.API.csproj"

COPY . .
WORKDIR "/src/Proj3.API"
RUN dotnet publish "Proj3.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "Proj3.API.dll"]