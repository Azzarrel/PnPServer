use dbPnPManager
go

if not exists (select * from sysobjects where name='tblCharacter' and xtype='U')
begin
    create table tblCharacter (
        Id int primary key identity (1, 1),
        Name nvarchar(100),
		Profession nvarchar(100),
		HairColor nvarchar(30),
		SkinColor nvarchar(30),
		Age nvarchar(6),
		Size nvarchar(6),
		Gender nvarchar(30),
		Weight nvarchar(6),
		Reputation nvarchar(500),
		Titles nvarchar(500),
		Extras nvarchar(500),
    )
end