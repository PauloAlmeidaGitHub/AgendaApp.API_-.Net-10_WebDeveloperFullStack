# =========================
# STAGE 1 - Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar arquivos de solução
COPY *.sln ./

# Copiar csproj e restaurar dependências
COPY AgendaApp.UI/*.csproj AgendaApp.UI/

RUN dotnet restore ./AgendaApp.UI/AgendaApp.UI.csproj

# Copiar todo o restante do projeto
COPY . ./

# Publicar aplicação
RUN dotnet publish -c Release -o /publish


# =========================
# STAGE 2 - Runtime (Nginx)
# =========================
FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html

# Remover arquivos padrão do nginx
RUN rm -rf ./*

# Copiar arquivos publicados
COPY --from=build /publish/wwwroot ./

# Expor porta 80
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]