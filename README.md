# 🎯 AuctionApp

AuctionApp is a Blazor web application that implements an auction system. Users can add bidders, import bidders from files, and determine the winner of the auction based on the set reserve price. The application is built with a modular project structure, containing separate layers for core logic, UI, and testing.

---

## 📂 Project Structure

```bash
.
├── 📁 AuctionApp.sln
├── 📂 AuctionApp.Core/
│   ├── 📁 Models/
│   │   ├── 📄 Bid.cs         # Model representing an individual bid
│   │   ├── 📄 Bidder.cs      # Model representing a bidder and their bids
│   │   └── 📄 Result.cs      # Auction result model
│   ├── 📂 Services/
│   │   └── 📄 AuctionService.cs  # Business logic for determining auction results
│   ├── 📂 Interfaces/
│   │   └── 📄 IAuctionService.cs # Auction service interface
│   └── 🗂️  Core.csproj        # Core library project
│
├── 📂 AuctionApp.UI/
│   ├── 📂 Pages/
│   │   ├── 📄 Index.razor           # Homepage of the application
│   │   └── 📄 AuctionResults.razor  # Page to display auction results
│   ├── 📂 Shared/
│   │   └── 📄 MainLayout.razor      # Default layout for the application
│   ├── 🌐 wwwroot/                  # Public/static assets like CSS, images
│   ├── 📄 Program.cs                # Entry point of the Blazor application
│   └── 🗂️  AuctionApp.UI.csproj      # UI project for the application
│
├── 📂 AuctionApp.Tests/
│   ├── 📂 Services/
│   │   └── 📄 AuctionServiceTests.cs # Unit tests for the AuctionService
│   ├── 🗂️  AuctionApp.Tests.csproj    # Test project for the application
│
└── 📄 README.md                      # Documentation
```

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
