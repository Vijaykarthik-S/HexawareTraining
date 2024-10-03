use Techshop;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY identity,
    Firstname VARCHAR(50),
    Lastname VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(300)
);

create table Products(
	ProductID int primary key identity,
	Productname varchar(50),
	Description text,
	Price decimal(10,2));

create table Orders(
	OrderID int primary key identity,
	CustomerID int,
	Orderdate date,
	TotalAmount decimal(10,2),
	foreign key(CustomerID) references Customers(CustomerID));

create table Orderdetails(
	OrderdetailID int primary key identity,
	OrderID int,
	ProductID int,
	Quantity int,
	foreign key(OrderID) references Orders(OrderID),
	foreign key(ProductID) references Products(ProductID));

create table Inventory(
	InventoryID int primary key identity,
	ProductID int,
	Quantity int,
	StockUpdate datetime,
	foreign key (ProductID) references Products(ProductID));

insert into Customers ( Firstname, Lastname, Email, Phone, Address) Values
	('Aarav', 'Sharma', 'aarav@example.com', '1234567890', '123 Main St'),
	('Vihaan', 'Patel', 'vihaan@example.com', '0987654321', '456 Elm St'),
	('Aditya', 'Verma', 'aditya@example.com', '2345678901', '789 Oak St'),
	('Arjun', 'Kumar', 'arjun@example.com', '3456789012', '101 Pine St'),
	('Sai', 'Reddy', 'sai@example.com', '4567890123', '202 Maple St'),
	('Reyansh', 'Gupta', 'reyansh@example.com', '5678901234', '303 Birch St'),
	('Atharv', 'Singh', 'atharv@example.com', '6789012345', '404 Cedar St'),
	('Krishna', 'Iyer', 'krishna@example.com', '7890123456', '505 Spruce St'),
	('Rohan', 'Nair', 'rohan@example.com', '8901234567', '606 Willow St'),
	('Vivaan', 'Sethi', 'vivaan@example.com', '9012345678', '707 Cherry St');

insert into Products (Productname, Description, Price) Values
	('Smartphone', 'Latest model with all features', 1000),
	('Laptop', 'High performance for gaming and work', 999),
	('Tablet', 'Lightweight and portable', 300),
	('Smartwatch', 'Keeps track of your fitness', 199),
	('Headphones', 'Noise-canceling over-ear headphones', 499),
	('Bluetooth Speaker', 'Portable and waterproof', 799),
	('Camera', 'High resolution for stunning photos', 500),
	('Smart TV', '4K Ultra HD with smart features', 799),
	('Game box', 'Latest gaming system', 450),
	('card', 'For book lovers on the go', 125);

insert into Orders (CustomerID, Orderdate, TotalAmount) values
	(1, GETDATE(), 699.99),
	(2, GETDATE(), 999.99),
	(3, GETDATE(), 299.99),
	(4, GETDATE(), 199.99),
	(5, GETDATE(), 149.99),
	(6, GETDATE(), 79.99),
	(7, GETDATE(), 499.99),
	(8, GETDATE(), 799.99),
	(9, GETDATE(), 499.99),
	(10, GETDATE(), 129.99);

insert into Orderdetails (OrderID, ProductID, Quantity) values
	(1, 1, 1),
	(2, 2, 1),
	(3, 3, 1),
	(4, 4, 2),
	(5, 5, 1),
	(6, 6, 1),
	(7, 7, 1),
	(8, 8, 2),
	(9, 9, 1),
	(10, 10, 3);

insert into Inventory (ProductID, Quantity, StockUpdate) values
		(1, 10, GETDATE()),
	(2, 20, GETDATE()),
	(3, 15, GETDATE()),
	(4, 30, GETDATE()),
	(5, 50, GETDATE()),
	(6, 25, GETDATE()),
	(7, 12, GETDATE()),
	(8, 35, GETDATE()),
	(9, 40, GETDATE()),
	(10, 35, GETDATE());



select * from Customers;
select * from Products;
select * from Orders;
select * from OrderDetails;
select * from Inventory;