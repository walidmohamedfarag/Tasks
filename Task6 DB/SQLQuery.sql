
--Create a new database named "CompanyDB."
create database companyDB
go

use companyDB
go
--Create a schema named "Sales" within the "CompanyDB" database.
create schema sales 
go

--Create a table named "employees" with columns: 
--employee_id (INT) - use sequence instead of identity,
--first_name (VARCHAR),
--last_name (VARCHAR),
--salary (DECIMAL)
--Within the "Sales" schema.

create table sales.employee(
     emp_id int ,
	 first_name varchar(30),
	 last_name varchar(30),
	 salary decimal,
)

--Alter the "employees" table to add a new column named "hire_date" with the data type DATE.
alter table sales.employee add hire_date datetime

--Select all columns from the "employees" table.
select * 
from sales.employee

--Retrieve only the "first_name" and "last_name" columns from the "employees" table.
select first_name , last_name 
from sales.employee

--Retrieve only the "first_name" and "last_name" columns from the "employees" table.
select first_name + ' ' + last_name 'full name'
from sales.employee

--Show the average salary of all employees. (Use AVG() function)
select AVG(salary) agerage
from sales.employee

--Select employees whose salary is greater than 50000. 
select first_name + ' ' + last_name 'full name',salary
from sales.employee 
where salary > 50000

--Retrieve employees hired in the year 2020.
select first_name + ' ' + last_name 'full name' , hire_date
from sales.employee
where year(hire_date) = '2020'

--List employees whose last names start with 'S'.
select last_name
from sales.employee
where last_name like '%s'

--Display the top 10 highest-paid employees
select top 10 * from sales.employee

--Find employees with salaries between 40000 and 60000.
select first_name + ' ' + last_name 'full name',salary
from sales.employee 
where salary between 40000 and 60000

--Show employees with names containing the substring 'man'.
select * 
from sales.employee 
where first_name + last_name like '%man%'

--Display employees with a NULL value in the "hire_date" column
select *
from sales.employee
where hire_date is not null

--Select employees with a salary in the set (40000, 45000, 50000).
select * 
from sales.employee
where salary in (40000,45000,50000)

--Retrieve employees hired between '2020-01-01' and '2021-01-01'.
select *
from sales.employee
where hire_date between '2020-01-01' and '2021-01-01'

--List employees with salaries in descending order.
select * 
from sales.employee 
order by salary desc

--Show the first 5 employees ordered by "last_name" in ascending order
select *
from sales.employee
order by last_name
offset 0 rows
fetch next 5 rows only

--Display employees with a salary greater than 55000 and hired in 2020.
select *
from sales.employee 
where salary > 55000 and YEAR(hire_date) = '2020'

--Select employees whose first name is 'John' or 'Jane'
select *
from sales.employee 
where first_name like 'John%' or first_name like 'Jane%'

--List employees with a salary ≤ 55000 and a hire date after '2022-01-01'
select *
from sales.employee 
where salary <= 55000 and hire_date = '2022-01-01'

--Retrieve employees with a salary greater than the average salary.
select first_name , last_name ,salary
from sales.employee
where salary > (select avg(salary) from sales.employee)

--Display the 3rd to 7th highest-paid employees. (Use OFFSET and FETCH)
select *
from sales.employee 
order by first_name,last_name
offset 3 rows 
fetch next 4 rows only

--List employees hired after '2021-01-01' in alphabetical order.
select *
from sales.employee 
where hire_date > '2021-01-01'

--Retrieve employees with a salary > 50000 and last name not starting with 'A'.
select *
from sales.employee 
where salary > 50000 and last_name not like 'A%'

--Display employees with a salary that is not NULL.
select * 
from sales.employee
where salary is not null

--Show employees with names containing 'e' or 'i' and a salary > 45000.
select *
from sales.employee 
where first_name + last_name like '%[ei]%' and salary > 45000

--Create a new table named "departments" with columns:
--department_id (Primary Key, INT),
--department_name (VARCHAR),
--manager_id (INT, references "employees".employee_id).
alter table sales.employee alter column emp_id int not null
alter table sales.employee add primary key(emp_id) 
create table sales.departments(
     department_id int primary key,
	 department_name varchar(30),
	 manager_id int references sales.employee(emp_id) 
)

--Assign each employee to a department by creating a "department_id" column in "employees" and making it a foreign key referencing "departments".department_id.
alter table sales.employee add department_id int foreign key references sales.departments(department_id)

--Retrieve all employees with their department names (Use INNER JOIN).
select first_name + ' ' + last_name 'full name' , department_name
from sales.employee e join sales.departments d
on e.emp_id = d.manager_id 
where d.department_name = ' '

--Retrieve employees who don’t belong to any department (Use LEFT JOIN and check for NULL).
select first_name + ' ' + last_name 'full name' , department_name
from sales.employee e left join sales.departments d
on e.department_id is null

--show all departments and their employee count (Use JOIN and GROUP BY).
select department_name , COUNT(emp_id) 'count employee'
from sales.employee e join sales.departments d
on e.emp_id = d.manager_id
group by 
department_name

--Retrieve the highest-paid employee in each department (Use JOIN and MAX(salary)).
select department_name , max(salary) 'max salary employee'
from sales.employee e join sales.departments d
on e.emp_id = d.manager_id
group by 
department_name