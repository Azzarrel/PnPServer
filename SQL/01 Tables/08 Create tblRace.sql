use dbPnPManager
go

if not exists (select * from sysobjects where name='tblRace' and xtype='U')
begin
    create table tblRace (      
        Id int primary key identity (1, 1),
        Name nvarchar(100),
		DefaultCharLink int,
		foreign key (DefaultCharLink) references tblCharacter(Id) on delete cascade,

    )
end