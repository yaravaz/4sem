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

declare @f int = dbo.COUNT_STUDENTS('��');
print '���������� ��������� �� ��� ' + convert(varchar, @f);
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

declare @f int = dbo.COUNT_STUDENTS('��', '1-40 01 02');
print '���������� ��������� ��� �� ������������� 1-40 01 02 ' + convert(varchar, @f);
select IDSTUDENT, NAME, dbo.COUNT_STUDENTS('��', '1-40 01 02')
from Student
where student.IDGROUP = 3;

drop function dbo.COUNT_STUDENTS;
go

---------------------------------------------------------

drop function dbo.FSUBJECTS;
go
create function FSUBJECTS(@p varchar(20)) returns nvarchar(300)
as begin
	declare @subj varchar(20), @otch nvarchar(300) = '����������: ';
	declare SubCursor cursor local
		for select SUBJECT from SUBJECT
			where PULPIT = @p;
	open SubCursor
	fetch SubCursor into @subj;
	while @@fetch_status = 0
		begin
			if @otch = '����������: '
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
select * from dbo.FFACPUL('����', NULL);
select * from dbo.FFACPUL(NULL, '�����');
select * from dbo.FFACPUL('����', '�����');

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

select PULPIT, dbo.FCTEACHER(PULPIT) [���������� ��������������]
from PULPIT

select dbo.FCTEACHER(NULL)[����� ��������������]

---------------------------------------

use V_MyBASE;
go

create function COUNT_Zakazy(@f nvarchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(������.�����)
			from ������
						join ��������� on ������.�������� = ���������.������������_�����
			where ���������.������������_����� = @f);
return @rc;
end;
go

declare @f int = dbo.COUNT_Zakazy('�����-����� ������');
print '���������� ������� � �����-����� ������ ' + convert(varchar, @f);
go

---------

alter function COUNT_Zakazy (@f nvarchar(20), @n varchar(20)) returns int
as begin
declare @rc int = 0
set @rc = (select count(������.�����)
			from ������
						join ��������� on ������.�������� = ���������.������������_�����
						join ������ on ������.������������_������ = ������.�����
			where ���������.������������_����� = @f and ������.����� = @n);
return @rc;
end;
go

declare @f int = dbo.COUNT_Zakazy('�����-����� ������', '����');
print '���������� ������� ����� � �����-����� ������ ' + convert(varchar, @f);

drop function dbo.COUNT_Zakazy;
go

---------------------------------------------------------

drop function dbo.FZakazy;
go
create function FZakazy(@tz varchar(20)) returns nvarchar(300)
as begin
	declare @tv varchar(20), @otch nvarchar(300) = '������: ';
	declare TovCursor cursor local
		for select ����� from ������
			where �������� = @tz;
	open TovCursor
	fetch TovCursor into @tv;
	while @@fetch_status = 0
		begin
			if @otch = '������: '
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

select ������������_�����, dbo.FZakazy(������������_�����) from ���������;

---------------------------------------------------------

drop function FTovCena;
go
create function FTovCena(@f varchar(10), @p int) returns table
as return
	select f.�����, p.����	
	from ������ p left outer join ������ f
					on f.����� = p.������������_������
					where f.����� = isnull(@f, f.�����)
					and p.���� = isnull(@p, p.����);
go

select * from dbo.FTovCena(NULL, NULL);
select * from dbo.FTovCena('����', NULL);
select * from dbo.FTovCena(NULL, 333);
select * from dbo.FTovCena('����', 333);

-----------------------------------------

drop function dbo.FKolTov;
go
create function FKolTov(@p varchar(20)) returns int
as begin
	declare @rc int = (select count(*) from ������
						where �������� = isnull(@p, ��������));
	return @rc;
end;
go

select ��������, dbo.FKolTov(��������) [���������� �������]
from ������

select dbo.FKolTov(NULL)[�����]

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
create function FACULTY_REPORT(@c int) returns @fr table ( [���������] varchar(50), [���������� ������] int, [���������� �����]  int, 
	                                                       [���������� ���������] int, [���������� ��������������] int )
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