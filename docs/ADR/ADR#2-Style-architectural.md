# Séparation des responsabilités : Présentation et Persistance

## Status
Acceptée

## Contexte
L'application doit rester maintenable, claire, et évolutive. Pour cela, il est essentiel de bien séparer la logique métier de l’interface console et de l’accès aux données. Une architecture N-tier à 2 couches est donc un bon choix

## Décision
Nous avons choisi de structurer l’application en 2 couches :
- **Présentation** : gestion de l’interface console (menus, saisies, affichages)
- **Persistance** : accès aux données via l’ORM Entity Framework

Chaque couche sera représentée dans un dossier distinct, et les dépendances iront du haut vers le bas (présentation dépend de la logique, qui dépend de la persistance).

## Conséquences
- ✅ Facilite les tests unitaires indépendants de la console ou de la base de données.
- ✅ Meilleure lisibilité et modularité du code.
- ✅ Prépare l’architecture à une éventuelle migration vers une API ou une interface graphique.
- ❗ Requiert plus de code et de structure dès le départ (ex: injection de dépendances).
