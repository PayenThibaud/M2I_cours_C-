# Docker Compose

# Formation sur Docker Compose

## Introduction

Docker Compose est un outil qui permet de définir et gérer des applications multi-conteneurs Docker. Il utilise un fichier YAML pour configurer les services, les réseaux, et les volumes, simplifiant ainsi le déploiement et la gestion d'applications complexes.

## 1. Qu'est-ce que Docker Compose?

Docker Compose est un outil qui permet de définir et gérer des applications Docker multi-conteneurs. Il utilise un fichier YAML pour spécifier les services, les réseaux, les volumes, et les configurations nécessaires à l'application.

## 2. Commandes de Base pour Travailler avec Docker Compose

### 2.1. **`docker-compose up`**

Démarre les conteneurs selon la configuration du fichier `docker-compose.yml`.

```bash
docker-compose up
```

### 2.2. **`docker-compose down`**

Arrête et supprime les conteneurs, les réseaux et les volumes définis dans le fichier `docker-compose.yml`.

```bash
docker-compose down
```

### 2.3. **`docker-compose ps`**

Affiche l'état des services.

```bash
docker-compose ps
```

### 2.4. **`docker-compose logs`**

Affiche les logs des services.

```bash
docker-compose logs nom_service
```

### 2.5. **`docker-compose exec`**

Exécute une commande dans un service.

```bash
docker-compose exec nom_service commande
```

## Démonstration Pratique

### Scenario: Déploiement d'une Application Web avec Docker Compose

1. **Création du Fichier `docker-compose.yml`**:

   ```yaml
   version: '3'
   services:
     web:
       image: nginx:latest
       ports:
         - "8080:80"
     app:
       image: mon-app-nodejs:1.0
       ports:
         - "3000:3000"
       depends_on:
         - db
     db:
       image: mysql:latest
       environment:
         MYSQL_ROOT_PASSWORD: my-secret-pw
       volumes:
         - mysql_data:/var/lib/mysql
   volumes:
     mysql_data:
   ```

2. **Démarrage de l'Application avec Docker Compose**:

   ```bash
   docker-compose up
   ```

3. **Accès à l'Application Web et Vérification de l'État**:

   - Ouvrez votre navigateur à [http://localhost:8080](http://localhost:8080) pour accéder à Nginx.
   - L'application Node.js est accessible à [http://localhost:3000](http://localhost:3000).
   - Vérifiez l'état des services avec `docker-compose ps`.

4. **Arrêt et Suppression de l'Application (facultatif)**:

   ```bash
   docker-compose down
   ```

## 3. Fonctionnalités Avancées de Docker Compose

### 3.1. **Variables d'Environnement**

- Utilisation de variables d'environnement dans le fichier `docker-compose.yml`.

  ```yaml
  services:
    app:
      image: mon-app-nodejs:1.0
      environment:
        NODE_ENV: production
  ```

### 3.2. **Réseaux Personnalisés**

- Définition de réseaux personnalisés pour les services.

  ```yaml
  networks:
    my_network:
      driver: bridge
  services:
    app:
      image: mon-app-nodejs:1.0
      networks:
        - my_network
  ```

## Lexique

- **Docker Compose**: Outil pour définir et gérer des applications multi-conteneurs Docker.
- **`docker-compose up`**: Commande pour démarrer les services selon la configuration du fichier `docker-compose.yml`.
- **`docker-compose down`**: Commande pour arrêter et supprimer les conteneurs, réseaux et volumes définis dans le fichier `docker-compose.yml`.
- **`docker-compose ps`**: Commande pour afficher l'état des services.
- **`docker-compose logs`**: Commande pour afficher les logs des services.
- **`docker-compose exec`**: Commande pour exécuter une commande dans un service.
- **Variables d'Environnement**: Paramètres dynamiques qui peuvent être utilisés dans le fichier `docker-compose.yml`.
- **Réseaux Personnalisés**: Réseaux définis dans `docker-compose.yml` pour connecter les services.

## Liens Utiles

1. [Docker Compose Documentation](https://docs.docker.com/compose/)
2. [Docker Compose - Get Started](https://docs.docker.com/compose/gettingstarted/)
3. [Docker Compose - Command Line Reference](https://docs.docker.com/compose/reference/)
