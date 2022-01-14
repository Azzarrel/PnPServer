use dbPnPManager
go

if not exists (select * from sysobjects where name='tblUser_Character' and xtype='U')
begin
    create table tblUser_Character (      
		UserLink int,
		CharacterLink int,
		foreign key (UserLink) references tblUser(Id) on delete cascade,
		foreign key (CharacterLink) references tblCharacter(Id) on delete cascade,

    )
end