use master 
go

if not exists(select * from sys.databases where name = 'dbPnPManager')
begin
    create database dbPnPManager
end

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

use dbPnPManager
go

create or alter procedure usp_SelectUser 
							@Name nvarchar(200)
as
begin

select * from tblUser
		 where Name = @Name

end

