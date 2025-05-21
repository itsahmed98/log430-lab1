# CU01 - Rechercher un produit
## Description
Ce cas d'utilisation permet à un employé de chercher un produit dans la base de données selon un critère : nom, identifiant ou catégorie.

## Acteurs
AC01 - Employé

## Pré-conditions
L'application console est en cours d'exécution

La base de données est accessible

## Post-conditions
Le ou les produits correspondant(s) au critère de recherche sont affichés

## Flux de base
1. L’employé sélectionne l’option "Rechercher un produit"
2. Il saisit un critère de recherche (ex. : nom ou ID)
3. Le système interroge la base de données
4. Le système affiche les produits correspondant à la recherche

## Flux alternatifs
2a. Si aucun produit n'est trouvé, le système affiche "Aucun résultat trouvé"

## Points d'extensions
Aucun

---

# CU02 - Enregistrer une vente

## Description
Ce cas d'utilisation permet à un employé d’enregistrer une nouvelle vente comprenant un ou plusieurs produits.

## Acteurs
AC01 - Employé

## Pré-conditions
- L'application est démarrée.
- Des produits existent dans le stock.

## Post-conditions
- La vente est sauvegardée dans la base de données.
- Le stock des produits vendus est mis à jour.

## Flux de base
1. L’employé sélectionne l’option "Nouvelle vente".
2. Il entre les produits et quantités vendues.
3. Le système affiche le total de la vente.
4. L’employé confirme la vente.
5. Le système enregistre la vente, met à jour le stock, et affiche une confirmation.

## Flux alternatifs
- 2a. Produit introuvable :
    - 1. Message d'erreur affiché.
    - 2. Retour à l'étape 2.

- 4a. L’employé annule la vente :
    - 1. Le processus est abandonné sans enregistrement.

## Points d'extensions
- Impression d’un reçu
- Gestion des paiements

---

# CU03 - Gérer un retour

## Description
Ce cas d'utilisation permet à un employé d’enregistrer le retour d’un ou plusieurs produits d’une vente précédente.

## Acteurs
AC01 - Employé

## Pré-conditions
- Une vente valide existe.
- L’application est démarrée.

## Post-conditions
- Le retour est enregistré.
- Le stock des produits retournés est ajusté.

## Flux de base
1. L’employé sélectionne "Retour produit".
2. Il entre l’identifiant de la vente.
3. Le système affiche les détails de la vente.
4. L’employé sélectionne les produits à retourner.
5. Le retour est enregistré, le stock est mis à jour.

## Flux alternatifs
- 2a. Vente introuvable :
    - 1. Message d’erreur affiché.
    - 2. Retour à l’étape 1.

- 4a. Aucun produit sélectionné :
    - 1. Retour annulé.

## Points d'extensions
- Enregistrement d’une raison de retour.
- Génération d’un bon de retour.

---

# CU04 - Consulter le stock

## Description
Ce cas d'utilisation permet à un employé de consulter le stock des produits disponibles.

## Acteurs
AC01 - Employé

## Pré-conditions
- L’application est démarrée.

## Post-conditions
- Le stock est affiché à l’écran.

## Flux de base
1. L’employé sélectionne "Consulter le stock".
2. Le système interroge la base de données.
3. Les produits avec leurs quantités disponibles sont affichés.

## Flux alternatifs
- Aucun

## Points d'extensions
- Tri du stock par catégorie, prix ou quantité.