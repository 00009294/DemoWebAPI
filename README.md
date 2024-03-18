
1.	В СУБД Microsoft SQL Server создайте БД TestDb, выполнив следующий SQL-скрипт (выделенные жирным красным шрифтом полные имена файлов БД нужно скорректировать исходя из желаемого места их размещения):
CREATE DATABASE [TestDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
 ( NAME = N'TestDb', 
   FILENAME = N'D:\SQL\DATA\TestDb.mdf' , 
   SIZE = 8192KB , 
   MAXSIZE = UNLIMITED, 
   FILEGROWTH = 65536KB )
 LOG ON 
 ( NAME = N'TestDb _log', 
   FILENAME = N'D:\SQL\DATA\TestDb_log.ldf' , 
   SIZE = 8192KB , 
   MAXSIZE = 2048GB , 
   FILEGROWTH = 65536KB )
GO

USE [TestDb]
GO

CREATE TABLE [dbo].[Product] (
  [ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
  CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID])
)
ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [Product_Name_IDX] ON [dbo].[Product]
  (Name)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

В результате выполнения SQL-скрипта будет создана БД TestDb. В ней будет создана таблица сущностей «Изделия» с именем Product со следующими полями:
o	ID – уникальное обозначение изделия, тип данных – Guid, поле обязательное для заполнения (первичный ключ);
o	Name – наименование изделия, тип данных - строка 255 символов, поле обязательное для заполнения;
o	Description – описание изделия, тип - строка с максимально возможным кол-вом символов, поле НЕ обязательное для заполнения.

2.	Реализуйте REST Web API сервис (ASP.NET Core) для возможности управления данными в БД в таблице Product. В сервисе должны присутствовать методы, реализующие:
o	Получение списка изделий по переданному фильтру (по наименованию изделия). 
o	Добавление нового изделия
o	Редактирование существующего изделия
o	Удаление существующего изделия по указанному идентификатору изделия

Доступ к БД осуществлять посредством использования Entity Framework Core.

3.	Необходимо создать WEB-приложение ASP.NET CORE 7.0 MVC для управления данными об изделиях по средством сервиса, созданного в пункте №2.
Основные требования:
o	Приложение должно получать данные об изделии через сервис (смотри пункт 2). Все "общение" с сервисом ведется только на серверной стороне приложения (политика безопасности).
o	В приложении должны присутствовать страница-перечень изделий.
o	На списковой странице необходимо реализовать фильтрацию по наименованию изделия (не клиентская фильтрация данных).
o	Добавление и редактирование изделий реализовать в виде модальных окон.
