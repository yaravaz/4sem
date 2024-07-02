
use Univer;

create table TR_AUDIT
(
	ID		int identity,
	STMT	varchar(20) check (STMT in ('INS', 'DEL', 'UPD')),
	TRNAME	varchar(50),
	CC		varchar(100)
)
go

select * from STUDENT

create trigger TRIG_TEACHER_INS on Teacher after insert
	as declare @a1 varchar(20), @a2 varchar, @a3 varchar, @in varchar(300);
	print 'операция вставки';
	set @a1 = (select [Teacher_name] from inserted);
	set @a2 = (select [Gender] from inserted);
	set @a3 = (select [Pulpit] from inserted);
	set @in = @a1 + ' ' + @a2 + ' ' + @a3;
	insert into TR_AUDIT(STMT, TRNAME, CC) values('INS', 'Trig_teacher_ins', @in);
	return;

insert into Teacher(TEACHER, TEACHER_NAME, GENDER, PULPIT) values ('New', 'NewNew', 'м', 'ИСиТ');
select * from TR_AUDIT;

delete teacher where TEACHER='new';
delete TR_AUDIT where STMT = 'INS'
drop trigger TRIG_TEACHER_INS;

go
--------------------------------

create trigger TRIG_TEACHER_DEL on Teacher after delete
	as declare @a1 varchar(20), @a2 varchar, @a3 varchar, @in varchar(300);
	print 'операция удаления';
	set @a1 = (select [Teacher_name] from deleted);
	set @a2 = (select [Gender] from deleted);
	set @a3 = (select [Pulpit] from deleted);
	set @in = @a1 + ' ' + @a2 + ' ' + @a3;
	insert into TR_AUDIT(STMT, TRNAME, CC) values('DEL', 'Trig_teacher_del', @in);
	return;

delete Teacher where TEACHER = 'АКНВЧ';
select * from TR_AUDIT;

insert into Teacher(TEACHER, TEACHER_NAME, GENDER, PULPIT) values ('АКНВЧ', 'Акунович Станислав Иванович', 'м', 'ИСиТ');
delete TR_AUDIT where STMT = 'DEL'
drop trigger TRIG_TEACHER_DEL;

go

-------------------------------

create trigger TRIG_TEACHER_UPD on Teacher after update
	as declare @a1 varchar(30), @a2 varchar, @a3 varchar(5), @in varchar(300);
	print 'операция изменения';
	set @a1 = (select [Teacher_name] from inserted);
	set @a2 = (select [Gender] from inserted);
	set @a3 = (select [Pulpit] from inserted);
	set @in = @a1 + ' ' + @a2 + ' ' + @a3;

	set @a1 = (select [Teacher_name] from deleted);
	set @a2 = (select [Gender] from deleted);
	set @a3 = (select [Pulpit] from deleted);
	set @in = @in +' '+ @a1 + ' ' + @a2 + ' ' + @a3;
	insert into TR_AUDIT(STMT, TRNAME, CC) values('UPD', 'Trig_teacher_upd', @in);
	return;

update Teacher set TEACHER_NAME='newnew' where TEACHER_NAME = 'Акунович Станислав Иванович';
select * from TR_AUDIT;

update Teacher set TEACHER_NAME = 'Акунович Станислав Иванович' where TEACHER_NAME='newnew';
delete TR_AUDIT where STMT = 'UPD'
drop trigger TRIG_TEACHER_UPD;
go

-----------------------------

create trigger TRIG_TEACHER on Teacher after insert, delete, update
	as declare @a1 varchar(30), @a2 varchar, @a3 varchar(5), @in varchar(300);
	declare @ins int = (select count(*) from inserted),
			@del int = (select count(*) from deleted);
	if(@ins > 0 and @del = 0)
	begin 
		print 'операция вставки';
		set @a1 = (select [Teacher_name] from inserted);
		set @a2 = (select [Gender] from inserted);
		set @a3 = (select [Pulpit] from inserted);
		set @in = @a1 + ' ' + @a2 + ' ' + @a3;
		insert into TR_AUDIT(STMT, TRNAME, CC) values('INS', 'Trig_teacher', @in);
	end;
	else
	if(@ins = 0 and @del > 0)
	begin 
		print 'операция удаления';
		set @a1 = (select [Teacher_name] from deleted);
		set @a2 = (select [Gender] from deleted);
		set @a3 = (select [Pulpit] from deleted);
		set @in = @a1 + ' ' + @a2 + ' ' + @a3;
		insert into TR_AUDIT(STMT, TRNAME, CC) values('DEL', 'Trig_teacher', @in);
	end;
	else
	if(@ins > 0 and @del > 0)
	begin 
		print 'операция изменения';
		set @a1 = (select [Teacher_name] from inserted);
		set @a2 = (select [Gender] from inserted);
		set @a3 = (select [Pulpit] from inserted);
		set @in = @a1 + ' ' + @a2 + ' ' + @a3;

		set @a1 = (select [Teacher_name] from deleted);
		set @a2 = (select [Gender] from deleted);
		set @a3 = (select [Pulpit] from deleted);
		set @in = @in + @a1 + ' ' + @a2 + ' ' + @a3;
		insert into TR_AUDIT(STMT, TRNAME, CC) values('UPD', 'Trig_teacher', @in);
	end;
return;

insert into Teacher(TEACHER, TEACHER_NAME, GENDER, PULPIT) values ('New', 'NewNew', 'м', 'ИСиТ');
delete Teacher where TEACHER = 'АКНВЧ';
update Teacher set TEACHER_NAME='newnew' where TEACHER_NAME = 'Акунович Станислав Иванович';

select * from TR_AUDIT;

delete teacher where TEACHER='new';
insert into Teacher(TEACHER, TEACHER_NAME, GENDER, PULPIT) values ('АКНВЧ', 'Акунович Станислав Иванович', 'м', 'ИСиТ');
update Teacher set TEACHER_NAME = 'Акунович Станислав Иванович' where TEACHER_NAME='newnew';
drop trigger TRIG_TEACHER;

delete TR_AUDIT where STMT = 'INS'
delete TR_AUDIT where STMT = 'DEL'
delete TR_AUDIT where STMT = 'UPD'
go

------------------------------

update TEACHER set GENDER = 'N' where TEACHER_NAME = 'newnew'
go

-------------------------------

create trigger TR_TEACHER_DEL1 on TEACHER after delete
as print 'Trigger 1'
return;
go
create trigger TR_TEACHER_DEL2 on TEACHER after delete
as print 'Trigger 2'
return;  
go
create trigger TR_TEACHER_DEL3 on TEACHER after delete
as print 'Trigger 3'
return;  


select t.name, e.type_desc 
from sys.triggers t join  sys.trigger_events e  
on t.object_id = e.object_id  
where OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE'

exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE'
exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last',  @stmttype = 'DELETE'

insert into TEACHER values('new','newnew','м','ИСиТ')
delete from TEACHER where TEACHER = 'new'
select * from TR_AUDIT
go

-------------------------------

create trigger PulpitTran on PULPIT after insert,delete,update
as 
	declare @c int = (select count (*) from PULPIT); 	 
	if (@c > 18) 
	begin
		raiserror('общее количество кафедр не может превышать 18', 10, 1);
	end;
	rollback;
	return;    
insert into PULPIT(PULPIT,PULPIT_NAME,FACULTY) values('new','new','ИТ')
select count(*) from PULPIT;
go
----------------------------------
create trigger F_INSTEAD_OF on FACULTY instead of delete
as
	raiserror('нельзя удалять',10,1)
	return
go
delete FACULTY where FACULTY = 'ИТ'

drop trigger F_INSTEAD_OF


drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3
drop trigger PulpitTran
go

---------------------------------

create trigger TR_BASE_DDL on database for DDL_DATABASE_LEVEL_EVENTS  
as   
	declare @EVENT_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)')
	declare @OBJ_NAME varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)')
	declare @OBJ_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)')
	if @EVENT_TYPE = 'DROP_TABLE' or  @EVENT_TYPE = 'ALTER_TABLE' or  @EVENT_TYPE = 'CREATE_TABLE'
	begin
		print 'Тип события: ' + cast(@EVENT_TYPE as varchar)
		print 'Имя объекта: ' + cast(@OBJ_NAME as varchar)
		print 'Тип объекта: ' + cast(@OBJ_TYPE as varchar)
		raiserror('Операции с таблицей запрещены.', 16, 1)
		rollback  
	end

alter table TEACHER drop column TEACHER_NAME
drop table TEACHER
create table qwerty(
	id int primary key,
	value varchar(1)
)
drop trigger TR_BASE_DDL
go

----------------V_MyBASE-------------
use V_MyBASE

create table TR_Tov
(
	ID		int identity,
	ST		varchar(20) check (ST in ('INS', 'DEL', 'UPD')),
	TRN		varchar(50),
	C		varchar(300)
)
go

create trigger TRIG_TOVAR_INS on Товары after insert
	as declare @a1 varchar(20), @a2 real, @a3 varchar, @in varchar(300);
	print 'операция вставки';
	set @a1 = (select [Наименование_товара] from inserted);
	set @a2 = (select [Цена] from inserted);
	set @a3 = (select [Описание] from inserted);
	set @in = @a1 + ' ' + convert(varchar, @a2) + ' ' + @a3;
	insert into TR_Tov(ST, TRN, C) values('INS', 'Trig_tovar_ins', @in);
	return;

insert into Товары(Наименование_товара, Цена, Описание) values ('New', 23.3, 'newnewnew');
select * from TR_Tov;

delete товары where Наименование_товара='new';
delete TR_Tov where ST = 'INS'
drop trigger TRIG_TOVAR_INS
go
--------------------------------

create trigger TRIG_TOVAR_DEL on Товары after delete
	as declare @a1 varchar(20), @a2 real, @a3 varchar, @in varchar(300);
	print 'операция удаления';
	set @a1 = (select [Наименование_товара] from deleted);
	set @a2 = (select [Цена] from deleted);
	set @a3 = (select [Описание] from deleted);
	set @in = @a1 + ' ' + convert(varchar, @a2) + ' ' + @a3;
	insert into TR_Tov(ST, TRN, C) values('DEL', 'Trig_tovar_del', @in);
	return;

delete Товары where Наименование_товара = 'Шуфлятка';
select * from TR_Tov;

insert into Товары(Наименование_товара, Цена, Описание) values ('Шуфлятка', 353, 'описание');
delete TR_Tov where ST = 'DEL'
drop trigger TRIG_TOVAR_DEL
go

-------------------------------

create trigger TRIG_TOVAR_UPD on Товары after update
	as declare @a1 varchar(20), @a2 real, @a3 varchar, @in varchar(300);
	print 'операция изменения';
	set @a1 = (select [Наименование_товара] from inserted);
	set @a2 = (select [Цена] from inserted);
	set @a3 = (select [Описание] from inserted);
	set @in = @a1 + ' ' + cast(@a2 as varchar(20)) + ' ' + @a3;

	set @a1 = (select [Наименование_товара] from deleted);
	set @a2 = (select [Цена] from deleted);
	set @a3 = (select [Описание] from deleted);
	set @in = @a1 + ' ' + cast(@a2 as varchar(20)) + ' ' + @a3;
	insert into TR_Tov(ST, TRN, C) values('UPD', 'Trig_tovar_upd', @in);
	return;

update ТОВАРЫ set Наименование_товара='newnew' where Наименование_товара = 'Шуфлятка';
select * from TR_Tov;

update ТОВАРЫ set Наименование_товара = 'Шуфлятка' where Наименование_товара='newnew';
delete TR_Tov where ST = 'UPD'
drop trigger TRIG_TOVAR_UPD
go

-----------------------------

create trigger TRIG_TOVAR on Товары after insert, delete, update
	as declare @a1 varchar(20), @a2 real, @a3 varchar, @in varchar(300);
	declare @ins int = (select count(*) from inserted),
			@del int = (select count(*) from deleted);
	if(@ins > 0 and @del = 0)
	begin 
		print 'операция вставки';
		set @a1 = (select [Наименование_товара] from inserted);
		set @a2 = (select [Цена] from inserted);
		set @a3 = (select [Описание] from inserted);
		set @in = @a1 + ' ' + convert(varchar, @a2) + ' ' + @a3;
		insert into TR_Tov(ST, TRN, C) values('INS', 'Trig_tovar_ins', @in);
	end;
	else
	if(@ins = 0 and @del > 0)
	begin 
		print 'операция удаления';
		set @a1 = (select [Наименование_товара] from deleted);
		set @a2 = (select [Цена] from deleted);
		set @a3 = (select [Описание] from deleted);
		set @in = @a1 + ' ' + convert(varchar, @a2) + ' ' + @a3;
		insert into TR_Tov(ST, TRN, C) values('DEL', 'Trig_tovar_del', @in);
	end;
	else
	if(@ins > 0 and @del > 0)
	begin 
		print 'операция изменения';
		set @a1 = (select [Наименование_товара] from inserted);
		set @a2 = (select [Цена] from inserted);
		set @a3 = (select [Описание] from inserted);
		set @in = @a1 + ' ' + cast(@a2 as varchar(20)) + ' ' + @a3;

		set @a1 = (select [Наименование_товара] from deleted);
		set @a2 = (select [Цена] from deleted);
		set @a3 = (select [Описание] from deleted);
		set @in = @a1 + ' ' + cast(@a2 as varchar(20)) + ' ' + @a3;
		insert into TR_Tov(ST, TRN, C) values('UPD', 'Trig_tovar_upd', @in);
	end;
return;

insert into Товары(Наименование_товара, Цена, Описание) values ('New', 23.3, 'newnewnew');
delete Товары where Наименование_товара = 'Шуфлятка';
update ТОВАРЫ set Наименование_товара='newnew' where Наименование_товара = 'Шуфлятка';
select * from TR_Tov;

delete товары where Наименование_товара='new';
insert into Товары(Наименование_товара, Цена, Описание) values ('Шуфлятка', 353, 'описание');
update ТОВАРЫ set Наименование_товара = 'Шуфлятка' where Наименование_товара='newnew';

delete TR_Tov where ST = 'UPD'
delete TR_Tov where ST = 'INS'
delete TR_Tov where ST = 'DEL'

drop trigger TRIG_TOVAR
go

-------------------------------

create trigger TR_TOVAR_DEL1 on Товары after delete
as print 'Trigger 1'
return;
go
create trigger TR_TOVAR_DEL2 on Товары after delete
as print 'Trigger 2'
return;  
go
create trigger TR_TOVAR_DEL3 on Товары after delete
as print 'Trigger 3'
return;  


select t.name, e.type_desc 
from sys.triggers t join  sys.trigger_events e  
on t.object_id = e.object_id  
where OBJECT_NAME(t.parent_id) = 'Товары' and e.type_desc = 'DELETE'

exec SP_SETTRIGGERORDER @triggername = 'TR_TOVAR_DEL3', @order = 'First', @stmttype = 'DELETE'
exec SP_SETTRIGGERORDER @triggername = 'TR_TOVAR_DEL2', @order = 'Last',  @stmttype = 'DELETE'

insert into Товары values('new',334,'newnew')
delete from Товары where Наименование_товара = 'new'
select * from TR_Tov
go

-------------------------------

create trigger OrderTran on Заказы after insert,delete,update
as 
	declare @c int = (select count (*) from Заказы); 	 
	if (@c > 9) 
	begin
		raiserror('общее количество заказов не может превышать 9', 10, 1);
	end;
	rollback;
	return;    
insert into Заказы(ID_заказа, Товар, Количество, Дата, Адрес, Вид_доставки, Заказчик) values(1, 'Стол', 2, '1212-12-12', 'new', 'почта', 'Прима-Стайл Мебель')
select count(*) from Заказы;
go
----------------------------------

create trigger T_INSTEAD_OF on Товары instead of delete
as
	raiserror('нельзя удалять',10,1)
	return
go
delete Товары where Наименование_товара = 'Стол'

drop trigger T_INSTEAD_OF
drop trigger TRIG_TOVAR_INS;
drop trigger TRIG_TOVAR_DEL;
drop trigger TRIG_TOVAR_UPD;
drop trigger TRIG_TOVAR;
drop trigger TR_TOVAR_DEL1
drop trigger TR_TOVAR_DEL2
drop trigger TR_TOVAR_DEL3
drop trigger OrderTran
go

---------------------------------

create trigger TR_BASE_DDL on database for DDL_DATABASE_LEVEL_EVENTS  
as   
	declare @EVENT_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)')
	declare @OBJ_NAME varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)')
	declare @OBJ_TYPE varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)')
	if @EVENT_TYPE = 'DROP_TABLE' or  @EVENT_TYPE = 'ALTER_TABLE' or  @EVENT_TYPE = 'CREATE_TABLE'
	begin
		print 'Тип события: ' + cast(@EVENT_TYPE as varchar)
		print 'Имя объекта: ' + cast(@OBJ_NAME as varchar)
		print 'Тип объекта: ' + cast(@OBJ_TYPE as varchar)
		raiserror('Операции с таблицей запрещены.', 16, 1)
		rollback  
	end

alter table Товары drop column Описание
drop table Товары
create table qwerty(
	id int primary key,
	value varchar(1)
)
drop trigger TR_BASE_DDL
go



------------------------

use UNIVER
select * from Student

use master
create table NewStudent
(
	IDSTUDENT   integer constraint NEWSTUDENT_PK  primary key,
    IDGROUP integer,        
    NAME   nvarchar(100), 
    BDAY   date
)

insert into NewStudent (IDSTUDENT, IDGROUP, NAME , BDAY)
    values (1000, 2, 'Силюк Валерия Ивановна',         '12.07.1994'),
           (1001, 2, 'Сергель Виолетта Николаевна',    '06.03.1994'),
           (1002, 2, 'Добродей Ольга Анатольевна',     '09.11.1994'),
           (1003, 2, 'Подоляк Мария Сергеевна',        '04.10.1994');

go
create trigger trig on NewStudent instead of insert
as
	declare @p1 int = (select IDSTUDENT from inserted);
	declare @p2 int = (select IDGROUP from inserted);
	if @p1 = 1000 and @p2 = 3
		begin
			update NewStudent set IDGROUP = 9 where IDSTUDENT = @p1;
		end;
	return
go

insert NewStudent(IDSTUDENT, IDGROUP, NAME, BDAY) values(1000, 3, 'Силюк Валерия Ивановна', '1994-07-12');
select * from NewStudent
update NewStudent set IDGROUP = 2 where IDSTUDENT = 1000
drop trigger trig
drop table NewStudent