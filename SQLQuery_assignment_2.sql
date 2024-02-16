--1.How many products can you find in the Production.Product table?

SELECT COUNT(*)
FROM Production.Product

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductSubcategoryID)
FROM Production.Product

--3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.

--ProductSubcategoryID CountedProducts

SELECT ProductSubcategoryID, COUNT(ProductSubcategoryID) as CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID

--4. How many products that do not have a product subcategory.
SELECT COUNT(*)-COUNT(ProductSubcategoryID)
FROM Production.Product

--5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
select productid, SUM(Quantity) as ProductQuantity
FROM    Production.ProductInventory
GROUP BY Productid

--6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

 --             ProductID    TheSum

   --           -----------        ----------


SELECT ProductID, SUM(Quantity) as TheSum
FROM Production.ProductInventory
where LocationID = 40
GROUP BY Productid
HAVING Sum(Quantity) < 100

--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--    Shelf      ProductID    TheSum

--    ----------   -----------        -----------
select shelf, ProductID, sum(Quantity)
from Production.ProductInventory
where LocationID = 40
GROUP BY Shelf,ProductID
HAVING Sum(Quantity) < 100
ORDER BY Shelf

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID, AVG(Quantity) as AvgQuantity
FROM Production.ProductInventory
WHERE LocationID=10
GROUP BY ProductID

--9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

    --ProductID   Shelf      TheAvg

    ----------- ---------- -----------
select ProductID, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory
GROUP BY Shelf,ProductID
ORDER BY Shelf

--10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

    --ProductID   Shelf      TheAvg

    ----------- ---------- -----------
select ProductID, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory
where Shelf <> 'N/A'
GROUP BY Shelf,ProductID
ORDER BY Shelf

--11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

    --Color                        Class              TheCount          AvgPrice

    -------------- - -----    -----------            ---------------------
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class
ORDER BY Color

--12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

    --Country                        Province

    ---------                          ----------------------

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode=s.CountryRegionCode
ORDER BY Country

--13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

 

    --Country                        Province

    ---------                          ----------------------
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode=s.CountryRegionCode
WHERE c.Name='Germany' OR c.Name='Canada'
ORDER BY Country

USE Northwind
GO
--14. List all Products that has been sold at least once in last 26 years.

SELECT distinct p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID=od.OrderID JOIN Products p ON p.ProductID=od.ProductID
WHERE o.OrderDate > '1998-01-01'
ORDER BY p.ProductName

--15. List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 shippostalcode, COUNT(ShipPostalCode) as NumOfSold
FROM Orders
WHERE ShipPostalCode IS NOT NULL
GROUP BY ShipPostalCode
ORDER BY NumOfSold DESC

--16. List top 5 locations (Zip Code) where the products sold most in last 26 years.
SELECT TOP 5 shippostalcode, COUNT(ShipPostalCode) as NumOfSold
FROM Orders
WHERE ShipPostalCode IS NOT NULL AND OrderDate > '1998-01-01'
GROUP BY ShipPostalCode
ORDER BY NumOfSold DESC

--17. List all city names and number of customers in that city. 
SELECT City, COUNT(City) AS NumOfCustomers
FROM Customers
GROUP BY City

--18. List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(City) AS NumOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(City) > 2

--19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.CompanyName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE OrderDate > '1998-01-01'
ORDER BY o.OrderDate

--20. List the names of all customers with most recent order dates
SELECT c.CompanyName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY o.OrderDate DESC

--21. Display the names of all customers  along with the  count of products they bought
SELECT c.CompanyName, SUM(od.Quantity) AS NumOfProducts
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.CompanyName

--22. Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CompanyName, SUM(od.Quantity) AS NumOfProducts
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.CompanyName
HAVING SUM(od.Quantity) > 100

--23. List all of the possible ways that suppliers can ship their products. Display the results as below

   -- Supplier Company Name                Shipping Company Name

    ---------------------------------            ----------------------------------
SELECT DISTINCT Suppliers.CompanyName AS 'Supplier Company Name', Shippers.CompanyName AS 'Shipping Company Name'
FROM Suppliers
JOIN Products ON Suppliers.SupplierID = Products.SupplierID
JOIN [Order Details] ON Products.ProductID = [Order Details].ProductID
JOIN Orders ON [Order Details].OrderID = Orders.OrderID
JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID
ORDER BY Suppliers.CompanyName

--24. Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON p.ProductID=od.ProductID
ORDER BY o.OrderDate

--25. Displays pairs of employees who have the same job title.

SELECT E1.FirstName + ' ' + E1.LastName AS [Employee 1], E2.FirstName + ' ' + E2.LastName AS [Employee 2], E1.Title AS [Job Title]
FROM Employees E1 JOIN Employees E2 ON E1.Title = E2.Title AND E1.EmployeeID < E2.EmployeeID
ORDER BY [Job Title],[Employee 1], [Employee 2]

--26. Display all the Managers who have more than 2 employees reporting to them.
SELECT e1.FirstName + ' ' + e1.LastName AS Managers
FROM Employees e1 JOIN Employees e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.EmployeeID,e1.FirstName,e1.LastName
HAVING COUNT(e1.EmployeeID) > 2

--27. Display the customers and suppliers by city. The results should have the following columns: City, Name, Contact Name, Type (Customer or Supplier)
SELECT City, CompanyName AS 'Name', ContactName, 'Customer' AS 'Type'
FROM Customers
UNION ALL
SELECT City, CompanyName, ContactName, 'Supplier'
FROM Suppliers
ORDER BY City, Type, Name
