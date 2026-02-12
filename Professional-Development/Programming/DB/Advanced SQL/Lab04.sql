use ITI;

-- [1]
create view studInfomation
as 
	select St_Fname + ' ' + St_Lname as fullName, Crs_Name
	from Student s join Stud_Course sc
	on s.St_Id = sc.St_Id
	join Course c
	on sc.Crs_Id = c.Crs_Id
	where sc.Grade > 50;

select * from studInfomation;

-- [2]
create view managerTopics
with encryption
as
select 
    d.Dept_Manager as ManagerName,
    t.Top_Name
from Department d
join Instructor i
    on d.Dept_Manager = i.Ins_Id
join Ins_Course ic
    on i.Ins_Id = ic.Ins_Id
join Course c
    on ic.Crs_Id = c.Crs_Id
join Topic t
    on c.Top_Id = t.Top_Id;

select * from managerTopics;


-- [3]
create view instructorDept
as 
	select Ins_Name, Dept_Name
	from Instructor i
	join Department d
	on i.dept_id = d.dept_id
	where dept_name in ('SD', 'Java')

select * from instructorDept;

-- [4]
create view v1
as
	select * from Student
	where St_Address in ('Alex', 'Cairo')
with check option

select * from v1;

-- [5]
use Company_SD
create view projectInfo
as
	select pname, COUNT(ESSn) as EmployeeNum
	from Project p
	join Works_for w
	on p.Pnumber = w.Pno
	group by pname;

select * from projectInfo;

----- [Index]

use ITI
-- [6]
create clustered index idx_department_hiredate
on Department (Manager_hiredate); -- error

-- [7]
create unique index idx_student_age -- error
on Student (st_age)

------ [Merge]
create table DailyTransactions
(userId int primary key,
transactionAmount int)

create table LastTransactions
(userId int primary key,
transactionAmount int)

-- [8]
merge LastTransactions as T
using DailyTransactions as s
on T.userId = s.userId

when matched then
	update
	set T.transactionAmount = s.transactionAmount
when not matched then
	insert
	values(s.userId, s.transactionAmount);


-------------------------------------------------------------------------------------
-- [Part 2]
use SD;

-- [1]
create view v_clerk
as 
	select EmpNo, ProjectNo, Enter_Date
	from Works_on
	where job = 'Clerk';

-- [2]
create view v_without_budget
as 
	select * from Company.project
	where budget is null

-- [3]
create view v_count
as 
	select projectName, count(job) as cnt
	from Company.project p, Works_on w
	where p.projectNo = w.ProjectNo
	group by projectName;

-- [4]
create view v_project_p2
as
	select EmpNo from v_clerk
	where ProjectNo = 'p2';

-- [5]
alter view v_without_budget
as
	select * from Company.Project
	where projectNo in ('p1', 'p2')

-- [6]
drop view v_clerk
drop view v_count

-- [7]
create view emp_info
as
	select EmpNo, EmpLname
	from HR.Employee
	where DeptNo = 'd2';

-- [8]
select EmpLname
from emp_info
where EmpLname like '%j%';

-- [9]
create view v_dept
as 
	select DeptNo, DeptName
	from Company.Department;

-- [10]
insert into v_dept
values('d4', 'Development')

-- [11]
create view v_2006_check
as
	select EmpNo, ProjectNo, Enter_Date
	from Works_on
where Enter_Date between '2006-01-01' and '2006-12-30'