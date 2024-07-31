# Utilisation de l'image ASP.NET runtime pour une image de base qui sera utilise en final
FROM mcr.microsoft.com/dotnet/aspnet AS base
# definit le repertoire de travail /app 
WORKDIR /app
# Expose le port 8080 de cette image
EXPOSE 8080


# Utilisation de l'image officiel de microsoft SDK pour une image qui va permettre de build le projet
FROM mcr.microsoft.com/dotnet/sdk AS build
# definit le repertoire de travail /src 
WORKDIR /src
# copie le fichier monappblazor.csproj dans le repertoire de travail
COPY ["monappblazor.csproj","."]
# restore les dépendances en utilisant le fichier monappblazor.csproj (qui contient la liste des dependances)
RUN dotnet restore "monappblazor.csproj"
# copier l'integralite du repertoire dans le repertoire de travail (sauf les fichiers/dossier du dockerignore)
COPY . .
# build de l'application a l'interieur du container build en mode release et resultat dans le repertoire /app/build
RUN dotnet build "monappblazor.csproj" -c Release -o /app/build

# Creation d'un nouveau stage (couche) base sur build qui s'apelle publish
FROM build AS publish
# Publication de l'application en mode release dans le repertoire /app/publish
RUN dotnet publish "monappblazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Creation d'un stage final à partir de base
FROM base AS final
# definit le repertoire de travail /app 
WORKDIR /app
# copie le repertoire /app/publish provenant du stage publish dans le repertoire de travail
COPY --from=publish /app/publish .
# defini la commande à lance lors du run de l'image (création du container)
ENTRYPOINT ["dotnet","monappblazor.dll"]


# construire l'image
# Ouvrir un terminal a la racine du projet (ou se trouve le dockerfile)
# docker build -t blazor-chouchou .

# test de l'image
# docker run -d --name chouchou-blazor -p 5006:8080 blazor-chouchou
# http://localhost:5006/