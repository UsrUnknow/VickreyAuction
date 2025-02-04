# 🎯 AuctionApp

AuctionApp est une application web **Blazor** qui implémente un système d'enchères. Les utilisateurs peuvent ajouter des enchérisseurs, importer des enchérisseurs depuis des fichiers, et déterminer le gagnant de l'enchère en fonction d'un prix de réserve défini. Le projet est basé sur une architecture modulaire avec une logique métier séparée et des tests.

---

## 📂 Structure du Projet

```bash
vickreyauction/
├── 📄 README.md
│   └── 📝 Documentation principale expliquant la configuration et l’utilisation du projet.
├── 🗂️  VickreyAuction.sln
│   └── 🛠 Fichier solution pour gérer et compiler l’ensemble du projet.
├── 📂 Core/
│   └── 📄 Logique métier pour gérer les enchères (modèles et services).
├── 📂 UI/
│   └── 📄 Interface utilisateur Blazor pour interagir avec le système d’enchères.
├── 📂 Tests/
│   └── 📄 Tests unitaires pour valider la logique métier.
```

---

## ✨ Fonctionnalités principales

### 🛒 Fonctionnalités d’enchères :
- Les utilisateurs peuvent :
    - ➕ Ajouter manuellement de nouveaux enchérisseurs via un formulaire.
    - 📤 Importer des enchérisseurs depuis des fichiers JSON ou CSV.
    - 👀 Visualiser la liste des enchérisseurs avec leurs enchères.
    - 🏆 Lancer une enchère avec un prix de réserve défini.

- **Détermination du gagnant** :
    - 🥇 Gagnant : celui qui propose l'enchère la plus élevée parmi les enchères valides (supérieures ou égales au prix de réserve).
    - 🔄 En cas d’égalité sur le montant de l’enchère, le premier enchérisseur dans l'ordre est choisi.

---

## 🚀 Déploiement et Utilisation

### 1. Prérequis : Installation de l’environnement .NET

Pour configurer et exécuter ce projet, vous aurez besoin :
- **SDK .NET 8.0 et Runtime ASP.NET Core 8.0**.  
  Téléchargez et installez-le depuis :  
  👉 [Lien vers l'installation .NET 8](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux&pivots=dotnet-8-0)

Vous pouvez vérifier la version installée via :

```bash
dotnet --version
```

Assurez-vous que la version indiquée correspond bien à **`8.x`**.

---

### 2. Mise en place locale

1. Clonez le repository :
   ```bash
   git clone https://github.com/your-repository/AuctionApp.git
   ```

2. Naviguez jusqu’au dossier du projet :
   ```bash
   cd AuctionApp
   ```

3. Compilez la solution :
   ```bash
   dotnet build
   ```

---

### 3. Exécuter l'application

1. Placez-vous dans le dossier UI contenant l’application Blazor :
   ```bash
   cd UI
   ```

2. Lancez l’application :
   ```bash
   dotnet run
   ```

3. Ouvrez un navigateur et accédez à l’URL :
   ```
   http://localhost:5068
   ```
   ou en HTTPS :
   ```
   https://localhost:5068
   ```

---

### 4. Exécution via Docker

Si vous ne souhaitez pas installer l’environnement localement, vous pouvez utiliser Docker :
1. **Vérifiez que Docker est installé** : [Installation de Docker](https://docs.docker.com/get-docker/)
2. Clonez le repository :
   ```bash
   git clone https://github.com/your-repository/AuctionApp.git
   ```

3. Naviguez jusqu’au dossier racine du projet :
   ```bash
   cd AuctionApp
   ```

4. Lancez l'application au moyen de Docker Compose :
   ```bash
   docker-compose up --build
   ```

   Cette commande effectuera les étapes suivantes :
    - Construira l'image (basée sur le fichier **`Dockerfile`** situé dans le dossier `UI`).
    - Liera automatiquement les ports nécessaires pour accéder au projet.

5. Accédez à l'application via votre navigateur :
   ```
   http://localhost:8080
   ```
   ou en HTTPS :
   ```
   https://localhost:8081
   ```

---

### 5. Gestion simplifiée avec Docker Compose

Pour arrêter ou redémarrer l'application, vous pouvez utiliser les commandes suivantes :

- **Arrêter les conteneurs en cours d'exécution** :
   ```bash
   docker-compose down
   ```

- **Redémarrer après modification** :
   ```bash
   docker-compose up --build
   ```

---


## ✅ Tests

### Tester les cas d’utilisation :
Le projet inclut des scénarios d’utilisation directement dans les tests.

1. **Exécutez les tests unitaires** :
   ```bash
   dotnet test
   ```

2. Les cas testés incluent :
    - ❌ Aucun enchérisseur valide → Retour attendu : "Aucun gagnant", et le prix payé est le prix de réserve.
    - ✅ Une seule enchère valide → Le gagnant est l’enchérisseur ayant cette enchère, mais il paiera soit la deuxième enchère valide (si disponible), soit le prix de réserve.
    - 🔢 Plusieurs enchérisseurs valides → Le gagnant est celui avec la plus haute enchère valide, mais il paiera la deuxième meilleure enchère valide (ou le prix de réserve si aucune n'est disponible).
    - 🔄 Cas d'égalité → En cas d'égalité sur la plus haute enchère, le gagnant est déterminé par l'ordre de priorité (le premier enchérisseur dans la liste).
    - 🏷️ Aucun second prix valide disponible → Si le gagnant est le seul enchérisseur valide ou qu'aucune autre enchère ne dépasse le prix de réserve, le gagnant paie le prix de réserve.


3. **Ajouter des cas d’utilisation directs dans les tests** :
    - Par exemple : Ajouter des enchérisseurs avec des enchères précises, y compris des égalités ou des enchères inférieures au prix de réserve, et vérifier que le gagnant et le prix payé respectent la logique d'enchères au second prix.

---

## ✨ Workflow Exemple

1. ➕ **Ajouter des enchérisseurs** :
    - Utilisez le formulaire intégré pour ajouter un enchérisseur avec une ou plusieurs enchères.
    - Importer des fichiers JSON ou CSV :
        - **Format JSON Exemple** :
          ```json
          [
              { "Name": "John", "Bids": [150, 200] },
              { "Name": "Alice", "Bids": [180] }
          ]
          ```
        - **Format CSV Exemple** :
          ```
          Name,Bid1,Bid2
          John,150,200
          Alice,180
          ```

2. 📊 **Définir le prix de réserve** :
    - Spécifiez le montant minimum dans l’interface de l’enchère.

3. 🏆 Lancez l'enchère et analysez les résultats.

---

## 🧪 Technologies utilisées

- 🧩 **Blazor WebAssembly** : Interface Web pour l'application.
- ⚙️ **ASP.NET Core** : Hébergement et gestion des appels serveur.
- 🚀 **.NET 8.0** : Framework principal pour l'application.
- 🧪 **xUnit** : Tests unitaires intégrés pour valider la logique.

---

## 🔄 Améliorations futures

1. 🔒 **Ajouter une authentification** :
    - Gestion des rôles utilisateur (enchérisseur, administrateur).
2. 📊 **Statistiques enrichies** :
    - Afficher des tableaux de bord détaillés pour les enchères, y compris :
        - Nombre total d'enchérisseurs.
        - Évolution des enchères par utilisateur.
        - Analyse des enchères gagnantes (second prix, prix final).
3. 🛠 **Améliorer la gestion des imports** :
    - Ajouter un outil avancé pour importer/enregistrer des enchérisseurs et enchères via des fichiers JSON ou CSV avec validation en temps réel.
4. 📤 **Exporter les résultats des enchères** :
    - Générer des rapports détaillés (en PDF ou Excel) pour chaque enchère, incluant le gagnant, le prix payé, et la liste des enchères valides.

---

Si vous rencontrez des problèmes, des questions ou souhaitez demander des fonctionnalités supplémentaires, veuillez ouvrir un ticket dans le dépôt. 🎉 Bonnes enchères !