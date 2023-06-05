CREATE TABLE Products
(
    product_id   INT PRIMARY KEY,
    product_name CHAR(50) NOT NULL,
);
CREATE TABLE Categories
(
    category_id   INT PRIMARY KEY,
    category_name CHAR(50) NOT NULL,
);
CREATE TABLE ProductCategory
(
    product_category_id INT PRIMARY KEY,
    product_id          INT,
    category_id         INT,
    CONSTRAINT products_fk FOREIGN KEY (product_id) REFERENCES Products (product_id),
    CONSTRAINT categories_fk FOREIGN KEY (category_id) REFERENCES Categories (category_id)
);

INSERT INTO Products(product_id, product_name)
VALUES (1, 'product_1'),
       (2, 'product_2'),
       (3, 'product_3');

INSERT INTO Categories(category_id, category_name)
VALUES (1, 'category_1'),
       (2, 'category_2'),
       (3, 'category_3');

INSERT INTO ProductCategory(product_category_id, product_id, category_id)
VALUES (1, 1, 1),
       (2, 1, 2),
       (3, 1, 3),
       (4, 2, 1);