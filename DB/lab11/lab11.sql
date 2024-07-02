
use Univer;

Declare DistIc Cursor for select Subject from Subject where PULPIT = '����';

Declare @di nvarchar(20), @collection nvarchar(200) = '';
OPEN DistIc;
Fetch DistIc into @di;
print '���������� ����:';
while @@FETCH_STATUS = 0
	begin
		set @collection = rtrim(@di) + ',' + @collection;
		Fetch DistIc into @di;
	end
print @collection;
CLOSE DistIc;
deallocate DistIc;

---------------------------------------

Declare Dists Cursor Local
						for Select Subject, Subject_Name from SUBJECT where Pulpit = '����';

Declare @dist nvarchar(20), @name nvarchar(50);
OPEN Dists;
fetch Dists into @dist, @name;
print '1.' + @dist + ' ' + @name;
go
Declare @dist nvarchar(20), @name nvarchar(50);
fetch Dists into @dist, @name;
print '2.' + @dist + ' ' + @name;
go

----

Declare Dists Cursor Global
					for Select Subject, Subject_Name from SUBJECT where Pulpit = '����';

Declare @dist nvarchar(20), @name nvarchar(50);
OPEN Dists;
fetch Dists into @dist, @name;
print '1.' + @dist + ' ' + @name;
go
Declare @dist nvarchar(20), @name nvarchar(50);
fetch Dists into @dist, @name;
print '2.' + @dist + ' ' + @name;
CLOSE Dists;
deallocate Dists;
go

--------------------------------------

Declare @dis nvarchar(20), @namedist nvarchar(50);

Declare Dist_ Cursor Local static
				for Select Subject, Subject_Name from SUBJECT where Pulpit = '����';

open Dist_;
print '���-�� �����: '+ cast(@@cursor_rows as nvarchar(5));
update Subject set SUBJECT_Name = '������' where SUBJECT = '��';
Delete SUBJECT where SUBJECT = '��';
Insert subject (subject, subject_name, pulpit) values('��', '����� ����������', '����');

fetch Dist_ into @dis, @namedist;
while(@@FETCH_STATUS = 0)
	begin
		print @dis + ' ' + @namedist
		fetch Dist_ into @dis, @namedist;
	end;
close Dist_;
deallocate Dist_;

select * from SUBJECT;

update subject set SUBJECT_NAME = '������������� ����������' where subject = '��';
insert subject (subject, subject_name, pulpit) values('��', '������������� ��������', '����');
delete subject where subject = '��';

-----

Declare @dist nvarchar(20), @namedis nvarchar(50);

Declare Dist_ Cursor
				for Select Subject, Subject_Name from SUBJECT where Pulpit = '����';

open Dist_;
print '���-�� �����: '+ cast(@@cursor_rows as nvarchar(5));
update Subject set SUBJECT_Name = '������' where SUBJECT = '��';
Delete SUBJECT where SUBJECT = '��';
Insert subject (subject, subject_name, pulpit) values('��', '����� ����������', '����');

fetch Dist_ into @dist, @namedis;
while(@@FETCH_STATUS = 0)
	begin
		print @dist + ' ' + @namedis
		fetch Dist_ into @dist, @namedis;
	end;

go


fetch Dist_ into @dist, @namedis;
while(@@FETCH_STATUS = 0)
	begin
		print @dist + ' ' + @namedis
		fetch Dist_ into @dist, @namedis;
	end;

print @dist;

close Dist_;
deallocate Dist_;

select * from SUBJECT;

update subject set SUBJECT_NAME = '������������� ����������' where subject = '��';
insert subject (subject, subject_name, pulpit) values('��', '������������� ��������', '����');
delete subject where subject = '��';

-------------------------------

Declare @di nvarchar(15), @diname nvarchar(30);
Declare Dist Cursor Local static scroll
				for Select Subject, Subject_Name from SUBJECT where Pulpit = '����';

open Dist;
print '���-�� �����: '+ cast(@@cursor_rows as nvarchar(5));
fetch Dist into @di, @diname;
print '��������� ������ ' + @di + ' ' + @diname;
fetch last from Dist into @di, @diname;
print '��������� ������ ' + @di + ' ' + @diname;
fetch next from Dist into @di, @diname;
print '��������� ����� ������� ������ ' + @di + ' ' + @diname;
fetch prior from Dist into @di, @diname;
print '���������� ������ ' + @di + ' ' + @diname;
fetch absolute 3 from Dist into @di, @diname;
print '3 � ������ ������ ' + @di + ' ' + @diname;
fetch absolute -3 from Dist into @di, @diname;
print '3 � ����� ������ ' + @di + ' ' + @diname;
fetch relative 3 from Dist into @di, @diname;
print '������ ����� ������� ������ ' + @di + ' ' + @diname;
fetch relative -3 from Dist into @di, @diname;
print '������ ����� ������� ������ ' + @di + ' ' + @diname;
close Dist;
deallocate Dist;

---------------------------------------

Declare @disti nvarchar(10), @distiname nvarchar(20);
Declare Dist Cursor local dynamic
							for select subject, subject_name from subject where PULPIT='����' for update;

Open Dist;
fetch Dist into @disti, @distiname;
delete Subject where Current of Dist;
fetch Dist into @disti, @distiname;
update Subject set SUBJECT_NAME = '����� ���' where current of Dist;
Close Dist;
deallocate Dist;

select * from subject;

insert subject(SUBJECT, SUBJECT_NAME, PULPIT)
								values('��', '���� ������', '����');
update subject set SUBJECT_NAME = '���������� ����������' where subject = '��'

select * from subject;

------------------------------------------------

DECLARE @StudentID int, @Grade int
DECLARE Cur CURSOR local 
			for select P.IDSTUDENT, P.NOTE
				FROM PROGRESS P
					JOIN STUDENT S ON P.IDSTUDENT = S.IDSTUDENT
					JOIN GROUPS G ON S.IDGROUP = G.IDGROUP
				where P.NOTE < 4;

OPEN Cur

FETCH NEXT FROM Cur INTO @StudentID, @Grade
WHILE @@FETCH_STATUS = 0
BEGIN
	DELETE Progress FROM PROGRESS
		WHERE IDSTUDENT = @StudentID
    FETCH NEXT FROM Cur INTO @StudentID, @Grade
END
CLOSE Cur
DEALLOCATE Cur

select IDSTUDENT,NOTE from PROGRESS

insert into PROGRESS (SUBJECT,IDSTUDENT,PDATE, NOTE)
values  ('����', 1000,  '01.10.2013',3),
        ('���', 1001,  '01.12.2013',2),
		('����',   1002,  '06.5.2013',2),
        ('���',   1003,  '01.1.2013',2),
        ('���',   1004,  '01.1.2013',2)

-----

declare @idstud int, @notestud int
declare EditNote cursor local dynamic 
						for select IDSTUDENT, NOTE from PROGRESS where IDSTUDENT = 1000
open EditNote
fetch EditNote into @idstud, @notestud
update PROGRESS set NOTE=NOTE+1 where current of EditNote
close EditNote
deallocate EditNote;

select IDSTUDENT, NOTE from progress where IDSTUDENT = 1000;
update progress set note = 3 where IDSTUDENT = 1000;

-------------------------------------------------

use V_MyBASE;

Declare @tv char(20), @t char(300) = '';
Declare ZkTovar cursor 
				for select ����� from ������;
open ZkTovar;
fetch ZkTovar into @tv;
print '���������� ������';
while (@@FETCH_STATUS = 0)
	begin
		set @t = rtrim(@tv) + ' ' + @t;
		fetch ZkTovar into @tv;
	end;
print @t;
close ZkTovar;
deallocate ZkTovar;

----------------------------------

Declare Tovary cursor local
				for select ������������_������, ���� from ������;
declare @tv2 char(20), @cena real;
open Tovary;
fetch Tovary into @tv2, @cena;
print '1. ' + @tv2 + cast(@cena as varchar(10));
go
declare @tv2 char(20), @cena real;
fetch Tovary into @tv2, @cena;
print '2. ' + @tv2 + cast(@cena as varchar(10));
close Tovary;
go



Declare Tovary cursor global
				for select ������������_������, ���� from ������;
declare @tv2 char(20), @cena real;
open Tovary;
fetch Tovary into @tv2, @cena;
print '1. ' + @tv2 + cast(@cena as varchar(10));
go
declare @tv2 char(20), @cena real;
fetch Tovary into @tv2, @cena;
print '2. ' + @tv2 + cast(@cena as varchar(10));
close Tovary;
deallocate Tovary;
go

------------------------------------------

DECLARE @tid char(10), @tnm char(40), @tgn char(10);  
DECLARE Zakaz CURSOR LOCAL STATIC                              
		 for SELECT �����, ����, ���������� 
		       FROM ������ where �������� = '�����-����� ������';				   
open Zakaz;
print   '���������� ����� : '+cast(@@CURSOR_ROWS as varchar(5)); 
UPDATE ������ set ���������� = 5 where ID_������ = 6;
DELETE ������ where ����� = '�����';
INSERT ������ (ID_������, �����, ����������, ����, �����, ���_��������, ��������) 
	                 values (18, '����', 340, '2014-08-02', '��. ���������� 2', '�����', '�����-����� ������'); 

FETCH  Zakaz into @tid, @tnm, @tgn;     
while @@fetch_status = 0                                    
   begin 
      print @tid + ' '+ @tnm + ' '+ @tgn;      
      fetch Zakaz into @tid, @tnm, @tgn; 
   end;          
close  Zakaz;

select * from ������;

UPDATE ������ set ���������� = 12 where ID_������ = 6;
INSERT ������ (ID_������, �����, ����������, ����, �����, ���_��������, ��������) 
	                 values (5, '�����', 12, '2023-12-05', '������� ������, ��� 7, ����� ��������', '���������', '�����-����� ������'); 
Delete ������ where ID_������ = 18; 

-----

DECLARE @tid2 char(10), @tnm2 char(40), @tgn2 char(10);  
DECLARE Zakaz CURSOR LOCAL Dynamic                              
		 for SELECT �����, ����, ���������� 
		       FROM ������ where �������� = '�����-����� ������';				   
open Zakaz;
print   '���������� ����� : '+cast(@@CURSOR_ROWS as varchar(5)); 
UPDATE ������ set ���������� = 5 where ID_������ = 6;
DELETE ������ where ����� = '�����';
INSERT ������ (ID_������, �����, ����������, ����, �����, ���_��������, ��������) 
	                 values (18, '����', 340, '2014-08-02', '��. ���������� 2', '�����', '�����-����� ������'); 

FETCH  Zakaz into @tid2, @tnm2, @tgn2;     
while @@fetch_status = 0                                    
   begin 
      print @tid2 + ' '+ @tnm2 + ' '+ @tgn2;      
      fetch Zakaz into @tid2, @tnm2, @tgn2; 
   end;          
close  Zakaz;

select * from ������;

UPDATE ������ set ���������� = 12 where ID_������ = 6;
INSERT ������ (ID_������, �����, ����������, ����, �����, ���_��������, ��������) 
	                 values (5, '�����', 12, '2023-12-05', '������� ������, ��� 7, ����� ��������', '���������', '�����-����� ������'); 
Delete ������ where ID_������ = 18; 

-----------------------------------------------------

Declare @di nvarchar(15), @diname nvarchar(30);
Declare Zakaz Cursor Local static scroll
				for Select �����, ���������� from ������ where �������� = '�����-����� ������';

open Zakaz;
print '���-�� �����: '+ cast(@@cursor_rows as nvarchar(5));
fetch Zakaz into @di, @diname;
print '��������� ������ ' + @di + ' ' + @diname;
fetch last from Zakaz into @di, @diname;
print '��������� ������ ' + @di + ' ' + @diname;
fetch next from Zakaz into @di, @diname;
print '��������� ����� ������� ������ ' + @di + ' ' + @diname;
fetch prior from Zakaz into @di, @diname;
print '���������� ������ ' + @di + ' ' + @diname;
fetch absolute 3 from Zakaz into @di, @diname;
print '3 � ������ ������ ' + @di + ' ' + @diname;
fetch absolute -3 from Zakaz into @di, @diname;
print '3 � ����� ������ ' + @di + ' ' + @diname;
fetch relative 3 from Zakaz into @di, @diname;
print '������ ����� ������� ������ ' + @di + ' ' + @diname;
fetch relative -3 from Zakaz into @di, @diname;
print '������ ����� ������� ������ ' + @di + ' ' + @diname;
close Zakaz;
deallocate Zakaz;

--------------------------------------------

declare @tn char(20), @tc int, @tk nvarchar(20);
declare Primer cursor local dynamic
							for select �����, ����������, �������� from ������ for update;

open Primer;
	fetch Primer into @tn, @tc, @tk;
	delete ������ where current of Primer;
	fetch Primer into @tn, @tc, @tk;
	Update ������ set ���������� = ���������� + 1 Where	current of Primer;
close Primer;

select * from ������;

insert ������(ID_������, �����, ����������, ����, �����, ���_��������, ��������) 
							values (5, '�����', 12, '2023-12-05', '������� ������, ��� 7, ����� ��������', '���������', '�����-����� ������'); 
update ������ set ���������� = ���������� - 1 where ID_������ = 6;