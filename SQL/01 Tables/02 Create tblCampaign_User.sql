use dbPnPManager
go

if not exists (select * from sysobjects where name='tblCampaign_User' and xtype='U')
begin
    create table tblCampaign_User (
	CampaignLink int,
	UserLink int,
	IsGameMaster bit,
	foreign key (CampaignLink) references tblCampaign(Id) on delete cascade,
	foreign key (UserLink) references tblUser(Id) on delete cascade,
    )
end