CREATE DATABASE OrderValidationDB
GO

USE OrderValidationDB
GO

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerName VARCHAR(100),
OrderDate DATE,
Shipped_Date DATE,
Order_Status INT
)
GO

CREATE TRIGGER trg_ValidateOrderStatus
ON Orders
AFTER UPDATE
AS
BEGIN
BEGIN TRY

IF EXISTS(
SELECT 1
FROM inserted
WHERE Order_Status = 4 AND Shipped_Date IS NULL
)
BEGIN
THROW 50002, 'Order cannot be marked Completed because Shipped_Date is NULL', 1
ROLLBACK TRANSACTION
RETURN
END

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
THROW
END CATCH

END
GO

INSERT INTO Orders VALUES (1,'Ali','2024-01-10',NULL,2)
INSERT INTO Orders VALUES (2,'Sara','2024-01-11','2024-01-12',3)
GO

UPDATE Orders
SET Order_Status = 4
WHERE OrderID = 1
GO

UPDATE Orders
SET Order_Status = 4
WHERE OrderID = 2
GO

SELECT * FROM Orders
GO