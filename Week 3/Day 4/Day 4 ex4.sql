CREATE DATABASE OrderManagementDb
GO

USE OrderManagementDb
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
    shipped_date DATE,
    required_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
)

-- Archived table
CREATE TABLE archived_orders(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    shipped_date DATE,
    required_date DATE,
    order_status INT
)

-- Sample Data
INSERT INTO customers VALUES
(1,'John','Doe'),
(2,'Sara','Ali'),
(3,'Michael','Smith')

INSERT INTO orders VALUES
(101,1,'2025-02-01','2025-02-05','2025-02-07',4),
(102,1,'2024-12-10','2024-12-12','2024-12-15',3),
(103,2,'2024-03-15','2024-03-20','2024-03-18',3),
(104,3,'2026-01-10','2026-01-12','2026-01-15',4)

-- 1. Archive orders older than 1 year or rejected
INSERT INTO archived_orders(order_id, customer_id, order_date, shipped_date, required_date, order_status)
SELECT order_id, customer_id, order_date, shipped_date, required_date, order_status
FROM orders
WHERE order_status = 3
   OR order_date < DATEADD(YEAR, -1, GETDATE())

-- 2. Delete rejected orders older than 1 year
DELETE FROM orders
WHERE order_status = 3
  AND order_date < DATEADD(YEAR, -1, GETDATE())

-- 3. Identify customers whose all orders are completed (status = 4)
SELECT customer_id, CONCAT(c.first_name,' ',c.last_name) AS full_name
FROM customers c
WHERE customer_id NOT IN (
    SELECT customer_id 
    FROM orders 
    WHERE order_status <> 4
)

-- 4. Display order processing delay and mark Delayed/On Time
SELECT order_id,
       customer_id,
       DATEDIFF(DAY, order_date, shipped_date) AS processing_delay_days,
       CASE 
           WHEN shipped_date > required_date THEN 'Delayed'
           ELSE 'On Time'
       END AS order_status_label
FROM orders