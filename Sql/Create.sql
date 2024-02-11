create database gamestore;

use gamestore;

create table Games (
    [Id] int primary key identity,
    [Name] nvarchar(50) not null,
    [Price] money,
    [Category] nvarchar(50) not null
)