create table Gems
(
GemID int primary key identity(1,1),
CreatedDate datetime not null,
Name varchar(100) not null,
Color varchar(25) null,
Size int null,
Carats int Null,
Mohs int null,
Shape varchar(25) null,
Origin varchar(50) null,
Example varchar (50) null,
Treatmemnt varchar(50) null,
AverageValue decimal(18, 2) null,
BirthStone varchar(9) null
);

create table Minerals
(
MineralID int primary key identity(1,1),
GemID int not null foreign key references Gems(GemID),
CreatedDate datetime not null,
Name varchar(100) not null,
ChemicalComposition varchar(100) not null,
)