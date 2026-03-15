CREATE DATABASE AutoDb
GO

USE AutoDb
GO

CREATE TABLE categories(
category_id INT PRIMARY KEY,
category_name VARCHAR(50)
)

CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(100),
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
)

INSERT INTO categories VALUES
(1,'Sedan'),
(2,'SUV'),
(3,'Truck')

INSERT INTO products VALUES
(101,'Honda Civic',1,2020,20000),
(102,'Toyota Corolla',1,2021,22000),
(103,'Ford Explorer',2,2022,35000),
(104,'Chevy Tahoe',2,2021,40000),
(105,'Ford F-150',3,2023,45000),
(106,'RAM 1500',3,2022,42000)

SELECT 
CONCAT(product_name,' (',model_year,')') AS product_details,
product_name,
model_year,
list_price,
(list_price - 
 (SELECT AVG(p2.list_price) 
  FROM products p2 
  WHERE p2.category_id = p1.category_id)
) AS price_difference
FROM products p1
WHERE list_price >
 (SELECT AVG(p3.list_price) 
  FROM products p3 
  WHERE p3.category_id = p1.category_id)