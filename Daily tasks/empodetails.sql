/*create table department (
	deptid int primary key identity,
	name varchar(30)
)
create table employee(
	id int primary key identity,
	name varchar(30),
	Gender varchar(10),
	DOB date,
	deptid int,
	foreign key (deptid) references department(deptid) 

);

insert into department values('HR'),('FSD'),('Testing'),('Finance'),('supervising')

insert into employee values
('rohit','male','2003-09-08',1),
('kumar','male','2003-09-18',2),
('nivetha','female','2004-06-18',3),
('yadav','male','2002-06-01',4),
('umesh','male','2004-09-08',5) */

/*create proc uspUpdateEmployee
    @id INT,
    @Name VARCHAR(50),
    @Gender VARCHAR(10),
    @DOB DATE,
    @DeptId INT
AS
begin
    UPDATE Employee
    SET Name = @Name,
        Gender = @Gender,
        DOB = @DOB,
        DeptId = @DeptId
    WHERE ID = @ID;
end;

EXEC uspUpdateEmployee @ID = 1, @Name = 'aarav', @Gender = 'Male', @DOB = '2002-01-01', @DeptId = 2;  */


CREATE PROCEDURE uspEmployeeByGenderAndDept
    @Gender VARCHAR(10),
    @DeptId INT
AS
BEGIN
    SELECT * 
    FROM Employee
    WHERE Gender = @Gender AND DeptId = @DeptId;
END;

exec uspEmployeeByGenderAndDept @Gender = 'Female', @DeptId = 3; 


/*create proc uspEmployeeCountByGender
    @Gender VARCHAR(10)
AS
begin
    SELECT COUNT(*) AS EmpCount FROM Employee
    WHERE Gender = @Gender;
end;


EXEC uspEmployeeCountByGender @Gender = 'Male'; */









