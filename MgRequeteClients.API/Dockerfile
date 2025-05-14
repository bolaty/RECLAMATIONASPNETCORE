# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copier tout le contenu de la solution
COPY . ./

# Aller dans le dossier principal du projet Web API
WORKDIR /app/MgRequeteClients.API

# Restaurer les packages NuGet
RUN dotnet restore

# Publier le projet
RUN dotnet publish -c Release -o /out

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Exposer le port utilisé dans Program.cs ou launchSettings.json
EXPOSE 40000

# Lancer l’application
ENTRYPOINT ["dotnet", "MgRequeteClients.API.dll"]
