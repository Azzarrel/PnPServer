use dbPnPManager
go

if not exists (select * from sysobjects where name='tblUser' and xtype='U')
begin
    create table tblUser (
        Id int primary key identity (1, 1),
        Name nvarchar(100) unique,
		Password nvarchar(100),
		Guid nvarchar(200),
    )
end