create database BookStore
use BookStore

create table BookModel
(
Id int primary key identity(1,1),
Title nvarchar(200),
Author nvarchar(100),
PublishedDate datetime,
ISBN nvarchar(max)
);

create proc sp_Book
@Id int=null,
@Title nvarchar(200)=null,
@Author nvarchar(100)=null,
@PublishedDate datetime=null,
@ISBN nvarchar(max)=null,
@Action int
as
begin
  if(@Action = 1)
  begin
   insert into BookModel values(@Title,@Author,@PublishedDate,@ISBN)
  end
  else if(@Action = 2)
  begin
   Select * from BookModel where Id=isnull(@Id,Id)
  end
  else if(@Action = 3)
  begin
   update BookModel set Title=@Title,Author=@Author,PublishedDate=@PublishedDate,ISBN=@ISBN where Id=@Id
  end
  else if(@Action = 4)
  begin
   Delete from BookModel where Id=@Id
  end
end

