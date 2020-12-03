create database PayScaleDb
use PayScaleDb

create table Scalee
(
 Payband varchar(10),
 PaySalary float
 primary key(Payband,PaySalary)

)
insert into Scalee values ('Grade-A',10000),('GradeB',15000),('Grade-C',20000)

Select * from Scalee