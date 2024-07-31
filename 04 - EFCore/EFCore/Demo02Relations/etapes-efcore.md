# Etapes création projet EFCore

1. Installer les dépendances
2. Créer les modèles (Avec les propriétés de navigations)
3. Créer votre DbContext
	- Créer les propriétés DbSet<>
	- Surcharger la configuration
	- (Optionnel) Surcharger la création de modèles
4. Faire une migration
5. Mettre à jour la base de données