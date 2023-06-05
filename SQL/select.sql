SELECT P.product_name, C.category_name
FROM Products P
LEFT JOIN ProductCategory PC ON P.product_id = PC.product_id
LEFT JOIN Categories C ON PC.category_id = C.category_id;