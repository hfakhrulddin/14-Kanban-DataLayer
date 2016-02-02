--create table List
--(
--ListId int primary key identity(1, 1),
--Name varchar(25) null,
--CreatedDate datetime not null,
--UserId int null
--);


--create table [Card]
--(
--CardId int primary key identity(1, 1),
--ListID int not null foreign key references List(ListId),
--CreatDate datetime not null,
--[Text] varchar(100) null,
--)

alter table List add UserId int null