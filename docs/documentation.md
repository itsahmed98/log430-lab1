# 1. Introduction et buts

## 1.1 Apercu des exigences

Cette application simule les operations d'une caisse dans un magasin. Les opérations sont:

1. Rechercher un produit (CU01)
2. Enregistrer une vente (CU02)
3. Gérer un retour produit et augmenter le stock (CU03)
4. Consulter l'état du stock en temps réel (CU04)

## 1.2 Qualité à atteindre

| Priorité | Attribut de qualité | Description                                                                  |     |
| -------- | ------------------- | ---------------------------------------------------------------------------- | --- |
| 1        | Fiabilité           | Assurer un traitement des opérations et la cohérence des données.            |     |
| 2        | Performance         | Assurer une rapidité dans les opérations.                                    |     |
| 3        | Scalabilité         | Prendre en charge plusieurs instances clientes simultanées sans dégradation. |     |
| 4        | Maintenabilité      | Faciliter les mises à jour et les améliorations du code.                     |     |

## 1.3 Parties prenantes

| Rôle         | Nom                 | Attentes                                              |     |
| ------------ | ------------------- | ----------------------------------------------------- | --- |
| Développeur  | Ahmed               | Architecture claire pour guider le développement.     |
| Utilisateurs | Employés du magasin | Interface intuitive pour les opérations quotidiennes. |

---

# 2 Contraintes

-   Développé en C# avec .NET 8.
-   Utilise PostgreSQL pour la persistance des données.
-   Fonctionne en tant qu'application console.
-   Docker est utilisé pour la conteneurisation.

---

# 3 Contexte et portée

## 3.1 Contexte métier

Le système est conçu pour les environnements de vente au détail où plusieurs caisses enregistreuses fonctionnent simultanément, interagissant avec une base de données d'inventaire centralisée.

## 3.2 Contexte technique

Chaque caisse se connecte à une base de données partager pour les opérations CRUD dans un contexte de magasin.

---

# 4 Stratégie de la solution

Implémenter une architecture client-server avec 3 instances du console (caisses) qui sont les clients

Avoir une base de données que les clients partagent et effectuer les opérations CRUD

Utiliser Entity framework core comme ORM pour les interactions avec la BD

# 5. Vue des blocs de construction

Application cliente : Gère les interactions utilisateur et la logique métier.

Base de données : Stocke les informations sur les produits, les enregistrements de ventes et les données d'inventaire.

# 6 Vue d'éxécution

(regarder les diagrammes de séquences pour un exemple d'éxécution)

# 7 Vue de déploiement

L'application est conteneurisée à l'aide de Docker :

Conteneurs clients : Plusieurs instances de l'application cliente (caisse).

Conteneur de base de données : Instance PostgreSQL unique partagée entre les clients.

Docker Compose orchestre le déploiement, assurant une communication transparente entre les conteneurs.

# 8 Conceptes transversaux

# 9 Décision architectural

## ADR#1 Choix des technologies : C#, PostgreSQL, Entity Framework Core

### Status

Acceptée

### Contexte

Je dois développer une application de caisse avec une interface console, une persistance robuste, et une compatibilité avec CI/CD et Docker. Il est nécessaire de choisir un langage, une base de données, et une méthode d’accès aux données (ORM) adaptée.

### Décision

J'ai décidé d’utiliser :

-   Le langage **C#** avec le framework .NET 8, car l’étudiant est déja familier avec ces technologies
-   La base de données relationnelle **PostgreSQL**, car elle est open-source, robuste, compatible avec Docker, et bien supportée par Entity Framework. De plus, l'étudiant possède seulement de l'éxperience avec les bases de données relationnelles en PostgreSQL
-   L’ORM **Entity Framework Core**, car il s’intègre naturellement avec C#/.NET, simplifie les requêtes, gère les migrations, et prend en charge PostgreSQL via le provider `Npgsql`.

### Conséquences

-   ✅ Plus facile à démarrer grâce à l’expérience existante avec C# et .NET.
-   ✅ Intégration fluide dans Docker et dans GitHub Actions.
-   ✅ Meilleure productivité grâce à l’automatisation des migrations EF Core.
-   ❗ Moins d’exposition à d'autres langages ou outils (ex: Java + Hibernate).

---

## ADR#2 Séparation des responsabilités : Présentation et Persistance

### Status

Acceptée

### Contexte

L'application doit rester maintenable, claire, et évolutive. Pour cela, il est essentiel de bien séparer la logique métier de l’interface console et de l’accès aux données. Une architecture N-tier à 2 couches est donc un bon choix

### Décision

J'ai choisi de structurer l’application en 2 couches :

-   **Présentation** : gestion de l’interface console (menus, saisies, affichages)
-   **Persistance** : accès aux données via l’ORM Entity Framework

Chaque couche sera représentée dans un dossier distinct, et les dépendances iront du haut vers le bas (présentation dépend de la logique, qui dépend de la persistance).

### Conséquences

-   ✅ Facilite les tests unitaires indépendants de la console ou de la base de données.
-   ✅ Meilleure lisibilité et modularité du code.
-   ✅ Prépare l’architecture à une éventuelle migration vers une API ou une interface graphique.
-   ❗ Requiert plus de code et de structure dès le départ (ex: injection de dépendances).

# 10 Exigences de qualité

**Arbre de qualité**

Fiabilité: Traitement précis des transactions.

Performance: Temps de réponse rapide pour les actions utilisateur.

Scalabilité: Prise en charge de plusieurs clients simultanés.

Maintenabilité: Base de code modulaire pour des mises à jour faciles.

**Scénarios de qualité**

Scénario 1 : Le système maintient l'intégrité des données lors de transactions de vente simultanées.

Scénario 2 : L'ajout d'une nouvelle fonctionnalité (par exemple, la gestion des remises) nécessite des modifications minimales du code existant.

# 11 Risques et dettes techniques

**Risque**: Une faiblesse d'une architecture client-server (2-tier) est qu'il est non scalable avec l'augmentation des clients. Une augmentation des clients va surcharger la base de données.

**Dette technique**: Ne pas faire la documentation et ecrire le code de n'importe quel maniere et sans tests peut causer de la dette dans le future pour corriger du code ou faire la documjentation.

# 12 Glossaire

| Terme                | Définition                                                               |     |
| -------------------- | ------------------------------------------------------------------------ | --- |
| **CU01**             | Cas d'utilisation 01 : Rechercher un produit.                            |     |
| **CU02**             | Cas d'utilisation 02 : Enregistrer une vente.                            |     |
| **CU03**             | Cas d'utilisation 03 : Traiter un retour de produit.                     |     |
| **CU04**             | Cas d'utilisation 04 : Vérifier les niveaux de stock.                    |     |
| **Entity Framework** | Un mappeur objet-relationnel (ORM) pour .NET.                            |     |
| **Docker Compose**   | Un outil pour définir et gérer des applications multi-conteneurs Docker. |
