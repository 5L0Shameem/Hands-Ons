CREATE DATABASE CompanySalesDB
GO

USE CompanySalesDB
GO

CREATE TABLE Stores(
StoreID INT PRIMARY KEY,
StoreName VARCHAR(100)
)
GO

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(100),
Price DECIMAL(10,2)
)
GO

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
StoreID INT,
OrderDate DATE,
Discount DECIMAL(5,2),
FOREIGN KEY(StoreID) REFERENCES Stores(StoreID)
)
GO

CREATE TABLE OrderItems(
OrderItemID INT PRIMARY KEY,
OrderID INT,
ProductID INT,
Quantity INT,
UnitPrice DECIMAL(10,2),
FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
)
GO

CREATE FUNCTION fn_TotalPriceAfterDiscount
(
@Price DECIMAL(10,2),
@Discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @FinalPrice DECIMAL(10,2)

IF @Discount IS NULL
SET @Discount = 0

SET @FinalPrice = @Price - (@Price * @Discount / 100)

RETURN @FinalPrice
END
GO

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
p.ProductID,
p.ProductName,
SUM(oi.Quantity) AS TotalSold
FROM OrderItems oi
JOIN Products p ON oi.ProductID = p.ProductID
GROUP BY p.ProductID,p.ProductName
ORDER BY TotalSold DESC
)
GO

CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
SELECT
s.StoreID,
s.StoreName,
SUM(oi.Quantity * oi.UnitPrice) AS TotalSales
FROM Stores s
LEFT JOIN Orders o ON s.StoreID = o.StoreID
LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
GROUP BY s.StoreID,s.StoreName
END
GO

CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
SELECT
OrderID,
StoreID,
OrderDate,
Discount
FROM Orders
WHERE OrderDate BETWEEN @StartDate AND @EndDate
END
GO

EXEC sp_TotalSalesPerStore
GO

EXEC sp_GetOrdersByDateRange '2024-01-01','2024-12-31'
GO

SELECT dbo.fn_TotalPriceAfterDiscount(1000,10)
GO

SELECT * FROM fn_Top5SellingProducts()
GO