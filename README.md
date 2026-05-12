# SmartShopppingAssistan# Smart Shopping Assistant

An intelligent e-commerce Web API developed with ASP.NET Core. This project goes beyond a standard shopping cart by integrating a **Multi-Agent AI System** that actively helps users save money, discover complementary products, and maximize active promotions.

## Key Features

* **Core E-Commerce API:** Full CRUD operations for Products, Categories, and Cart Management.
* **Dynamic Promotions:** Applies cart-level and quantity-based discounts automatically.
* **Agentic AI Integration:**
  * **Promotion Checker Agent:** Analyzes the current cart against available promotions and identifies "near-misses" (e.g., "Add one more item to get 10% off").
  * **Suggestion Composer Agent:** Uses LLMs to suggest 1-5 highly relevant products based on the user's cart contents, available categories, and near-miss promotion logic.

## Tech Stack

* **Framework:** .NET 8 (ASP.NET Core Web API)
* **Database:** Entity Framework Core (SQL Server)
* **Architecture:** N-Tier (Controllers, Business Logic Services, Repositories, DTOs)
* **AI Integration:** OpenAI API / LLM Prompting for intelligent decision-making
