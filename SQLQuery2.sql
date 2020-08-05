Create Table Users
(
ID int primary key identity(1,1) not null,
UserName nvarchar(50) not null,
Password nvarchar(50) not null,
Email Nvarchar(50) null,
Phone int null
)


create table Categories
(
ID int primary key identity(1,1) not null,
Name nvarchar(100) not null
)

create table Statues
(
ID int primary key identity(1,1) not null,
Name nvarchar(5) not null
)

create table Accessories
(
ID int primary key identity(1,1) not null,
Name nvarchar(100) not null,
Serial_Number nvarchar(100) not null,
Model nvarchar(50) not null,
Weight float not null,
Entry_Data date not null,
Departure_Date date Not null,
Work_In nvarchar(max) not null,
Buy_Date date not null,
Special_Prop nvarchar(max) not null,
Quantity int not null,
Cat_ID int not null foreign key references Categories(ID),
Stat_ID int not null foreign key references Statues(ID),
User_ID int not null foreign key references Users(ID)
)

create table colors
(
ID int primary key identity(1,1) not null,
Name nvarchar(50) not null,
Acc_ID int not null foreign key references Accessories(ID)
)