
use Univer;

Declare DistIc Cursor for select Subject from Subject where PULPIT = 'ИСиТ';

Declare @di nvarchar(20), @collection nvarchar(200) = '';
OPEN DistIc;
Fetch DistIc into @di;
print 'дисциплины Исит:';
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
						for Select Subject, Subject_Name from SUBJECT where Pulpit = 'ИСиТ';

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
					for Select Subject, Subject_Name from SUBJECT where Pulpit = 'ИСиТ';

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
				for Select Subject, Subject_Name from SUBJECT where Pulpit = 'ИСиТ';

open Dist_;
print 'кол-во строк: '+ cast(@@cursor_rows as nvarchar(5));
update Subject set SUBJECT_Name = 'пример' where SUBJECT = 'ЭТ';
Delete SUBJECT where SUBJECT = 'ЭП';
Insert subject (subject, subject_name, pulpit) values('ЭХ', 'Новая дисциплина', 'ИСиТ');

fetch Dist_ into @dis, @namedist;
while(@@FETCH_STATUS = 0)
	begin
		print @dis + ' ' + @namedist
		fetch Dist_ into @dis, @namedist;
	end;
close Dist_;
deallocate Dist_;

select * from SUBJECT;

update subject set SUBJECT_NAME = 'Экономические технологии' where subject = 'ЭТ';
insert subject (subject, subject_name, pulpit) values('ЭП', 'Экономическая политика', 'ЭТиМ');
delete subject where subject = 'ЭХ';

-----

Declare @dist nvarchar(20), @namedis nvarchar(50);

Declare Dist_ Cursor
				for Select Subject, Subject_Name from SUBJECT where Pulpit = 'ИСиТ';

open Dist_;
print 'кол-во строк: '+ cast(@@cursor_rows as nvarchar(5));
update Subject set SUBJECT_Name = 'пример' where SUBJECT = 'ЭТ';
Delete SUBJECT where SUBJECT = 'ЭП';
Insert subject (subject, subject_name, pulpit) values('ЭХ', 'Новая дисциплина', 'ИСиТ');

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

update subject set SUBJECT_NAME = 'Экономические технологии' where subject = 'ЭТ';
insert subject (subject, subject_name, pulpit) values('ЭП', 'Экономическая политика', 'ЭТиМ');
delete subject where subject = 'ЭХ';

-------------------------------

Declare @di nvarchar(15), @diname nvarchar(30);
Declare Dist Cursor Local static scroll
				for Select Subject, Subject_Name from SUBJECT where Pulpit = 'ИСиТ';

open Dist;
print 'кол-во строк: '+ cast(@@cursor_rows as nvarchar(5));
fetch Dist into @di, @diname;
print 'следующая строка ' + @di + ' ' + @diname;
fetch last from Dist into @di, @diname;
print 'последняя строка ' + @di + ' ' + @diname;
fetch next from Dist into @di, @diname;
print 'следующая после текущей строка ' + @di + ' ' + @diname;
fetch prior from Dist into @di, @diname;
print 'предыдущая строка ' + @di + ' ' + @diname;
fetch absolute 3 from Dist into @di, @diname;
print '3 с начала строка ' + @di + ' ' + @diname;
fetch absolute -3 from Dist into @di, @diname;
print '3 с конца строка ' + @di + ' ' + @diname;
fetch relative 3 from Dist into @di, @diname;
print 'третья после текущей строка ' + @di + ' ' + @diname;
fetch relative -3 from Dist into @di, @diname;
print 'третья перед текущей строка ' + @di + ' ' + @diname;
close Dist;
deallocate Dist;

---------------------------------------

Declare @disti nvarchar(10), @distiname nvarchar(20);
Declare Dist Cursor local dynamic
							for select subject, subject_name from subject where PULPIT='ИСиТ' for update;

Open Dist;
fetch Dist into @disti, @distiname;
delete Subject where Current of Dist;
fetch Dist into @disti, @distiname;
update Subject set SUBJECT_NAME = 'новое имя' where current of Dist;
Close Dist;
deallocate Dist;

select * from subject;

insert subject(SUBJECT, SUBJECT_NAME, PULPIT)
								values('БД', 'Базы данных', 'ИСиТ');
update subject set SUBJECT_NAME = 'Дискретная математика' where subject = 'ДМ'

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
values  ('ОАИП', 1000,  '01.10.2013',3),
        ('ООП', 1001,  '01.12.2013',2),
		('ОАИП',   1002,  '06.5.2013',2),
        ('ПСП',   1003,  '01.1.2013',2),
        ('ПСП',   1004,  '01.1.2013',2)

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
				for select Товар from ЗАКАЗЫ;
open ZkTovar;
fetch ZkTovar into @tv;
print 'заказанные товары';
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
				for select Наименование_товара, Цена from ТОВАРЫ;
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
				for select Наименование_товара, Цена from ТОВАРЫ;
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
		 for SELECT Товар, Дата, Количество 
		       FROM ЗАКАЗЫ where Заказчик = 'Прима-Стайл Мебель';				   
open Zakaz;
print   'Количество строк : '+cast(@@CURSOR_ROWS as varchar(5)); 
UPDATE Заказы set Количество = 5 where ID_заказа = 6;
DELETE Заказы where Товар = 'Тумба';
INSERT Заказы (ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) 
	                 values (18, 'Шкаф', 340, '2014-08-02', 'Ул. Сталеваров 2', 'почта', 'Прима-Стайл Мебель'); 

FETCH  Zakaz into @tid, @tnm, @tgn;     
while @@fetch_status = 0                                    
   begin 
      print @tid + ' '+ @tnm + ' '+ @tgn;      
      fetch Zakaz into @tid, @tnm, @tgn; 
   end;          
close  Zakaz;

select * from Заказы;

UPDATE Заказы set Количество = 12 where ID_заказа = 6;
INSERT Заказы (ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) 
	                 values (5, 'Тумба', 12, '2023-12-05', 'Площадь Победы, дом 7, город Звездное', 'самовывоз', 'Прима-Стайл Мебель'); 
Delete Заказы where ID_заказа = 18; 

-----

DECLARE @tid2 char(10), @tnm2 char(40), @tgn2 char(10);  
DECLARE Zakaz CURSOR LOCAL Dynamic                              
		 for SELECT Товар, Дата, Количество 
		       FROM ЗАКАЗЫ where Заказчик = 'Прима-Стайл Мебель';				   
open Zakaz;
print   'Количество строк : '+cast(@@CURSOR_ROWS as varchar(5)); 
UPDATE Заказы set Количество = 5 where ID_заказа = 6;
DELETE Заказы where Товар = 'Тумба';
INSERT Заказы (ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) 
	                 values (18, 'Шкаф', 340, '2014-08-02', 'Ул. Сталеваров 2', 'почта', 'Прима-Стайл Мебель'); 

FETCH  Zakaz into @tid2, @tnm2, @tgn2;     
while @@fetch_status = 0                                    
   begin 
      print @tid2 + ' '+ @tnm2 + ' '+ @tgn2;      
      fetch Zakaz into @tid2, @tnm2, @tgn2; 
   end;          
close  Zakaz;

select * from Заказы;

UPDATE Заказы set Количество = 12 where ID_заказа = 6;
INSERT Заказы (ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) 
	                 values (5, 'Тумба', 12, '2023-12-05', 'Площадь Победы, дом 7, город Звездное', 'самовывоз', 'Прима-Стайл Мебель'); 
Delete Заказы where ID_заказа = 18; 

-----------------------------------------------------

Declare @di nvarchar(15), @diname nvarchar(30);
Declare Zakaz Cursor Local static scroll
				for Select Товар, Количество from ЗАКАЗЫ where Заказчик = 'Прима-Стайл Мебель';

open Zakaz;
print 'кол-во строк: '+ cast(@@cursor_rows as nvarchar(5));
fetch Zakaz into @di, @diname;
print 'следующая строка ' + @di + ' ' + @diname;
fetch last from Zakaz into @di, @diname;
print 'последняя строка ' + @di + ' ' + @diname;
fetch next from Zakaz into @di, @diname;
print 'следующая после текущей строка ' + @di + ' ' + @diname;
fetch prior from Zakaz into @di, @diname;
print 'предыдущая строка ' + @di + ' ' + @diname;
fetch absolute 3 from Zakaz into @di, @diname;
print '3 с начала строка ' + @di + ' ' + @diname;
fetch absolute -3 from Zakaz into @di, @diname;
print '3 с конца строка ' + @di + ' ' + @diname;
fetch relative 3 from Zakaz into @di, @diname;
print 'третья после текущей строка ' + @di + ' ' + @diname;
fetch relative -3 from Zakaz into @di, @diname;
print 'третья перед текущей строка ' + @di + ' ' + @diname;
close Zakaz;
deallocate Zakaz;

--------------------------------------------

declare @tn char(20), @tc int, @tk nvarchar(20);
declare Primer cursor local dynamic
							for select Товар, Количество, Заказчик from ЗАКАЗЫ for update;

open Primer;
	fetch Primer into @tn, @tc, @tk;
	delete ЗАКАЗЫ where current of Primer;
	fetch Primer into @tn, @tc, @tk;
	Update ЗАКАЗЫ set Количество = Количество + 1 Where	current of Primer;
close Primer;

select * from ЗАКАЗЫ;

insert ЗАКАЗЫ(ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) 
							values (5, 'Тумба', 12, '2023-12-05', 'Площадь Победы, дом 7, город Звездное', 'самовывоз', 'Прима-Стайл Мебель'); 
update ЗАКАЗЫ set Количество = Количество - 1 where ID_заказа = 6;