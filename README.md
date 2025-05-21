# 🛒 LABO 1 — LOG430 | Système client-serveur avec persistance PostgreSQL

## 📦 Répo GitHub (public)
- https://github.com/itsahmed98/log430-lab1

---

## 📝 Brève description de l’application

Ce projet est une application console C# (.NET 8) qui simule le fonctionnement de plusieurs caisses d’un commerce. Chaque instance du client interagit avec une base de données PostgreSQL partagée, et permet d’effectuer les opérations suivantes :

- Rechercher un produit (`CU01`)
- Enregistrer une vente (`CU02`)
- Gérer un retour de produit (`CU03`)
- Consulter l’état du stock (`CU04`)

L’architecture suit une approche client-serveur distribuée conteneurisée avec Docker et orchestrée avec Docker Compose.

---

## ✅ Fonctionnalités principales (Cas d’utilisation)

| Code | Fonction                                             |
|------|------------------------------------------------------|
| CU01 | Rechercher un produit (par ID, nom ou catégorie)     |
| CU02 | Enregistrer une vente et diminuer le stock           |
| CU03 | Gérer un retour produit et augmenter le stock        |
| CU04 | Consulter l’état du stock en temps réel              |

---

## 🧪 Suite de tests

Le projet contient un dossier `client.Tests` avec des tests unitaires pour :

- ✅ ProduitService
- ✅ VenteService
- ✅ RetourService

### Pour les exécuter :
```bash
cd client.Tests
dotnet test

```

## 🧱 Structure du projet

```plaintext

log430-lab1/
│
├── client/                  # Projet console principal (.NET 8)
│   ├── Program.cs           # Menu principal
│   ├── Models/              # Entités EF Core (Produit, Vente, etc.)
│   ├── Data/                # DbContext EF Core + Factory
│   ├── Services/            # Logique métier par CU
│   ├── Migrations/          # Migrations EF Core appliquées
│
├── client.Tests/            # Projet de tests unitaires (xUnit)
│   ├── ProduitServiceTests.cs
│   ├── VenteServiceTests.cs
│   └── RetourServiceTests.cs
│
├── docs/
│   ├── ADR/                 # Décisions d'architecture (format ADR)
│   ├── UML/                 # Vues UML PlantUML (logique, déploiement, etc.)
│   ├── BesoinsDuClient.md
│   └── Cas-utilisations.md
│
├── Dockerfile               # Dockerfile du client
├── docker-compose.yml       # Orchestration client + db
├── .github/workflows/ci.yml # CI/CD GitHub Actions
└── README.md
```
---

## ⚙️ Architecture du projet et technologies

L'application suit une architecture 2 tier client-servier :

✅ Application console en C# (.NET 8)
✅ Persistance avec Entity Framework Core (ORM)
✅ Base de données PostgreSQL
✅ Tests unitaires avec xUnit
✅ Conteneurisation avec Docker
✅ Orchestration multi-service avec Docker Compose
✅ Déploiement CI/CD automatique via GitHub Actions
✅ Image publiée sur Docker Hub
---

## 🛠️ Étapes d’installation et d’exécution

### ✅ 1. Cloner le dépôt et aller dans le fichier racine
    - git clone https://github.com/itsahmed98/log430-lab1.git
    - cd log430-lab1

### ✅ 2. Lancer l'application avec docker compose
    - docker compose up --build -d
    L’application va démarrer une instance du client console + PostgreSQL

--- 

## 📦 Image Docker Hub
Les images sont disponible ici: https://hub.docker.com/u/ahmedsherif98

pour récupèrer une imgage (ex: log430-lab0-api)
    - docker pull ahmedsherif98/log430-lab0-api:latest
    - docker run -d -p 8080:80 ahmedsherif98/log430-lab0-api

## 🚀 CI/CD — Pipeline
 - https://github.com/itsahmed98/log430-lab1/actions

Le pipeline CI/CD :
1. Restaure les dépendances
2. Vérifie la mise en forme du code (Linting)
3. Lance les tests unitaires (avec xunit)
4. Construit l’image Docker
5. Publie l’image sur Docker Hub (avec un tag par defaut "latest")
    - `https://hub.docker.com/r/ahmedsherif98/log430-lab1-client`

    Pour la tirer manuellement:
    
    ```bash
    docker pull ahmedsherif98/log430-lab1-client:latest
    docker run ahmedsherif98/log430-lab1-client
    ```

## 👨‍💻 Auteur
Ahmed Akram Sherif
Étudiant au baccalauréat en génie logiciel
Cours : LOG430 — Été 2025