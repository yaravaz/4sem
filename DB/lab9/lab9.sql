
DECLARE 
	@c char = 'c',
	@d datetime = getdate(),
	@t time,
	@i int,
	@s smallint,
	@ti tinyint,
	@n numeric(12, 5);

SET @t = '20:25:20';
SET @i = 2147483647;
SET @s = 32767;
SET @ti = 255;
SET @n = 12345.67;

select @t[time], @i[int], @s[smallint], @ti[tinyint], @n[numeric];

SELECT @t = '20:25:21',
	   @i = 123441234,
	   @s = 2341,
	   @ti = 123,
	   @n = 5324.34;

print @t;
print @i;
print @s;
print @ti;
print @n;

------------------------------------------------------
use Univer;

select * from AUDITORIUM;

declare @capasity int = (select SUM(AUDITORIUM_CAPACITY) from AUDITORIUM), 
		@count int, 
		@avgcapasity float, 
		@countlow int,
		@pros float;

if @capasity > 200
	begin
		select @count = (select count(AUDITORIUM) from AUDITORIUM),
			   @avgcapasity = (select round(avg(cast(AUDITORIUM_CAPACITY as float(4))), 2) from AUDITORIUM);
		select @countlow = (select count(*) from AUDITORIUM where AUDITORIUM_CAPACITY < @avgcapasity);
		select @pros = cast(@countlow as float(4)) / cast(@count as float(4));
			  
		select @count 'Количество аудиторий', @avgcapasity 'Средняя вместительность', 
				@countlow 'Количество < avg', @pros 'Процент (<avg)'
	end
	else
		print @capasity

---------------------------------------------------

print 'число строк: '+cast(@@rowcount as nvarchar(20));
print 'версия SQL Server: '+cast(@@version as nvarchar(100));
print 'идентификатор процесса: '+cast(@@spid as nvarchar(20));
print 'код последней ошибки: '+cast(@@error as nvarchar(20));
print 'имя сервера: '+cast(@@servername as nvarchar(100));
print 'уровень вложенности транзакции: '+cast(@@trancount as nvarchar(20));
print 'статус выборки: '+cast(@@fetch_status as nvarchar(20));
print 'уровень вложенности текущей процедуры: '+cast(@@nestlevel as nvarchar(20));

--------------------------------------------------

declare @tv float = 12.3, @xv float = -1.4, @zv float;

if (@tv>@xv)
	set @zv = sin(@tv)
else if (@tv < @xv)
	set @zv = 4*(@tv+@xv)
else 
	set @zv = 1 - exp(@xv-2)

print 'z=' + cast(@zv as nvarchar(10));

-- - - - - - - -

declare @fio varchar(50) = 'Макейчик Татьяна Леонидовна',
		@fp int;
set @fp = charindex(' ', @fio);

select substring(@fio, 1, @fp) +
	   substring(@fio, @fp + 1 , 1) + '.' +
	   substring(@fio, charindex(' ', @fio, @fp+1)+1, 1) + '.' 'ФИО'

-- - - - - - - -

select * from student

select name, bday, year(getdate())-year(bday) [Возраст]
from student
where month(bday) = month(getdate()) + 1

-- - - - - - - -

select * from PROGRESS;

declare @group int = 5, 
		@dayweek date;
set @dayweek = (select top(1) PROGRESS.PDATE
				from PROGRESS join STUDENT
				on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
				where STUDENT.IDGROUP = @group and PROGRESS.SUBJECT = 'СУБД')
select datename(dw, @dayweek) [День недели]

-----------------------------------------------------

select * from AUDITORIUM

declare @audCapasity int = (select sum(AUDITORIUM_CAPACITY) 
							from AUDITORIUM)
if @audCapasity < 100
	begin
		print 'Общая вместительность аудиторий < 100'
		print 'Вместительность: ' + cast(@audCapasity as nvarchar(10)) 
	end
else if @audCapasity > 100 and @audCapasity < 200
	begin
		print 'Общая вместительность аудиторий 100 - 200'
		print 'Вместительность: ' + cast(@audCapasity as nvarchar(10)) 
	end
else if @audCapasity > 200
	begin
		print 'Общая вместительность аудиторий > 200'
		print 'Вместительность: ' + cast(@audCapasity as nvarchar(10)) 
	end

------------------------------------------------------

select STUDENT.NAME, GROUPS.FACULTY,
	   case  
 			when PROGRESS.NOTE between 0 and 3 then 'незачёт'
			when PROGRESS.NOTE between 4 and 8 then 'зачёт'
	   else 'зачёт с отличием'
	   end Результат
from STUDENT
			join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
			join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
where GROUPS.FACULTY = 'ИТ'
group by name, faculty, 
	   case  
 			when PROGRESS.NOTE between 0 and 3 then 'незачёт'
			when PROGRESS.NOTE between 4 and 8 then 'зачёт'
	   else 'зачёт с отличием'
	   end

------------------------------------------------------

create table #table
(
	id int identity(0, 1),
	Number int,
	String nvarchar(20)
);

set nocount on
declare @newi int = 0;
while @newi <	10
	begin
		insert #table(Number, String)
			values (1000*rand(), replicate('строка ', 3))
		set @newi = @newi + 1;
	end
select * from #table
drop table #table

-------------------------------------------------------

declare @counter int = 0;
while @counter < 10
	begin
		print @counter;
		if(@counter = 5)
			begin
				print 'о нет, 5! заканчиваем'
				return;
			end
		set @counter = @counter + 1
	end

-------------------------------------------------------

declare @num int = 1, @zero int = 0
begin try
	set @num = @num / @zero
end try
begin catch
	print ERROR_NUMBER();
	print ERROR_MESSAGE();
	print ERROR_LINE();
	print ERROR_PROCEDURE();
	print ERROR_SEVERITY();
	print ERROR_STATE();
end catch