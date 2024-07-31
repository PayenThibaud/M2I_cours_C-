# DockerFile

# Formation sur les Dockerfiles

## Introduction

Les Dockerfiles sont des scripts textes qui contiennent une série d'instructions pour construire une image Docker. Comprendre la création et l'utilisation des Dockerfiles est essentiel pour personnaliser et optimiser vos images Docker.

## 1. Qu'est-ce qu'un Dockerfile?

Un Dockerfile est un fichier texte qui contient une série d'instructions permettant de créer une image Docker. Il spécifie les dépendances, la configuration et les étapes nécessaires pour exécuter une application.

## 2. Structure de Base d'un Dockerfile

Un Dockerfile suit une structure simple:

```Dockerfile
# Sélection de l'image de base
FROM nom_image[:tag]

# Définition du répertoire de travail
WORKDIR /chemin/du/repertoire

# Copie des fichiers locaux vers l'image
COPY fichier_source destination

# Exécution de commandes dans l'image
RUN commande

# Exposition des ports
EXPOSE port

# Définition de variables d'environnement
ENV variable=valeur

# Définition de la commande par défaut pour le conteneur
CMD ["commande", "argument"]
```

## 3. Instructions Principales d'un Dockerfile

### 3.1. **`FROM`**

Définit l'image de base à partir de laquelle construire.

```Dockerfile
FROM nom_image[:tag]
```

### 3.2. **`WORKDIR`**

Définit le répertoire de travail à l'intérieur de l'image.

```Dockerfile
WORKDIR /chemin/du/repertoire
```

### 3.3. **`COPY`**

Copie des fichiers locaux vers l'image.

```Dockerfile
COPY fichier_source destination
```

### 3.4. **`RUN`**

Exécute des commandes dans l'image pendant la construction.

```Dockerfile
RUN commande
```

### 3.5. **`EXPOSE`**

Spécifie les ports sur lesquels le conteneur écoute.

```Dockerfile
EXPOSE port
```

### 3.6. **`ENV`**

Définit des variables d'environnement.

```Dockerfile
ENV variable=valeur
```

### 3.7. **`CMD`**

Définit la commande par défaut pour le conteneur.

```Dockerfile
CMD ["commande", "argument"]
```

## Démonstration Pratique

### Scenario: Construction d'une Image Node.js avec Dockerfile

1. **Création d'un Dockerfile**:

   ```Dockerfile
   # Sélection de l'image de base
   FROM node:14

   # Définition du répertoire de travail
   WORKDIR /app

   # Copie des fichiers locaux vers l'image
   COPY package*.json ./

   # Installation des dépendances
   RUN npm install

   # Copie du reste des fichiers
   COPY . .

   # Exposition du port 3000
   EXPOSE 3000

   # Définition de la commande par défaut
   CMD ["npm", "start"]
   ```

2. **Construction de l'Image**:

   ```bash
   docker build -t mon-app-nodejs:1.0 .
   ```

3. **Exécution d'un Conteneur avec l'Image Créée**:

   ```bash
   docker run -p 3000:3000 mon-app-nodejs:1.0
   ```

   - Ouvrez votre navigateur à [http://localhost:3000](http://localhost:3000) pour accéder à l'application Node.js.

## Lexique

- **Dockerfile**: Script texte contenant des instructions pour construire une image Docker.
- **`FROM`**: Instruction spécifiant l'image de base à utiliser.
- **`WORKDIR`**: Instruction définissant le répertoire de travail.
- **`COPY`**: Instruction copiant des fichiers locaux vers l'image.
- **`RUN`**: Instruction exécutant des commandes pendant la construction de l'image.
- **`EXPOSE`**: Instruction spécifiant les ports sur lesquels le conteneur écoute.
- **`ENV`**: Instruction définissant des variables d'environnement.
- **`CMD`**: Instruction définissant la commande par défaut pour le conteneur.

## Liens Utiles

1. [Docker Documentation - Dockerfile](https://docs.docker.com/engine/reference/builder/)
2. [Best practices for writing Dockerfiles](https://docs.docker.com/develop/develop-images/dockerfile_best-practices/)
