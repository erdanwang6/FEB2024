--1. List all cities that have both Employees and Customers.
select distinct e.City
from Employees e JOIN Customers c on e.City=c.City

--2. List all cities that have Customers but no Employee.

--a.      Use sub-query
SELECT c.City
FROM Customers c
WHERE c.City NOT IN (Select e.City 
                     from Employees e) 

--b.      Do not use sub-query
SELECT c.City
FROM Customers c LEFT JOIN Employees e ON e.City=c.City
WHERE EmployeeID IS NULL

--3. List all products and their total order quantities throughout all orders.

SELECT p.ProductName, SUM(od.Quantity) AS TotalOrderQuant
FROM Products p JOIN [Order Details] od ON p.ProductID=od.ProductID
GROUP BY od.ProductID, p.ProductName

--4. List all Customer Cities and total products ordered by that city.

SELECT c.City, SUM(od.Quantity) AS ProductTotal
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON od.OrderID=o.OrderID
GROUP BY c.City

--5. List all Customer Cities that have at least two customers.

--a.      Use union

SELECT City FROM Customers
EXCEPT
SELECT City FROM customers
GROUP BY City
HAVING COUNT(*)=1
UNION
SELECT City FROM Customers
GROUP BY City
HAVING COUNT(*)=0

--b.      Use sub-query and no union
SELECT temp.City
FROM (select city, COUNT(city) as NumOfCustomer from Customers GROUP BY City) temp
where temp.NumOfCustomer > 1

--6.List all Customer Cities that have ordered at least two different kinds of products.

select temp.city, COUNT(temp.City) as KindsOfProducts
from 
(SELECT c.City, od.ProductID
from Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON od.OrderID=o.OrderID
GROUP BY c.City, od.ProductID) as temp
GROUP by temp.City
HAVING COUNT(temp.City) > 1

--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT c.CompanyName, c.City, o.ShipCity
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID AND c.City<>o.ShipCity

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH ProductQuantities AS (
    SELECT 
        p.ProductID,
        p.ProductName,
        SUM(od.Quantity) AS TotalQuantity,
        AVG(od.UnitPrice) AS AveragePrice
    FROM [Order Details] od
    JOIN Products p ON od.ProductID = p.ProductID
    GROUP BY p.ProductID, p.ProductName
),
MaxCityOrders AS (
    SELECT 
        pq.ProductID,
        c.City,
        SUM(od.Quantity) AS CityQuantity
    FROM [Order Details] od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    JOIN ProductQuantities pq ON od.ProductID = pq.ProductID
    GROUP BY pq.ProductID, c.City
),
RankedCities AS (
    SELECT 
        ProductID,
        City,
        CityQuantity,
        RANK() OVER(PARTITION BY ProductID ORDER BY CityQuantity DESC) AS CityRank
    FROM MaxCityOrders
)
SELECT TOP 5
    pq.ProductName,
    pq.AveragePrice,
    rc.City
FROM ProductQuantities pq
JOIN RankedCities rc ON pq.ProductID = rc.ProductID
WHERE rc.CityRank = 1
ORDER BY pq.TotalQuantity DESC

--9. List all cities that have never ordered something but we have employees there.

--a.      Use sub-query
SELECT DISTINCT e.City
FROM Employees e
JOIN Customers c ON e.City = c.City
WHERE c.City NOT IN (
    SELECT DISTINCT c.City
    FROM Orders o
    JOIN Customers c ON o.CustomerID = c.CustomerID
)


--b.      Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
JOIN Customers c ON e.City = c.City
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT TOP 1 e.City, COUNT(o.OrderID) AS TotalOrders
FROM Employees e
JOIN Orders o ON e.EmployeeID = o.EmployeeID
GROUP BY e.City
ORDER BY TotalOrders DESC

SELECT TOP 1 c.City, SUM(od.Quantity) AS TotalQuantity
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.City
ORDER BY TotalQuantity DESC

--11. How do you remove the duplicates record of a table?
--Ans: Use UNION to remove the duplicates