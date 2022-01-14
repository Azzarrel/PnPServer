use dbPnPManager
go

if not exists (select * from sysobjects where name='tblCampaign' and xtype='U')
begin
    create table tblCampaign (
        Id int primary key identity (1, 1),
        Name nvarchar(100),
		LogoPath nvarchar(200),
    )
end