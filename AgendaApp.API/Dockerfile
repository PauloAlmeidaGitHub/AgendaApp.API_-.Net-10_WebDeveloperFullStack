# =========================
# STAGE 1 - BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar arquivos de solução
COPY *.sln ./

# Copiar arquivos de projeto separadamente (melhora cache)
COPY AgendaApp.API/*.csproj AgendaApp.API/
COPY AgendaApp.Domain/*.csproj AgendaApp.Domain/
COPY AgendaApp.Infra.Data/*.csproj AgendaApp.Infra.Data/

# Restaurar dependências
RUN dotnet restore ./AgendaApp.API/AgendaApp.API.csproj

# Copiar todo o restante
COPY . .

# Publicar API
WORKDIR /src/AgendaApp.API
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


# =========================
# STAGE 2 - RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# Expor porta padrão do ASP.NET
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "AgendaApp.API.dll"]