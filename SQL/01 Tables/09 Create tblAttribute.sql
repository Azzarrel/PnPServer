use dbPnPManager
go

if not exists (select * from sysobjects where name='tblAttribute' and xtype='U')
begin
    create table tblAttribute (      
        Id int primary key identity (1, 1),
        Name nvarchar(100),
		Tag nvarchar(100),
		Base int,
		Augmentation int,
		CharLink int,
		ExpCalc nvarchar
		foreign key (CharLink) references tblCharacter(Id) on delete cascade,
    )
end