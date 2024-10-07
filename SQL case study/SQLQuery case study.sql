use Asset_management

 use Asset_Management

create table employees(
	employee_id int primary key,
	name varchar(50),
	department varchar(30),
	email varchar(50),
	password varchar(30))

create table assets(
	asset_id int primary key ,
	name varchar(30),
	type varchar(30),
	serial_number varchar(30),
	purchase_date date,
	location text,
	status varchar(50),
	owner_id int not null,
	foreign key (owner_id) references employees(employee_id))

create table maintenance_records(
	maintenance_id int primary key ,
	asset_id int,
	maintenance_date date,
	description text,
	cost decimal(10,2)
	foreign key (asset_id) references assets(asset_id))

create table asset_allocations(
	allocation_id int primary key,
	asset_id int,
	employee_id int,
	allocation_date date not null,
	return_date date
	foreign key(asset_id) references assets(asset_id),
	foreign key (employee_id) references employees(employee_id))

create table reservations(
	reservation_id int primary key,
	asset_id int,
	employee_id int,
	reservation_date date,
	start_date date,
	end_date date,
	status varchar(30)
	foreign key(asset_id) references assets(asset_id),
	foreign key (employee_id) references employees(employee_id)) 


INSERT INTO employees (employee_id, name, department, email, password) VALUES 
(1, 'Amit Sharma', 'IT', 'amit.sharma@example.com', 'Amit123!'),
(2, 'Priya Gupta', 'HR', 'priya.gupta@example.com', 'Priya@456'),
(3, 'Ravi Kumar', 'Finance', 'ravi.kumar@example.com', 'Ravi789#'),
(4, 'Sneha Mehta', 'IT', 'sneha.mehta@example.com', 'Sneha^321'),
(5, 'Rahul Singh', 'Sales', 'rahul.singh@example.com', 'Rahul$987'),
(6, 'Neha Verma', 'Marketing', 'neha.verma@example.com', 'Neha%654'),
(7, 'Karan Bansal', 'IT', 'karan.bansal@example.com', 'Karan&852'),
(8, 'Sakshi Jain', 'Finance', 'sakshi.jain@example.com', 'Sakshi*123'),
(9, 'Ankit Yadav', 'HR', 'ankit.yadav@example.com', 'Ankit(456)'),
(10, 'Pooja Desai', 'Sales', 'pooja.desai@example.com', 'Pooja)789!'); 

INSERT INTO assets (asset_id, name, type, serial_number, purchase_date, location, status, owner_id) VALUES 
(1, 'Laptop', 'laptop', 'SN-LAP001', '2023-01-15', 'Mumbai', 'in use', 1),
(2, 'Desktop', 'computer', 'SN-DESK002', '2023-02-20', 'Pune', 'in use', 2),
(3, 'Projector', 'equipment', 'SN-PROJ003', '2023-03-10', 'Navi Mumbai', 'under maintenance', 3),
(4, 'Printer', 'equipment', 'SN-PRNT004', '2023-04-05', 'Thane', 'in use', 4),
(5, 'Scanner', 'equipment', 'SN-SCNR005', '2023-05-12', 'Bangalore', 'decommissioned', 5),
(6, 'Mobile Phone', 'mobile', 'SN-MOB006', '2023-06-18', 'Chennai', 'in use', 6),
(7, 'Tablet', 'tablet', 'SN-TBL007', '2023-07-22', 'Delhi', 'in use', 7),
(8, 'Camera', 'equipment', 'SN-CAM008', '2023-08-30', 'Hyderabad', 'under maintenance', 8),
(9, 'Server', 'computer', 'SN-SRV009', '2023-09-10', 'Ahmedabad', 'in use', 9),
(10, 'Network Switch', 'equipment', 'SN-NSW010', '2023-10-15', 'Jaipur', 'in use', 10);

INSERT INTO maintenance_records (maintenance_id, asset_id, maintenance_date, description, cost) VALUES 
(1, 3, '2023-03-12', 'Replaced lamp and cleaned filter', 1500.00),
(2, 4, '2023-04-10', 'Serviced printer', 2000.00),
(3, 5, '2023-05-15', 'Decommissioned due to age', 0.00),
(4, 6, '2023-06-20', 'Software update', 500.00),
(5, 7, '2023-07-25', 'Battery replacement', 1000.00),
(6, 8, '2023-08-28', 'General maintenance check', 2500.00),
(7, 9, '2023-09-12', 'Hardware upgrade', 3000.00),
(8, 10, '2023-10-20', 'Routine check-up', 750.00),
(9, 1, '2023-01-20', 'Cleaned and serviced', 1000.00),
(10, 2, '2023-02-25', 'Software installation', 800.00);

INSERT INTO asset_allocations (allocation_id, asset_id, employee_id, allocation_date, return_date) VALUES 
(1, 1, 1, '2023-01-20', NULL),
(2, 2, 2, '2023-02-22', NULL),
(3, 3, 3, '2023-03-15', NULL),
(4, 4, 4, '2023-04-10', '2023-04-15'),
(5, 5, 5, '2023-05-12', NULL),
(6, 6, 6, '2023-06-18', NULL),
(7, 7, 7, '2023-07-22', NULL),
(8, 8, 8, '2023-08-30', NULL),
(9, 9, 9, '2023-09-10','2023-09-14'),
(10, 10, 10, '2023-10-15', NULL);


INSERT INTO reservations (reservation_id, asset_id, employee_id, reservation_date, start_date, end_date, status) VALUES 
(1, 1, 1, '2023-01-10', '2023-01-15', '2023-01-20', 'approved'),
(2, 2, 2, '2023-02-18', '2023-02-20', '2023-02-25', 'approved'),
(3, 3, 3, '2023-03-05', '2023-03-08', '2023-03-12', 'pending'),
(4, 4, 4, '2023-04-01', '2023-04-05', '2023-04-10', 'canceled'),
(5, 5, 5, '2023-05-15', '2023-05-20', '2023-05-25', 'pending'),
(6, 6, 6, '2023-06-18', '2023-06-20', '2023-06-25', 'approved'),
(7, 7, 7, '2023-07-22', '2023-07-25', '2023-07-30', 'approved'),
(8, 8, 8, '2023-08-30', '2023-09-01', '2023-09-05', 'pending'),
(9, 9, 9, '2023-09-10', '2023-09-12', '2023-09-15', 'approved'),
(10, 10, 10, '2023-10-15', '2023-10-20', '2023-10-25', 'canceled');  

select * from employees
select * from assets
select * from maintenance_records
select * from asset_allocations
select * from reservations