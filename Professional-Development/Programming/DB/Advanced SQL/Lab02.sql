use SD;

sp_addtype loc, 'nchar(2)';

create default def1 as 'NY';

create rule r1 as @value in ('NY', 'DS', 'KW');

sp_bindrule r1, loc;

sp_bindefault def1, loc;

create table Department(
DeptNo varchar(2) primary key,
DeptName varchar(20),
Location loc
)


create table Employee(
EmpNo int primary key,
EmpFname varchar(20) not null,
EmpLname varchar(20) not null,
DeptNo varchar(2),
Salary dec(8,2) unique,
constraint c1 foreign key(DeptNo) references Department(DeptNo)
)

create rule r2 as @var < 6000;
sp_bindrule r2, 'Employee.Salary'

-- inserting into tables
insert into Department
values('d1', 'Research', 'NY'), ('d2', 'Accounting', 'DS'), ('d3', 'Marketing', 'KW')

insert into Employee
values 
(25348, 'Mathew', 'Smith', 'd3', 2500),
(10102, 'Ann', 'Jones', 'd3', 3000),
(18316, 'John', 'Barrimore', 'd1', 2400),
(29346, 'James', 'James', 'd2', 2800),
(9031,  'Lisa', 'Bertoni', 'd2', 4000),
(2581,  'Elisa', 'Hansel', 'd2', 3600),
(28559, 'Sybl', 'Moser', 'd1', 2900);

insert into Project
values
('p1', 'Apollo', 120000),
('p2', 'Gemini', 95000),
('p3', 'Mercury', 185600);


insert into Works_on 
values (10102, 'p1', 'Analyst', '2006-10-01'),
(10102, 'p3', 'Manager', '2012-01-01'),
(25348, 'p2', 'Clerk',   '2007-02-15'),
(18316, 'p2', null,      '2007-06-01'),
(29346, 'p2', null,      '2006-12-15'),
(2581,  'p3', 'Analyst', '2007-10-15'),
(9031,  'p1', 'Manager', '2007-04-15'),
(28559, 'p1', null,      '2007-08-01'),
(28559, 'p2', 'Clerk',  '2012-02-01'),
(9031,  'p3', 'Clerk',  '2006-11-15'),
(29346, 'p1', 'Clerk',  '2007-01-04');

-- Testing Referential Integrity
insert into Works_on 
values (11111, 'p1', 'Engineer', '2007-10-01'); -- fk conflict

update Works_on
set EmpNo = 11111 where EmpNo = 10102 -- same conflict

update Employee
set EmpNo = 22222 where EmpNo = 10102 -- same conflict

delete from Employee
where EmpNo = 10102					  -- same conflict

--- Table Modifications
alter table Employee add TelephoneNumber varchar(20);
alter table Employee drop column TelephoneNumber;


-- [2] Create Schema and transfer tables
create schema Company;
alter schema Company transfer Department;

create schema HR;
alter schema HR transfer Employee;

--[3]
select
    constraint_name,
    constraint_type
from information_schema.table_constraints
where table_name = 'Employee';

--[4]
create synonym Emp
for HR.Employee

select * from Employee; -- invalid object name
select * from HR.Employee;
select * from Emp; 
select * from HR.Emp;   -- invalid object name

-- [5] 
update Company.Project
set Budget += Budget * 0.1
where ProjectNo in (select ProjectNo from Works_on where EmpNO = 10102);

-- [6]
update Company.Department
set DeptName = 'Sales'
where DeptNo in (select DeptNo from HR.Employee where EmpFname = 'James'); 

-- [7]
update Works_on
set Enter_Date = '12-12-2007'
where ProjectNo = 'p1' and EmpNo in 
	(select EmpNo from HR.Employee E, Company.Department D
		where E.DeptNo = D.DeptNo and DeptName = 'Sales');

-- [8]
delete from Works_on
where EmpNo in 
	(select EmpNo from HR.Employee E, Company.Department D
		where E.DeptNo = D.DeptNo and Location = 'KW');

