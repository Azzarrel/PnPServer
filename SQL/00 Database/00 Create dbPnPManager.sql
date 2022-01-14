use master 
go

if not exists(select * from sys.databases where name = 'dbPnPManager')
begin
    create database dbPnPManager
end