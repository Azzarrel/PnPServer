use dbPnPManager
go

if not exists (select * from sysobjects where name='tblAdventure' and xtype='U')
begin
    create table tblAdventure (
        Id int primary key identity (1, 1),
        Name nvarchar(100),
		CampaignLink int,
		foreign key (CampaignLink) references tblCampaign(Id) on delete cascade,
    )
end