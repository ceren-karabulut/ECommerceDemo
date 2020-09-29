use ECommerceDB
go

insert into Product 
values ('Telephone','Apple','7000','20','2'),
('Laptop','Hp','4400','32','1'),
('Laptop', 'Toshiba','5499','11','1')

insert into Category 
values ('Computer'),
('Telephone')

insert into Product
values ('Galaxy','Samsung','4500','10','2')

update Product
set
CategoryId ='1'
where Name='laptop'

update Product
set
CategoryId ='2'
where Id = '4'

update Product
set
CategoryId='2'
where Name ='Telephone'

insert into Product
values ('Abra','Monster','5300','3','1')

select * from Product

select *from Category