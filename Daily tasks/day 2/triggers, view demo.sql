create table salarydetail(
	bankid int ,
	id int,
	name varchar(30),
	salary decimal(10,2),
	foreign key (id) references employee(id),

);

insert into salarydetail values
(1,1,'kumar',5000),
(2,2,'nishan',10000),
(3,3,'rohan',4000),
(4,4,'umesh',6000),
(5,5,'oviya',7000)

create clustered index ix_id on salarydetail(id)



create table skills(
	id int,
	name varchar(50),
	skills varchar(30)
)

insert into skills values
(1,'kumar','fsd'),
(2,'nishan','testing'),
(3,'rohan','cad'),
(4,'umesh','frontend'),
(5,'oviya','plm')

create unique index ix_id on skills(id)


create table sports(
	id int,
	name varchar(30),
	sport_name varchar(25)
)

insert into sports values
(1,'kumar','cricket'),
(2,'nishan','chess'),
(3,'rohan','football'),
(4,'umesh','hcokey'),
(5,'oviya','badminton')

create nonclustered index ix_id on sports(id)

select * from sports

--create view
create view vwempanddept
as
select e.id,e.name,e.Gender,e.deptid from employee e
join department d on d.deptid = e.deptid

select * from vwempanddept
--show particular values
select * from vwempanddept where Gender = 'Female'
--update values
update employee set name = 'arnheid' where id = 3

select * from vwempanddept

insert into employee values (6,'thorfinn','male','19-04-2002',6)

--Transactions


begin Transaction
update employee set name='Thorkell'
where id = 2

waitfor delay '00:00:05'

update skills set name = 'Canute', skills = 'Data analyst'
where id = 2

commit transaction

select * from employee
select * from skills

--9th question

create table Employee_Audit  (    
	auditID int identity(1,1),
	ID int,
	audit_action varchar(255),
	audit_date   Date Default GETDATE()
)  

select * from Employee
select * from Employee_Audit

create trigger trg_EmployeeInsert
on Employee
for insert	
as
begin
    insert into Employee_Audit(ID,audit_action,audit_date)
    select ID ,'INSERT',GETDATE() from inserted
end

insert into Employee values(6,'bhor','Male','2003-09-11',4)

create trigger trg_EmployeeUpdate
on Employee
after update
as
begin
    insert into Employee_Audit(ID,audit_action,audit_date)
    select ID ,'UPDATE',GETDATE() from inserted
end

update Employee set deptid = 3 where ID = 5
 


