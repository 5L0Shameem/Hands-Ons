CREATE DATABASE AutoRetailDB
GO

USE AutoRetailDB
GO

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(100)
)
GO

CREATE TABLE Stocks(
ProductID INT PRIMARY KEY,
StockQuantity INT,
FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
)
GO

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
OrderDate DATE
)
GO

CREATE TABLE Order_Items(
OrderItemID INT PRIMARY KEY,
OrderID INT,
ProductID INT,
Quantity INT,
FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
)
GO

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN
IF EXISTS(
SELECT 1
FROM inserted i
JOIN Stocks s ON i.ProductID = s.ProductID
WHERE s.StockQuantity < i.Quantity
)
BEGIN
RAISERROR('Insufficient stock. Order cannot be processed.',16,1)
ROLLBACK TRANSACTION
RETURN
END

UPDATE s
SET s.StockQuantity = s.StockQuantity - i.Quantity
FROM Stocks s
JOIN inserted i
ON s.ProductID = i.ProductID
END
GO

INSERT INTO Products VALUES (1,'Car Battery')
INSERT INTO Products VALUES (2,'Engine Oil')
GO

INSERT INTO Stocks VALUES (1,20)
INSERT INTO Stocks VALUES (2,50)
GO

BEGIN TRY
BEGIN TRANSACTION

INSERT INTO Orders VALUES (1,GETDATE())

INSERT INTO Order_Items VALUES (1,1,1,5)

COMMIT TRANSACTION

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Order failed due to insufficient stock'
END CATCH
GO

SELECT * FROM Stocks
GO