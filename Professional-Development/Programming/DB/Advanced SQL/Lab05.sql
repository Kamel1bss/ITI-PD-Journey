use ITI;

-- [1]
create proc studCount
as 
	select Dept_Name, count(*) as Studcnt
	from Department d join Student s
	on s.Dept_Id = d.Dept_Id
	group by Dept_Name

exec studCount

-- [2]

alter proc checkEmp
as
	declare @cnt int
	select @cnt = count(EmpNo)
	from Works_on
	where ProjectNo = 'p1'

	if @cnt > 3  
	begin
		select 'The number of employees in the project p1 is 3 or more'
	end
	else
	begin
		    select 'The following employees work for the project p1 :', ''
			union
		    select EmpFname, EmpLname
			from HR.Employee e, Works_on w
			where e.EmpNo = w.EmpNo
			and ProjectNo = 'p1';
	end

exec checkEmp

-- [3]
create proc updateWorks_on @oldId int, @newId int, @projectId varchar(2)
as
	update Works_on
	set EmpNo = @newId
	where EmpNo = @oldId and ProjectNo = @projectId;


exec updateWorks_on 29346, 10102, 'p2'

-- [4]
create table audit(
ProjectNo varchar(2),
UserName varchar(20),
ModifiedDate date,
Old_budget int,
new_budget int)

create trigger t1
on Company.Project
after update
as 
	if update(Budget)
	begin
		insert into audit
		select d.ProjectNo, user_name(), getdate(), d.budget, i.budget
			from deleted d, inserted i
			where d.ProjectNo = i.ProjectNo
	end

update Company.Project
set Budget = 15000
where Budget = 104500 and ProjectNo = 'p2';

select * from audit;

-- [5]
use ITI;

create trigger t2
on Department
instead of insert
as
	select 'Cannot insert a new record in that table!!'

insert into Department(Dept_Id, Dept_Name)
values (23, 'new');

-- [6]
use SD;

create trigger t3
on HR.Employee
after insert
as
	if(month(getdate()) = 'March')
		delete from Hr.Employee
		where EmpNo = (select EmpNo from inserted)

-- [7]
create Table audit_2
(
serverUserName varchar(50),
Date date,
Note varchar(100)
)


use ITI;
create trigger t4
on Student
after insert
as
	insert into audit_2
    select
        @@SERVERNAME,
        getdate(),
        'User ' + user_name() +
        ' inserted new row with key = ' + convert(varchar(10), i.St_Id) +
        ' in table Student'
    from inserted i;

insert into Student(St_Id, St_Fname)
values(159, 'Kamel')

select * from audit_2;

-- [8]
create trigger t5
on Student
instead of delete
as
	insert into audit_2
	select 
	  @@SERVERNAME,
        getdate(),
        'User ' + user_name() +
        ' try to delete row with key = ' + convert(varchar(10), d.St_Id)
    from  deleted d;

delete from Student
where st_id = 159;

select * from audit_2;


