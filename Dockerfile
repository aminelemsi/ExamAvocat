# Utiliser l'image officielle .NET SDK pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copier les fichiers .csproj et restaurer les dépendances
COPY Examen.WEB/*.csproj ./Examen.WEB/
COPY Examen.ApplicationCore/*.csproj ./Examen.ApplicationCore/
COPY Examen.Infrastructure/*.csproj ./Examen.Infrastructure/
COPY Examen.Console/*.csproj ./Examen.Console/

RUN dotnet restore Examen.WEB/Examen.WEB.csproj

# Copier tout le code source et compiler l'application
COPY . ./
RUN dotnet publish Examen.WEB/Examen.WEB.csproj -c Release -o out

# Utiliser l'image officielle .NET runtime pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exposer le port 80
EXPOSE 80

# Commande d'exécution de l'application
ENTRYPOINT ["dotnet", "Examen.WEB.dll"]
