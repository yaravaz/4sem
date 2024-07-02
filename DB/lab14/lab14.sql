use UNIVER;
go

select * from faculty;
select * from groups;
select * from student;

drop function COUNT_STUDENTS;
go
create function COUNT_STUDENTS (@faculty nvarchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(student.IDSTUDENT)
			from Faculty
						join Groups on faculty.FACULTY = groups.FACULTY
						join Student on groups.IDGROUP = student.IDGROUP
			where faculty.faculty = @faculty);
return @rc;
end;
go

declare @f int = dbo.COUNT_STUDENTS('ИТ');
print 'количество студентов на ФИТ ' + convert(varchar, @f);
go

---------

alter function COUNT_STUDENTS (@faculty nvarchar(20), @prof varchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(student.IDSTUDENT)
			from Faculty
						join Groups on faculty.FACULTY = groups.FACULTY
						join Student on groups.IDGROUP = student.IDGROUP
			where faculty.faculty = @faculty and groups.PROFESSION = @prof);
return @rc;
end;
go

declare @f int = dbo.COUNT_STUDENTS('ИТ', '1-40 01 02');
print 'количество студентов ФИТ на специальности 1-40 01 02 ' + convert(varchar, @f);
select IDSTUDENT, NAME, dbo.COUNT_STUDENTS('ИТ', '1-40 01 02')
from Student
where student.IDGROUP = 3;

drop function dbo.COUNT_STUDENTS;
go

---------------------------------------------------------

drop function dbo.FSUBJECTS;
go
create function FSUBJECTS(@p varchar(20)) returns nvarchar(300)
as begin
	declare @subj varchar(20), @otch nvarchar(300) = 'Дисциплины: ';
	declare SubCursor cursor local
		for select SUBJECT from SUBJECT
			where PULPIT = @p;
	open SubCursor
	fetch SubCursor into @subj;
	while @@fetch_status = 0
		begin
			if @otch = 'Дисциплины: '
			begin
				set @otch = @otch + rtrim(@subj)
				fetch SubCursor into @subj;
			end;
			else
			begin
				set @otch = @otch + ', ' + rtrim(@subj)
				fetch SubCursor into @subj;
			end;
		end;
	return @otch;
end;
go

select PULPIT , dbo.FSUBJECTS(PULPIT) from PULPIT;

---------------------------------------------------------

drop function FFACPUL;
go
create function FFACPUL(@f varchar(10), @p varchar(10)) returns table
as return
	select f.faculty, p.pulpit	
	from faculty f left outer join pulpit p
					on f.FACULTY = p.FACULTY
					where f.FACULTY = isnull(@f, f.FACULTY)
					and p.PULPIT = isnull(@p, p.PULPIT);
go

select * from dbo.FFACPUL(NULL, NULL);
select * from dbo.FFACPUL('ИДиП', NULL);
select * from dbo.FFACPUL(NULL, 'ЛМиЛЗ');
select * from dbo.FFACPUL('ТТЛП', 'ЛМиЛЗ');

-----------------------------------------

drop function dbo.FCTEACHER;
go
create function FCTEACHER(@p varchar(20)) returns int
as begin
	declare @rc int = (select count(*) from TEACHER
						where PULPIT = isnull(@p, PULPIT));
	return @rc;
end;
go

select PULPIT, dbo.FCTEACHER(PULPIT) [Количество преподавателей]
from PULPIT

select dbo.FCTEACHER(NULL)[Всего преподавателей]

---------------------------------------

use V_MyBASE;
go

create function COUNT_Zakazy(@f nvarchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(заказы.Товар)
			from ЗАКАЗЫ
						join Заказчики on Заказы.Заказчик = Заказчики.Наименование_фирмы
			where Заказчики.Наименование_фирмы = @f);
return @rc;
end;
go

declare @f int = dbo.COUNT_Zakazy('Прима-Стайл Мебель');
print 'количество заказов у Прима-Стайл Мебель ' + convert(varchar, @f);
go

---------

alter function COUNT_Zakazy (@f nvarchar(20), @n varchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(заказы.Товар)
			from ЗАКАЗЫ
						join Заказчики on Заказы.Заказчик = Заказчики.Наименование_фирмы
						join Товары on товары.Наименование_товара = Заказы.Товар
			where Заказчики.Наименование_фирмы = @f and заказы.Товар = @n);
return @rc;
end;
go

declare @f int = dbo.COUNT_Zakazy('Прима-Стайл Мебель', 'Стол');
print 'количество заказов стола у Прима-Стайл Мебель ' + convert(varchar, @f);

drop function dbo.COUNT_Zakazy;
go

---------------------------------------------------------

drop function dbo.FZakazy;
go
create function FZakazy(@tz varchar(20)) returns nvarchar(300)
as begin
	declare @tv varchar(20), @otch nvarchar(300) = 'Товары: ';
	declare TovCursor cursor local
		for select Товар from Заказы
			where Заказчик = @tz;
	open TovCursor
	fetch TovCursor into @tv;
	while @@fetch_status = 0
		begin
			if @otch = 'Товары: '
			begin
				set @otch = @otch + rtrim(@tv)
				fetch TovCursor into @tv;
			end;
			else
			begin
				set @otch = @otch + ', ' + rtrim(@tv)
				fetch TovCursor into @tv;
			end;
		end;
	return @otch;
end;
go

select Наименование_фирмы, dbo.FZakazy(Наименование_фирмы) from ЗАКАЗЧИКИ;

---------------------------------------------------------

drop function FTovCena;
go
create function FTovCena(@f varchar(10), @p int) returns table
as return
	select f.Товар, p.Цена	
	from Товары p left outer join Заказы f
					on f.Товар = p.Наименование_товара
					where f.Товар = isnull(@f, f.Товар)
					and p.Цена = isnull(@p, p.Цена);
go

select * from dbo.FTovCena(NULL, NULL);
select * from dbo.FTovCena('Стол', NULL);
select * from dbo.FTovCena(NULL, 333);
select * from dbo.FTovCena('Стол', 333);

-----------------------------------------

drop function dbo.FKolTov;
go
create function FKolTov(@p varchar(20)) returns int
as begin
	declare @rc int = (select count(*) from Заказы
						where Заказчик = isnull(@p, Заказчик));
	return @rc;
end;
go

select Заказчик, dbo.FKolTov(Заказчик) [Количество заказов]
from Заказы

select dbo.FKolTov(NULL)[Всего]

--------------------------------------------------------------------

use UNIVER
go
create function COUNT_PULPIT(@f nvarchar(20)) returns int
as begin
	declare @rc int = (select count(*) from PULPIT where PULPIT.FACULTY=@f);
	return @rc;
end;
go
create function COUNT_GROUPS(@f nvarchar(20)) returns int
as begin
	declare @rc int = (select count(*) from GROUPS where GROUPS.FACULTY=@f);
	return @rc;
end;
go
create function COUNT_STUDENTS(@faculty nvarchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(student.IDSTUDENT)
			from Faculty
						join Groups on faculty.FACULTY = groups.FACULTY
						join Student on groups.IDGROUP = student.IDGROUP
			where faculty.faculty = @faculty);
return @rc;
end;
go
create function COUNT_PROFESSIONS(@f nvarchar(20)) returns int
as begin
	declare @rc int = (select count(*) from PROFESSION where PROFESSION.FACULTY=@f);
	return @rc;
end;
go
create function FACULTY_REPORT(@c int) returns @fr table ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	                                                       [Количество студентов] int, [Количество специальностей] int )
as begin 
	declare cc CURSOR static for 
	select f.FACULTY from FACULTY f 
	where dbo.COUNT_STUDENTS(f.FACULTY) > @c; 
	declare @f varchar(30);
	open cc;  
	fetch cc into @f;
	while @@fetch_status = 0
		begin
			insert @fr values( @f,  dbo.COUNT_PULPIT(@f), dbo.COUNT_GROUPS(@f),   
			dbo.COUNT_STUDENTS(@f), dbo.COUNT_PROFESSIONS(@f)); 
			fetch cc into @f;  
	    end;   
    return; 
end;
go
select * from dbo.FACULTY_REPORT(0);