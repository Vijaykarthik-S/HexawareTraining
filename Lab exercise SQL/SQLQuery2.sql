use Techshop;

select Firstname, Lastname, Email from Customers;   --question 1

select Customers.Firstname, Customers.Lastname, Orders.Orderdate from Orders
inner join Customers on Customers.CustomerID = Orders.CustomerID;  --question2

insert into Customers (Firstname, Lastname, Email, Address) values
('Walter','White','walt@abc.com','104,East Road, Albuquerque');
select * from Customers;  --question 3



select*from Products;
update Products set Price = Price*1.10;
select * from Products;   --question 4

select * from Orders;
select * from Orderdetails;

declare @OrderID int = 5;

delete from Orders where OrderID = @OrderID;
delete from Orderdetails where OrderID = @OrderID;

select * from Orders;
select * from Orderdetails;  -- question 5
select * from Orders;



insert into Orders (CustomerID, Orderdate, TotalAmount) values( 10, GETDATE(), 500);
select * from orders;  --question 6

select * from customers;

update Customers set Email = 'white@123.com', Address = '600 westerling street' 
where CustomerID = 14;

select * from Customers;  -- question 7



