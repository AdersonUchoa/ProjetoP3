FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo
COPY . .

# Lista o que foi copiado
RUN echo "=== ARQUIVOS COPIADOS ==="
RUN ls -la
RUN echo "=== CONTEÚDO PASTA ProjP3.API ==="
RUN ls -la ProjP3.API/ || echo "Pasta ProjP3.API não encontrada"

# Restaura e publica
RUN dotnet restore
WORKDIR "/src/ProjP3.API"
RUN dotnet publish "ProjP3.API.csproj" -c Release -o /app/publish

# Mostra o que foi publicado
RUN echo "=== ARQUIVOS PUBLICADOS ==="
RUN ls -la /app/publish/

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Mostra o que está na pasta final
RUN echo "=== ARQUIVOS FINAIS ==="
RUN ls -la

ENV ASPNETCORE_URLS=http://+:$PORT

# Tenta executar qualquer DLL encontrada
CMD ["sh", "-c", "echo 'DLLs encontradas:' && ls -la *.dll && dotnet $(ls *.dll | head -1)"]