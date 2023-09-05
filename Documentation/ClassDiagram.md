# ArtisanGemstoneIMS

## Class Diagram

```mermaid
classDiagram
    AuditableEntity <|-- Product
    AuditableEntity <|-- Address
    AuditableEntity <|-- Customer
    AuditableEntity <|-- Inventory
    AuditableEntity <|-- InventorySnapshot
    AuditableEntity <|-- SalesOrder
    Product -- LineItem
    Product *-- Inventory
    Product -- InventorySnapshot
    Customer -- Address
    SalesOrder *-- LineItem
    SalesOrder o-- Customer
    class AuditableEntity {
        +Guid Id
        +DateTime CreatedAt
        +DateTime UpdatedAt
    }
    class Product {
        +string Sku
        +string Name
        +string Description
        +double Price
        +string ImageUrl
        +bool IsArchived
        +GetAll() IReadOnlyList~Product~
        +GetUnArchived() IReadOnlyList~Product~
        +GetById(Guid id) Product
        +Create(Product product)
        +Update(Product product)
        +Archive(Guid id)
    }
    class Address {
        +string AddressLine1
        +string AddressLine2
        +string City
        +string State
        +string PostalCode
        +string Country
        +GetAll() IReadOnlyList~Address~
        +GetById(Guid id) Address
        +Create(Address address)
        +Update(Address address)
        +Delete(Guid id)
    }
    class Customer {
        +string FirstName
        +string LastName
        +Address PrimaryAddress
        +Guid PrimaryAddressId
        +string PhoneNumber
        +string Email
        +GetAll() IReadOnlyList~Customer~
        +GetById(Guid id) Customer
        +Create(Customer customer)
        +Update(Customer customer)
        +Delete(Guid id)
    }
    class Inventory {
        +Product product
        +Guid ProductId
        +int QuantityOnHand
        +int IdealQuantity
        +GetCurrent() IReadOnlyList~Inventory~
        +GetLowStock() IReadOnlyList~Inventory~
        +GetByProductId(Guid id) Inventory
        +UpdateUnitsAvailable(Guid id, int adjustment)
        +UpdateIdealQuantity(Guid id, int adjustment)
        +GetSnapshotHistory(int numberOfDays) IReadOnlyList~InventorySnapshot~
    }
    class InventorySnapshot {
        +Product Product
        +Guid ProductId
        +DateTime SnapshotTime
        +int SnapshotQuantity
    }
    class SalesOrder {
        +string SONumber
        +Customer Customer
        +Guid CustomerId
        +bool IsPaid
        +double TotalCost
        +ICollection~LineItem~ LineItems
        +GetOpenOrders() IReadOnlyList~SalesOrder~
        +GetClosedOrders() IReadOnlyList~SalesOrder~
        +GetById(Guid id) SalesOrder
        +MarkFulfilled(Guid id)
        +GenerateOrder(SalesOrder order) 
    }
    class LineItem {
        +Guid Id
        +int Quantity
        +double UnitPrice
        +Product Product
        +Guid ProductId
    }
```