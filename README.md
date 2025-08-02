# 📦 Comprehensive Stock, Customer & Order Management System (C\# Windows Forms)

## 🌟 Project Overview

This project is a desktop application developed using C\# Windows Forms, designed to streamline and automate daily operations for small to medium-sized businesses. 🏪 It efficiently manages stock inventory, customer relationships (CRM), and order processing. With its user-friendly interface, this application integrates inventory tracking, customer database management, and quick order creation into a single platform, significantly accelerating workflows and reducing errors. 🚀📊

## ✨ Key Features & Modules

The application is primarily composed of the following core modules:

### 1\. 🏠 Main Menu

  * The central navigation hub and starting point of the application. It provides quick and easy access to all main management modules.
  * **Modules:** "Ürün Ekle" (Add Product) ➕, "Ürün Düzenle/Ara" (Edit/Search Product) ✏️🔍, "Müşteri Ekle" (Add Customer) 🧑‍🤝‍➕, "Müşteri Düzenle/Ara" (Edit/Search Customer) 🧑‍🤝‍✏️🔍, "Sipariş Oluştur" (Create Order) 🛒✍️.

### 2\. ➕ Product Addition Module (UrunKaydi.png, UrunKaydi2.png, UrunKaydi3.png)

  * Used to register new products into the system.
  * **Input Fields:** Product ID 🆔, Product Name 🏷️, Product Brand 🏭, Product Price 💰 (NumericUpDown), Product Quantity 🔢 (NumericUpDown), Product Category 🗂️ (Dropdown - e.g., Entertainment, Technology, Stationery), Product Description 📝.
  * **User Feedback:**
      * Upon successful registration, a confirmation message "Ürün ekleme işlemi başarılı\!" (Product addition successful\!) appears. ✅
      * If required fields are left empty, a warning message "Eksik ürün kaydı." (Missing product entry.) is displayed, ensuring data integrity. ⚠️

### 3\. ✏️🔍 Product Management (Edit/Search) Module (UrunDuzenleme.png to UrunDuzenleme9.png)

  * Used to view, update, search for, or delete existing product inventory.
  * **Search Function:** A search bar "ID'ye göre Ara" (Search by ID) allows for quick searching by Product ID. 🔎
  * **Data Listing:** All product records or search results are presented in a readable DataGridView (table) format. This includes detailed column headers like "Ürün ID" (Product ID), "Ürün Ad" (Product Name), "Ürün Marka" (Product Brand), "Ürün Miktar" (Product Quantity), "Ürün Kategori" (Product Category), "Ürün Açıklama" (Product Description), "Ürün Tarih" (Product Date), and "Ürün Fiyat" (Product Price). 📋
  * **Easy Editing:** When any product is selected in the table, its information automatically loads into the editing fields on the right. Users can easily make changes through these fields. ✍️
  * **Data Management Buttons:**
      * **"Güncelle" (Update):** Saves changes made to product information to the database and confirms with a success message (e.g., "Ürün güncelleme işlemi başarıyla tamamlandı\!" - Product update completed successfully\!). ✅
      * **"Sil" (Delete):** Securely removes the selected product record from the system and provides a confirmation message (e.g., "Ürün silme işlemi başarıyla tamamlandı\!" - Product deletion completed successfully\!). 🗑️
      * **"Temizle" (Clear):** Quickly clears all input fields on the right, preparing for a new operation. 🧹

### 4\. 🧑‍🤝‍➕ Customer Addition Module

  * Used to create new customer profiles.
  * **Input Fields:** Customer ID 🆔, Customer Name 👤, Phone Number 📞, Address 📍, and Email 📧.
  * **User Feedback:** Provides instant feedback on operation success or missing entries. ✅⚠️

### 5\. 🧑‍🤝‍✏️🔍 Customer Management (Edit/Search) Module

  * Used to manage, update, search for, and delete registered customer information.
  * **Search Function:** The "ID'ye göre Ara" (Search by ID) text box allows for immediate searching by Customer ID. 🔎
  * **Comprehensive Listing:** All customer records or search results are displayed in a DataGridView with columns like "Müşteri ID" (Customer ID), "Müşteri Adı" (Customer Name), "Müşteri Telefon" (Customer Phone), "Müşteri Adres" (Customer Address), "Müşteri Email" (Customer Email), and "Müşteri Tarih" (Customer Date). 📋
  * **Easy Editing:** When a customer is selected in the table, their information automatically loads into the editing fields on the right for convenient modification. ✍️
  * **Data Management Buttons:**
      * **"Güncelle" (Update):** Saves changes to customer information and confirms with a success message. ✅
      * **"Sil" (Delete):** Deletes the selected customer record from the system and confirms the successful deletion. 🗑️
      * **"Temizle" (Clear):** Clears all text boxes on the right. 🧹

### 6\. 🛒✍️ Order Creation Module

  * Manages the process of creating new orders for selected customers from available products.
  * **Two-Stage Selection:**
      * **Customer Selection Section:** An upper DataGridView lists and allows searching for customers. Selected customer information is reflected in the fields on the right. 🧑‍🤝‍✅
      * **Product Selection Section:** A lower DataGridView lists and allows searching for products. Selected product details load into the fields on the right, and the "Ürün Adet" (Product Quantity) can be adjusted. 📦✅
  * **Dynamic Total Calculation:** The customer's name and the dynamically calculated total order amount are displayed in the bottom right section. 💲
  * **"Hepsini Temizle" (Clear All):** Resets all customer and product selections and input fields with a single click. 🧹🔄
  * **"Sipariş Ver" (Place Order):** Confirms and places the order with the selected customer and products. A "Sipariş başarılı\!" (Order successful\!) message appears upon completion. 🎉
  * **Invoice Generation & Printing (PDF Export):** After placing an order, the user is offered the option to save the generated invoice as a PDF (e.g., "Fatura.pdf") or print it directly. 📄🖨️ The invoice features a simple and readable structure, including basic information like "Tarih" (Date), "Müşteri" (Customer) details, ordered products (quantity, product name, price), and the "Tutar" (Total Amount). 🧾

## 💻 Technical Stack

  * **Programming Language:** C\#
  * **User Interface (GUI):** Windows Forms (WinForms)
  * **Database Management System:** Microsoft SQL Server (MSSQL) 💾
  * **Database Connectivity:** ADO.NET (customizable via the `Connection.cs` file) 🔗

## 🚀 Setup & Running Instructions

To get this project up and running on your system, please follow these steps:

1.  **MSSQL Database Setup:**

      * Navigate to the "Veritabani" folder within the project directory. 📁
      * Execute the SQL script (e.g., the `.sql` file) on your Microsoft SQL Server instance to create the necessary database tables. This script contains all the required table structures and initial data, if any, for the application. 🛠️

2.  **Update Connection String:**

      * Go to the `UrunSatis` folder within the project files. 📂
      * Open the `Connection.cs` file using a text editor or Visual Studio. 📝
      * Update the existing database connection string within this file to match your MSSQL server's connection details (Server Name, Database Name, Authentication Information, etc.). For example:
        ```csharp
        "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True;" 
        // OR for SQL Server authentication:
        "Data Source=YourServerName;Initial Catalog=YourDatabaseName;User ID=YourUsername;Password=YourPassword;"
        ```
      * Save the changes. 💾

3.  **Run the Project:**

      * Open Visual Studio. 🖥️
      * Open the project solution file (`.sln` extension). 📂
      * Build the solution. 🏗️
      * Run the application (Start Debugging or Ctrl+F5). ▶️

## 🎯 Use Cases

This application is an ideal solution for small businesses, boutiques, freelancers, and individual e-commerce entrepreneurs who need to systematically record their products and customers, track current inventory, and quickly create orders. Its ease of use and essential functionality contribute significantly to the digitalization of business processes. 📈✨
