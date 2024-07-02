
USE UNIVER;
exec sp_helpindex 'AUDITORIUM'
exec sp_helpindex 'AUDITORIUM_TYPE'
exec sp_helpindex 'FACULTY'
exec sp_helpindex 'GROUPS'
exec sp_helpindex 'PROFESSION'
exec sp_helpindex 'PROGRESS'
exec sp_helpindex 'PULPIT'
exec sp_helpindex 'STUDENT'
exec sp_helpindex 'SUBJECT'	
exec sp_helpindex 'TEACHER'

drop table #localTable;
create table #localTable (
	ID int identity(1,1),
	Val nvarchar(20)
);

Declare @i int = 1;
while(@i <= 1000)
	begin
		insert #localTable values('text' + cast(@i as nvarchar));
		set @i = @i + 1;
	end

select * from #localTable where ID > 300 and ID < 400;

checkpoint;  --фиксация БД
DBCC DROPCLEANBUFFERS;  --очистить буферный кэш

Create clustered index #localTable_CL on #localTable(ID asc)
drop index #localTable_CL on #localTable

---------------------------------------------

drop table #localTable2;
create table #localTable2(
	Id int identity(1,1),
	Counter int 
);

Declare @ii int = 1;
while(@ii <= 10000)
	begin
		insert #localTable2 values(@ii * 1.2);
		set @ii = @ii + 1;
	end

Create index #localTable2_NONCLU on #localTable2(Id, Counter);
DROP index #localTable2_NONCLU on #localTable2

select * from #localTable2 
where Id > 2400 and Counter < 3000

select * from #localTable2 
order by Id, Counter;

select * from #localTable2 
where Id = 4885 and Counter > 4000

----------------------------------------------

drop table #localTable3;
create table #localTable3(
	Id int identity(1,1),
	Counter int 
);

Declare @j int = 1;
set nocount on
while(@j <= 10000)
	begin
		insert #localTable3 values(@j * 1.2);
		set @j = @j + 1;
	end

select count(*)[кол-во строк] from #localTable3;
select * from #localTable3;

create index #localTable3_ID_X on #localTable3(id) include (counter);
DROP index #localTable3_ID_X on #localTable3

select counter from #localTable3
where Id < 100

-------------------------------------------

drop table #localTable4;
create table #localTable4(
	Id int identity(1, 1),
	Counter int
)
set nocount on
declare @g int = 1
while @g <= 10000
begin 
	insert #localTable4(Counter)
	values (@g*1.2);
	set @g = @g + 1;
end

select Id from #localTable4 where (Id > 1500 and Id < 2000)

CREATE index #localTable4_nonclu on #localTable4(Id) where (Id > 1500 and Id < 5000)
DROP index #localTable4_nonclu on #localTable4

-----------------------------

use tempdb;
drop table #localTable5;
create table #localTable5(
	Id int identity(1,1),
	String nvarchar(20),
	Counter int 
);

Declare @k int = 1;
set nocount on
while(@k <= 100)
	begin
		insert #localTable5 values(REPLICATE('text ',3), @k * 1.2);
		set @k = @k + 1;
	end

Create index #localTable5_NONCLU on #localTable5(Id);
DROP index #localTable5_NONCLU on #localTable5;

INSERT top(10000) #localTable5(String, Counter) select String, Counter from #localTable5;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID('tempdb'), 
OBJECT_ID(N'#localTable5'), NULL, NULL, NULL) ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

ALTER index #localTable5_NONCLU on #localTable5 reorganize;

ALTER index #localTable5_NONCLU on #localTable5 rebuild with (online = off);

-----------------------------------------

drop table #localTable6;
create table #localTable6(
	Id int identity(1,1),
	Counter int 
);

Declare @n int = 1;
set nocount on
while(@n <= 100000)
	begin
		insert #localTable6 values(@n * 1.2);
		set @n = @n + 1;
	end

DROP index #localTable6_Counter on #localTable6;
CREATE index #localTable6_Counter on #localTable6(Counter) with (fillfactor = 65);

INSERT top(50)percent INTO #localTable6(Counter) SELECT Counter FROM #localTable6;

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'),    
OBJECT_ID(N'#localTable6'), NULL, NULL, NULL) ss  JOIN sys.indexes ii 
ON ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

--------------------------------

use V_MyBASE;

--Table Товары

--create clustered index #t_CL on ТОВАРЫ(Цена);


----------------------------

select * from ЗАКАЗЫ where ID_заказа > 20 and Количество < 600
select * from ЗАКАЗЫ order by Количество
select * from ЗАКАЗЫ where ID_заказа = 75 and Количество < 600

create index #z_nonclu on ЗАКАЗЫ(ID_заказа, Количество)
drop index #z_nonclu on ЗАКАЗЫ

