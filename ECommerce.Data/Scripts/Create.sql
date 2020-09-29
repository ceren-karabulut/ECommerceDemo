Create Database ECommerceDB
go

use ECommerceDB
go

Create Table Product(
Id int primary key identity,
[Name] nvarchar(100) not null, 
Brand nvarchar(100) not null,
UnitPrice decimal not null,
StockCount int not null
)


create table Category(
Id int primary key identity,
[Name] nvarchar(50) not null
)

alter table Product 
add CategoryId int


