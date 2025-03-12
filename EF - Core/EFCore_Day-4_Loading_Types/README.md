# Entity Framework Core : Day - 4 
## Problem Statement:
- Schema
    - Customer
        - Id (Primary Key)
        - Name (string, required)
        - Email (string, required, unique)
        - CreatedDate (DateTime)
        - Navigation Property: Orders (One-to-Many relationship)
    - Order
      - Id (Primary Key)
      - OrderDate (DateTime, required)
      - CustomerId (Foreign Key)
      - IsDeleted (bool, for soft delete)
      - Navigation Properties: Customer (Many-to-One), OrderProducts (Many-to-Many)
    - Product
      - Id (Primary Key)
      - Name (string, required)
      - Price (decimal, required)
      - Stock (int, required)
      - Navigation Property: OrderProducts (Many-to-Many relationship)
    - OrderProduct (Join Table for Many-to-Many relationship)
      - Id (Primary Key)
      - OrderId (Foreign Key)
      - ProductId (Foreign Key)
      - Quantity (int, required)
      - Navigation Properties: Order, Product
- Relationships
  - Customer → Order (One-to-Many)
  - Order → OrderProduct (One-to-Many)
  - Product → OrderProduct (One-to-Many)

## Data Seeding
- Use HasData() in OnModelCreating() to seed initial data for:
  - Customers
  - Products
  - Orders
  - Order-Product relationships
- Dynamically seed orders and order-product relationships in DbContext constructor to simulate real-world data variations.
- Ensure that data seeding does not override existing data when migrations are applied multiple times.

## Eager Loading 
1. Write a LINQ query that retrieves all Customers with their related Orders and OrderProducts in a single query using eager loading.
2. Modify the above query to include only Orders placed in the last 30 days and only Products with stock greater than 20.
3. Write a LINQ query that fetches Products along with the total number of Orders they are associated with using eager loading. Print the result.
4. Using eager loading, write a query that retrieves Orders placed in the last month, including the related Customer but excluding OrderProducts.

## Lazy Loading 
1. Enable lazy loading in your project and demonstrate how accessing the Orders property of a Customer triggers a database query.
2. Write a LINQ query that retrieves Customers with their Orders, ensuring lazy loading is used. Print the result and add logs to display the SQL queries being executed to track performance.
3. Implement a method where lazy loading is combined with conditional logic — for instance, load Orders only if their total amount exceeds $500.

## Explicit Loading 
1. Write a code snippet that retrieves a Customer and explicitly loads their Orders only if the customer’s CreatedDate is within the past year.
2. Write a LINQ query that retrieves Orders without related OrderProducts but allows users to explicitly load OrderProducts on demand. Print the result.
3. Using explicit loading, write a method that retrieves Products and conditionally loads their associated Orders if the product’s Stock is below 10.
4. Write a query that first retrieves Customers eagerly with their Orders, and then uses explicit loading to load OrderProducts for those orders.
 
## Combination Challenges
1. Implement a solution where Orders are fetched with eager loading, but the OrderProducts are loaded lazily only when accessed.
2. Develop a query that efficiently fetches Orders with eager loading but performs explicit loading for OrderProducts where the quantity is greater than 5.
3. Write a method that retrieves a Customer’s Orders eagerly and explicitly loads OrderProducts only if the Customer is marked as “VIP”.

## Output: 
![Screenshot 2025-03-12 171528](https://github.com/user-attachments/assets/c46510c5-95dd-487d-87cd-ea1fb259b746)
![Screenshot 2025-03-12 171507](https://github.com/user-attachments/assets/a471d7d0-3a73-423a-a391-423be600b6fc)

