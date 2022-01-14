use dbPnPManager
go

create or alter procedure usp_CreateUser 
							@Name nvarchar(30),
							@Password nvarchar(30),
							@Guid nvarchar(200)
as
begin

insert into tblUser (Name, Password, Guid)
values (@Name, @Password, @Guid)

select * from tblUser where Name = @Name
end