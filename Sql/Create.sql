create database GameStoreDB;

use GameStoreDB;

create table Games (
    [Id] int primary key identity,
    [Name] nvarchar(50) not null,
    [Price] money,
    [Category] nvarchar(50) not null
)