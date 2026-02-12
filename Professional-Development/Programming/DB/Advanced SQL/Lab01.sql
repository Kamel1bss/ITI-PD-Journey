use ITI;

-- [1] Retrieve number of students who have a value in their age. 
select COUNT(*) 
from Student
where St_Age is not null;

-- [2] Get all instructors Names without repetition
select distinct ins_name 
from Instructor;

-- [3] Display student with the following Format (use isNull function)
select st_id, isnull(st_fname,'') + ' ' + isnull(st_lname, '') as[Student Full Name], isnull(dept_name, '')
from student s, department d
where s.dept_id = d.dept_id

-- [4] Display instructor Name and Department Name 
select ins_name, dept_name
from Department d right join Instructor i
on i.Dept_Id = d.Dept_Id

-- [5] Display student full name and the name of the course he is taking For only courses which have a grade  
select st_fname + ' ' + st_lname, crs_name
from student s,Stud_Course sc , course c
where s.St_Id = sc.St_Id and sc.Crs_Id = c.Crs_Id and Grade is not null;

-- [6] Display number of courses for each topic name
select top_name, count(crs_id) as course_count
from Course c, Topic t
where c.Top_Id = t.Top_Id
group by top_name;

-- [7] Display max and min salary for instructors
select max(salary) as Max_salary, min(salary) as Min_salary
from Instructor;

-- [8] Display instructors who have salaries less than the average salary of all instructors.
select * from Instructor
where Salary < (select avg(salary) from Instructor);

-- [9] Display the Department name that contains the instructor who receives the minimum salary.
select Dept_name 
from(select Dept_name, ROW_NUMBER() over (order by salary) as rn
		from Instructor i, Department d
		where i.Dept_Id = d.Dept_Id) as newTable
where rn = 1;
-- OR
select top(1)Dept_Name
from Instructor i, Department d
where i.Dept_Id = d.Dept_Id 
order by salary;

-- [10] Select max two salaries in instructor table. 
select Salary 
from(select Salary, ROW_NUMBER() over (order by salary) as rn
		from Instructor ) as newTabel
where rn <= 2;

-- [11] Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function"
select Ins_name, coalesce(convert(varchar(20),salary), 'Bouns')
from Instructor;

-- [12] Select Average Salary for instructors 
select avg(salary) as AVG
from Instructor;

-- [13] Select Student first name and the data of his supervisor 
select student.st_fname as [Student_name], super.*
from Student student, Student super
where student.St_super = super.St_Id;

-- [14] Write a query to select the highest two salaries in Each Department for instructors who have salaries. “using one of Ranking Functions”
select salary 
from(select salary, ROW_NUMBER() over(partition by dept_id order by salary desc) as rn
		from Instructor) as newTable
where rn <= 2

-- [15] Write a query to select a random student from each department.  “using one of Ranking Functions”
select St_Fname 
from(select st_fname, ROW_NUMBER() over(partition by dept_id order by newid()) as rn
		from Student) as newTable
where rn = 1

-----------------------------------------------------------------------------------------------------

use AdventureWorks2012;
-- [1] Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema) 
--     to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’

select SalesOrderId, shipDate 
from Sales.SalesOrderHeader
where OrderDate between '7/28/2002' and '7/29/2014';

-- [2] Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)
select Product.Name 
from Production.Product
where Product.StandardCost < 110;

-- [3] Display ProductID, Name if its weight is unknown
select Product.ProductID, Product.Name
from Production.Product
where Product.Weight is null;

-- [4] Display all Products with a Silver, Black, or Red Color
select Product.Name
from Production.Product
where Product.Color in ('Silver', 'Black', 'Red');

-- [5] Display any Product with a Name starting with the letter B
select Product.Name
from Production.Product
where Product.Name like 'B%';

-- [6] Run the following Query
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3
-- Then write a query that displays any Product description with underscore value in its description

select Description
from Production.ProductDescription
where Description like '%[_]%';

-- [7] Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table 
--		for the period between  '7/1/2001' and '7/31/2014'

select orderDate, Sum(TotalDue)
from Sales.SalesOrderHeader
where OrderDate between '7/1/2001' and '7/31/2014'
group by orderDate;

-- [8] Display the Employees HireDate (note no repeated values are allowed)
select distinct HireDate
from HumanResources.Employee

-- [9] Calculate the average of the unique ListPrices in the Product table
select AVG(distinct ListPrice) as Avg_price
from Production.Product;

-- [10] Display the Product Name and its ListPrice within the values of 100 and 120 the list should has the following format 
--      "The [product name] is only! [List price]" (the list will be sorted according to its ListPrice value)

select
 'The [' + Product.Name + '] is only! [' + convert(nvarchar(20), ListPrice) + ']'
from Production.Product
where ListPrice between 100 and 120
order by ListPrice

-- [11]
-- a) Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table  
--	in a newly created table named [store_Archive]
select rowguid, Name, SalesPersonID, Demographics into store_Archive
from Sales.Store

select * from store_Archive;
-- Note: Check your database to see the new table and how many rows in it?
-- b)	Try the previous query but without transferring the data? 
select rowguid, Name, SalesPersonID, Demographics into store_Archive2
from Sales.Store
where 1 = 2

select * from store_Archive2

-- [12] Using union statement, retrieve the today’s date in different styles using convert or format funtion.

select format(getdate(), 'dd-MM-yyyy')
union
select format(getdate(), 'MM-dd-yyyy');

