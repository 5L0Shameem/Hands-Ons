CREATE DATABASE StoreDb
GO

USE StoreDb
GO

CREATE TABLE customers(
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50)
)

CREATE TABLE orders(
order_id INT PRIMARY KEY,
customer_id INT,
order_date DATE,
order_status INT,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
)

INSERT INTO customers VALUES
(1,'John','David'),
(2,'Sara','Ali'),
(3,'Michael','Smith')

INSERT INTO orders VALUES
(101,1,'2026-03-01',1),
(102,2,'2026-03-05',4),
(103,3,'2026-03-07',2)

SELECT c.first_name, c.last_name, o.order_id, o.order_date, o.order_status
FROM customers c
INNER JOIN orders o ON c.customer_id = o.customer_id
WHERE o.order_status IN (1,4)
ORDER BY o.order_date DESC