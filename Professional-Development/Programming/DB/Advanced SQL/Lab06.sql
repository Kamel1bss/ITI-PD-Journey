-- [1]
use SD;

declare c1 cursor 
for select Salary from HR.Employee
for update
declare @sal int
open c1
fetch c1 into @sal
while @@FETCH_STATUS = 0
begin
	if @sal < 3000
		update HR.Employee
		set Salary= @sal * 1.1
		where current of c101
	else 
		update HR.Employee
		set Salary =@sal *1.2
		where current of c101

	fetch c1 into @sal
end
close c1
deallocate c1

-- [2]
use ITI;

declare c1 cursor 
for select Dept_Name, Ins_Name as Manger_Id from Department d, Instructor i where i.Ins_Id = d.Dept_Manager
for read only
declare @DeptName varchar(20), @Manger varchar(20)
open c1
fetch c1 into @DeptName, @Manger
while @@FETCH_STATUS = 0
begin
	select @DeptName, @Manger
	fetch c1 into @DeptName, @Manger
end
close c1
deallocate c1

-- [3]

use ITI;

declare c1 cursor 
for select St_Fname from student 
for read only
declare @firstName varchar(20), @AllNames varchar(max) = ''
open c1
fetch c1 into @firstName
while @@FETCH_STATUS = 0
begin
	set @AllNames = CONCAT(@AllNames, ', ', @firstName)
	fetch c1 into @firstName
end
	select @AllNames;
close c1
deallocate c1

-- [4]
---------------------------------------------------------------------------------------------------------
--[4.1]
create proc getMonth_sp @var date
as 
	begin 
		select month(@var)
	end

exec getMonth_sp '12-1-2003'

--[4.2]
create proc getValues_sp @start int, @end int
as 
	begin
		declare @t table (nums int)
		while @start < @end
		begin
			set @start = @start + 1 
			insert into @t values (@start)
		end
		select * from @t;
	end

exec getValues_sp 10, 20;

-- [4.3] 
create proc studInfo_sp @studNo int
	as
	begin
		declare @t table (DeptName varchar(20), FullName varchar(20))
		insert into @t 
		select Dept_Name , CONCAT(St_Fname, ' ', St_Lname) as FullName
					from Student s, Department d
					where s.Dept_Id = d.Dept_Id and St_Id = @studNo
	end

exec studInfo_sp 10;

-- [4.4]
create proc checkName_sp @studNo int
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
		select @result;
	end

exec CheckName_sp 11

-- [4.5] 
alter proc MangerInfo_sp @mgr_id int
as 
	begin
	declare @t table(DeptName varchar(20), Ins_Name varchar(20), hireDate date)
	insert into @t 
	select Dept_Name, Ins_Name, Manager_hiredate 
			from Instructor s, Department d  
				where s.Ins_Id = d.Dept_Manager and s.Ins_Id = @mgr_id
	select * from @t
	end
	
exec MangerInfo_sp 5;


-- [4.6] 
alter proc checkstring_sp @str varchar(20)
as 
	begin
		declare @t table(name varchar(20))
		if @str = 'first name'
			insert into @t
			select isnull(St_Fname, '') from Student
		else if @str = 'last name'
			insert into @t
			select isnull(St_lname, '') from Student
		else if @str = 'full name'
			insert into @t
			select CONCAT(st_fname, ' ', st_lname) from Student;
	select * from @t
	end

exec checkString_sp 'full name'
------------------------------------------------------------------------------------------------
-- [5]
create sequence s1
  as int
  start with 1
  increment by 1
  maxvalue 10
  no cycle

create table SEQ_Test
(
	Id int ,
	Name varchar(20),
)


insert into SEQ_Test (Id, Name) values (next value for s1, 'Ahmed');
insert into SEQ_Test(Id, Name) values (next value for s1, 'Kamel');

select * from SEQ_Test

-- [6]
CREATE DATABASE AdventureWorks_Snapshot
ON
(
    NAME = AdventureWorks2012_Data,
    FILENAME = 'D:\Backup\AdventureWorks_Snapshot.ss'
)
AS SNAPSHOT OF AdventureWorks2012;

-- [7]
backup database SD
to disk ='D:\Backup\SD.bak'

backup database SD
to disk ='D:\Backup\SD_Diff.bak'
with differential

-- [8]
SELECT * FROM Student; -- to ecxel sheet
