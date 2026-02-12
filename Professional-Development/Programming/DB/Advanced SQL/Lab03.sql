--[1] Create a scalar function that takes date and returns Month name of that date.
create function getMonth(@var date)
returns varchar(20)
as 
	begin 
		return month(@var)
	end

select dbo.getMonth(getDate()) as Month

-- [2] Create a multi-statements table-valued function that 
--     takes 2 integers and returns the values between them.

create function getValues(@start int, @end int)
returns @t table(numbers int)
as 
	begin
		while @start < @end
		begin
			set @start = @start + 1 
			insert into @t values (@start)
		end
		return
	end

select * from getValues(10, 20);

-- [3] Create inline function that takes Student No and returns Department Name 
--		with Student full name.

create function studInfo(@studNo int)
returns table
	as
		return (select Dept_Name , CONCAT(St_Fname, ' ', St_Lname) as FullName
					from Student s, Department d
					where s.Dept_Id = d.Dept_Id and St_Id = @studNo)

select * from studInfo(10)

-- [4] Create a scalar function that takes Student ID and returns a message to user

create function checkName(@studNo int)
returns varchar(max)
as 
	begin 
		declare @fname varchar(20), @lname varchar(20), @result varchar(max)
		select @fname = st_fname, @lname = st_lname from Student where St_Id = @studNo;
		if @fname is null and @lname is null
			set @result = 'First name & last name are null'
		else if @fname is null
			set @result = 'first name is null'
		else if @lname is null
			set @result = 'lanst name is null'
		else 
			set @result = 'First name & last name are not null'
		return @result;
	end

select dbo.CheckName(12);
select dbo.CheckName(13);
select dbo.CheckName(14);

-- [5] Create inline function that takes integer which represents manager ID and displays department name, 
--		Manager Name and hiring date 

create function MangerInfo(@mgr_id int)
returns table
as 
	return (select Dept_Name, Ins_Name, Manager_hiredate 
			from Instructor s, Department d  
				where s.Ins_Id = d.Dept_Manager and s.Ins_Id = @mgr_id)

select * from MangerInfo(5);


-- [6] Create multi-statements table-valued function that takes a string

create function checkstring(@str varchar(20))
returns @t table(name varchar(20))
	as 
	begin
		if @str = 'first name'
			insert into @t
			select isnull(St_Fname, '') from Student
		else if @str = 'last name'
			insert into @t
			select isnull(St_lname, '') from Student
		else if @str = 'full name'
			insert into @t
			select CONCAT(st_fname, ' ', st_lname) from Student;
	return
	end

select * from checkString('full name')

-- [7] Write a query that returns the Student No and Student first name without the last char
	select St_Id, substring(St_Fname, 0, len(St_Fname))
	from Student;

-- [8] Wirte query to delete all grades for the students Located in SD Department 
	delete sc
	from stud_course sc
	join student s 
		on sc.st_id = s.st_id
	join department d 
		on s.dept_id = d.dept_id
	WHERE d.Dept_Name = 'SD';

-- OR

	update sc
	set Grade = null
	from stud_course sc join student s
		on sc.st_id = s.st_id
	join department d
		on d.dept_id = s.dept_id
	where Dept_Name = 'SD'

----------------------------------------------------------------------------
-- [BOUNS]
-- [1]
create table EmployeeHierarchy (
    EmployeeID int primary key,
    Name varchar(20),
    OrgNode hierarchyid
);

insert into employeehierarchy (employeeid, name, orgnode)
values (1, 'CEO', hierarchyid::GetRoot());

insert into employeehierarchy (employeeid, name, orgnode)
values (2, 'Manager', hierarchyid::GetRoot().GetDescendant(null, null));

insert into employeehierarchy (employeeid, name, orgnode)
values (3, 'CTO', hierarchyid::GetRoot().GetDescendant(null, hierarchyid::GetRoot().GetDescendant(null, null)));




-- [2]
use Company_SD;

declare @i int = 1;

while @i <= 3000
begin
    insert into HR.Employee (SSN, Fname, Lname, Dno)
    values (@i, 'Jane', 'Smith', 10);
    set @i = @i + 1;
END
GO