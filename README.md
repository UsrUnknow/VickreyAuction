# 🎯 AuctionApp

AuctionApp is a Blazor web application that implements an auction system. Users can add bidders, import bidders from files, and determine the winner of the auction based on the set reserve price. The application is built with a modular project structure, containing separate layers for core logic, UI, and testing.

---

## 📂 Project Structure

```bash
usrunknow-vickreyauction/
├── 📄 README.md
│   └── 📝 Principal documentation file explaining the project setup and usage.
├── 🗂️  VickreyAuction.sln
│   └── 🛠 Solution file to manage and build the entire project.
├── 📂 Core/
│   ├── 📂 Models/
│   │   ├── 📄 Bid.cs
│   │   │   └── 🏷 Represents a bid, including bid amount and bidder details.
│   │   ├── 📄 Bidder.cs
│   │   │   └── 👤 Represents a bidder and their associated bids.
│   │   └── 📄 Result.cs
│   │       └── 🏆 Models auction results (winner, amount, etc.).
│   └── 📂 Services/
│       └── 📄 AuctionService.cs
│           └── ⚙️ Core business logic for managing Vickrey auction behavior.
├── 📂 Tests/
│   └── 📄 AuctionServiceTests.cs
│       └── ✅ Key unit tests to verify the correctness of auction logic (edge cases, functionalities).
└── 📂 UI/
    ├── 📄 Program.cs
    │   └── 🚀 Application entry point for the Blazor app.
    ├── 📂 Pages/
    │   ├── 📄 AddBidderForm.razor
    │   │   └── ➕ Form to add bidders and their bids manually.
    │   ├── 📄 Auction.razor
    │   │   └── 🏆 Displays auction information and results.
    │   ├── 📄 AuctionActions.razor
    │   │   └── ⚙️ Provides functionality to start/reset the auction.
    │   └── 📄 BidderList.razor
    │       └── 👥 Displays the list of bidders and their respective bids.
    ├── 📄 appsettings.json
    │   └── 🔧 Primary configuration file for the app (environments, defaults).
    └── 📂 wwwroot/
        ├── 🎨 app.css
        │   └── 💅 Styles to control the appearance of the app.
        └── 🌐 bootstrap/
            └── 🎨 Bootstrap framework for consistent and responsive design.

```
   - Légende :
     - 📁/📂 : Indiquent les dossiers et sous-dossiers.
     - 📄 : Représente les fichiers ordinaires comme `.cs`, `.json` et `.razor`.
     - ✨/🎨 : Utilisé pour les fichiers de style ou de mise en page (`CSS`, layout).
     - ✅/❌ : Ajouté aux tests ou fichiers d'erreurs pour clarifier leur rôle.
     - 🔧/⚙️/🛠 : Sont utilisés pour les fichiers de configuration ou de logique.
---

## ✨ Features

### 🛒 Auction Functionality
- Users can:
  - ➕ Add new bidders through a form.
  - 📤 Import bidders from JSON or CSV files.
  - 👀 View the list of bidders and their bids.
  - 🏆 Run an auction with a reserve price.

- The service determines the winner based on:
  - 🥇 The highest valid bid (greater than or equal to the reserve price).
  - 🔄 In the case of a tie, the earliest bidder wins.

---

## 🛠 Usage

### Local Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repository/AuctionApp.git
   ```
2. Navigate to the solution folder:
   ```bash
   cd AuctionApp
   ```
3. Build the solution:
   ```bash
   dotnet build
   ```

### Run the Application
1. Navigate to the UI project:
   ```bash
   cd AuctionApp.UI
   ```
2. Start the application:
   ```bash
   dotnet run
   ```
3. Open your browser and navigate to:
   ```
   https://localhost:5001
   ```

---

## 🔍 Modules

### 🚀 1. AuctionApp.Core
- Contains the core business logic, models, and services.
- **Key Components:**
  - **Models:**
    - `Bid`: Represents an individual bid with a specific amount.
    - `Bidder`: Represents a participant in the auction with a name and a list of bids.
    - `Result`: Represents the auction result with the winner's name and the price.
  - **Services:**
    - `AuctionService`: Implements auction logic to determine winners.
    - Logic includes filtering bids by reserve price and picking the highest valid bid.
  - **Interfaces:**
    - `IAuctionService`: Interface for the auction service.

### 💻 2. AuctionApp.UI
- Blazor-based user interface for interacting with the auction system.
- **Key Pages:**
  - `Index.razor`: Homepage of the application.
  - `AuctionResults.razor`: Displays the calculated auction results.
- **Key Components:**
  - ➕ **AddBidderForm.razor**: Form for adding new bidders with their bids.
  - 📤 **FileImporter.razor**: Allows importing bidders from JSON/CSV files.
  - 🔄 **AuctionActions.razor**: Provides controls to set a reserve price and start the auction.
  - 👥 **BidderList.razor**: Displays the list of all bidders and their bids.
- Built-in navigation and a clean design for displaying auction functionalities.

### 🧪 3. AuctionApp.Tests
- Contains unit tests to verify the correctness of the auction logic.
- **Key Test Class:**
  - `AuctionServiceTests`: Validates `AuctionService` for various edge cases.
- **Key Test Scenarios:**
  - ❌ No valid bids => "No Winner".
  - ✅ A single valid bid => Winner is the only bidder.
  - 🔢 Multiple valid bids => Winner is the bidder with the highest bid.
  - 🔄 Handle ties in bids => Winner is the first valid bidder in case of ties.

---

## 🎯 Example Workflow

1. ➕ Add bidders manually or import them:
   - Use the **Add Bidders Form** to add bidders with their bids.
   - 📤 Import bidders using a JSON or CSV file upload.
     - JSON format:
       ```json
       [
           { "Name": "A", "Bids": [110, 130] },
           { "Name": "B", "Bids": [] },
           { "Name": "C", "Bids": [125] }
       ]
       ```
     - CSV format example:
       ```
       A, 110, 130
       B
       C, 125
       ```
2. Set the reserve price for the auction.
3. 🏁 Click the **Start Auction** button to determine the winner.
4. 🏆 View the results: Winner's name and the final price.

---

## ✅ Testing

Run the test suite to verify the functionality of the `AuctionService`:

1. Navigate to the test project:
   ```bash
   cd AuctionApp.Tests
   ```
2. Run the tests:
   ```bash
   dotnet test
   ```
3. 🚦 The tests will validate edge cases such as:
   - ❌ No valid bids.
   - ✅ Multiple valid bids.
   - 🔄 Tie handling.

---

## 🛠 Technologies Used

- 🧩 **Blazor WebAssembly**: Front-end UI for the application.
- ⚙️ **ASP.NET Core**: Web framework for facilitating server-side rendering.
- 🚀 **.NET 6**: For building the core, UI, and testing libraries.
- 🧪 **xUnit**: For writing unit tests.

---

## 🚀 Future Enhancements

- 🔄 **Add multi-round auctions.**
- 🔒 **Implement login and authentication for user roles.**
- 🏆 **Expand to Vickrey (second-price sealed-bid) auction logic.**
- 📊 **Enhance the UI with bidder statistics.**

---

If you have any issues, questions, or feature requests, please open an issue in the repository. 🎉 Happy bidding!
