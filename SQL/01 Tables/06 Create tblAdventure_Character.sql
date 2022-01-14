use dbPnPManager
go

if not exists (select * from sysobjects where name='tblAdventure_Character' and xtype='U')
begin
    create table tblAdventure_Character (      
		AdventureLink int,
		CharacterLink int,
		foreign key (AdventureLink) references tblAdventure(Id) on delete cascade,
		foreign key (CharacterLink) references tblCharacter(Id) on delete cascade,

    )
end