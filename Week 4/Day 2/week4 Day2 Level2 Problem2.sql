CREATE DATABASE BikeStoreDB
GO

USE BikeStoreDB
GO

CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(100),
quantity INT
)

CREATE TABLE orders(
order_id INT PRIMARY KEY,
order_status INT
)

CREATE TABLE order_items(
order_id INT,
item_id INT,
product_id INT,
quantity INT,
PRIMARY KEY(order_id,item_id),
FOREIGN KEY(order_id) REFERENCES orders(order_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
)

INSERT INTO products VALUES
(1,'Bike',50),
(2,'Helmet',30)

INSERT INTO orders VALUES
(1,1)

INSERT INTO order_items VALUES
(1,1,1,5)

BEGIN TRY
BEGIN TRANSACTION

DECLARE @order_id INT
SET @order_id = 1

SAVE TRANSACTION CancelPoint

UPDATE p
SET p.quantity = p.quantity + oi.quantity
FROM products p
JOIN order_items oi
ON p.product_id = oi.product_id
WHERE oi.order_id = @order_id

IF @@ERROR <> 0
BEGIN
ROLLBACK TRANSACTION CancelPoint
RAISERROR('Stock restore failed',16,1)
END

UPDATE orders
SET order_status = 3
WHERE order_id = @order_id

IF @@ERROR <> 0
BEGIN
ROLLBACK TRANSACTION CancelPoint
RAISERROR('Order update failed',16,1)
END

COMMIT TRANSACTION
PRINT 'Order cancelled and stock restored'

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT ERROR_MESSAGE()
END CATCH
