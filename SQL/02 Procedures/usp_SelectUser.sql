use dbPnPManager
go

create or alter procedure usp_SelectUser 
							@Name nvarchar(200)
as
begin

select * from tblUser
		 where Name = @Name

end