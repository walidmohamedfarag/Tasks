

create database task5
go
use task5
go
create schema task
go


--Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
create table task.Employees(
     id int,
	 name varchar(30),
	 salary decimal(8,2)
)

--Add a new column named "Department" to the "Employees" table with data type varchar(50).
alter table task.Employees add Department varchar(50)

--Remove the "Salary" column from the "Employees" table.
alter table task.Employees drop column salary

--Rename the "Department" column in the "Employees" table to "DeptName".
exec sp_rename 'task.Employees.Department','DeptName'

--Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
create table task.project(
     project_id int,
	 project_name varchar(30)
)

--Add a primary key constraint to the "Employees" table for the "ID" column.
alter table task.Employees add primary key(id)

--Add a unique constraint to the "Name" column in the "Employees" table.
alter table task.Employees add unique(name)

--Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar), and Email (varchar), and Status (varchar).
create table task.Customers(
     cust_id int,
	 first_name varchar(30),
	 last_name varchar(30),
	 email varchar(50),
	 status varchar(30)
)

--Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
alter table task.Customers add constraint name unique (first_name , last_name )

--Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime), and TotalAmount (decimal).
create table task.orders(
     order_id int,
	 customer_id int,
	 order_date datetime,
	 total_amount decimal(10,2)
)

--Add a check constraint to the "TotalAmount" column in the "Orders" table to ensure that it is greater than zero.
alter table task.orders add check(total_amount > 0 )

--Create a schema named "Sales" and move the "Orders" table into this schema
create schema sales
go
alter schema sales transfer task.orders

--Rename the "Orders" table to "SalesOrders."
exec sp_rename 'sales.orders','SalesOrders'