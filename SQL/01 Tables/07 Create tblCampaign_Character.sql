use dbPnPManager
go

if not exists (select * from sysobjects where name='tblAdventure_Character' and xtype='U')
begin
    create table tblAdventure_Character (      
		CampaignLink int,
		CharacterLink int,
		foreign key (CampaignLink) references tblCampaign(Id) on delete cascade,
		foreign key (CharacterLink) references tblCharacter(Id) on delete cascade,

    )
end